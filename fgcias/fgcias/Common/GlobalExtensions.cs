using System;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.IdentityModel.Tokens.Jwt;
using fgcias.Common;
using Microsoft.JSInterop;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.AspNetCore.Components;
using Blazored.LocalStorage;
using MudBlazor;
using fgcias.domain.clsUserAccount;
using fgcias.service.UserAccountServices;
using fgcias.service.GlobalServices;



public static class Extensions
{
    public static bool CheckGlobalToken()
    {
        if (string.IsNullOrWhiteSpace(GlobalClass.token)) {
            return false;
        } else if (!string.IsNullOrWhiteSpace(GlobalClass.token)) {
            return true;
        }
        return false;
    }
    public static async Task<bool> CheckGlobalTokenV2(ILocalStorageService localStorageService)
    {
        GlobalClass.token = await localStorageService.GetItemAsync<string>("token");
        if (!string.IsNullOrWhiteSpace(GlobalClass.token))
            return true;
        return false;
    }

    public static async Task<bool> ValidateToken(IUserAccountService userAccountService, ILocalStorageService localStorageService, IJSRuntime jsRuntimeService)
    {
        bool isTokenExist = await CheckGlobalTokenV2(localStorageService) ? true : await GetSetToken(localStorageService, jsRuntimeService);
        bool isAuthExpired;
        if (isTokenExist) {
            isAuthExpired = isTokenExpired(await localStorageService.GetItemAsync<string>("token"));
            if (!isAuthExpired) {
                await ClearRemainingCookie(jsRuntimeService);
                return await AuthenticateToken(userAccountService, GlobalClass.token);
            }
            else if (isAuthExpired) {
                await GetSetToken(localStorageService, jsRuntimeService);
                return await AuthenticateToken(userAccountService, GlobalClass.token);
            }
        }
        return false;
    }

    public static async Task<bool> GetSetToken(ILocalStorageService localStorageService, IJSRuntime jsRuntimeService)
    {
        var cookieToken = await jsRuntimeService.InvokeAsync<string>("GetCookie", "token");
        if (!string.IsNullOrWhiteSpace(cookieToken)) {
            await localStorageService.SetItemAsync<string>("token", cookieToken);
            GlobalClass.token = await localStorageService.GetItemAsync<string>("token");
            await jsRuntimeService.InvokeAsync<string>("DeleteCookie");
            return true;
        } else if (string.IsNullOrWhiteSpace(cookieToken))
            return false;
        return false;
    }
    public static async Task ClearAllToken(ILocalStorageService localStorageService, IJSRuntime jsRuntimeService)
    {
        await localStorageService.ClearAsync();
        await jsRuntimeService.InvokeAsync<string>("DeleteCookie");
    }

    public static async Task ClearRemainingCookie(IJSRuntime jsRuntimeService)
    {
        await jsRuntimeService.InvokeAsync<string>("DeleteCookie");
    }

    public static async Task<bool> AuthenticateToken(IUserAccountService userAccountService, string token)
    {
        UserAccountModel userAccount = await userAccountService.AuthenticateToken(new UserAccountModel(), token);
        GlobalClass.currentUserAccount = userAccount ?? new UserAccountModel();
        Console.WriteLine(GlobalClass.currentUserAccount.httpResponse);
        if (GlobalClass.currentUserAccount.httpResponse == System.Net.HttpStatusCode.OK 
        && GlobalClass.currentUserAccount.httpResponse != System.Net.HttpStatusCode.Unauthorized)
            return true;
        return false;
    }
    public static string GetEnumDescription(Enum value)  
    {  
        var enumMember = value.GetType().GetMember(value.ToString()).FirstOrDefault();  
        var descriptionAttribute =  
            enumMember == null  
                ? default(DescriptionAttribute)  
                : enumMember.GetCustomAttribute(typeof(DescriptionAttribute)) as DescriptionAttribute;  
        return  
            descriptionAttribute == null  
                ? value.ToString()  
                : descriptionAttribute.Description;  
    }

    public static bool isTokenExpired(string token)
    {
        const int second = 1;
        const int minute = 60 * second;
        const int hour = 60 * minute;

        var handler = new JwtSecurityTokenHandler(); 
        var jwt = handler.ReadJwtToken(token);
        var name = jwt.Claims.First(claim => claim.Type == "unique_name").Value;
        var userId = jwt.Claims.First(claim => claim.Type == "EmployeeId").Value;
        var tokenDate = jwt.Claims.First(claim => claim.Type == "exp").Value;
        DateTime expirationTime = DateTimeOffset.FromUnixTimeSeconds(long.Parse(tokenDate)).DateTime;
        
        var ts = new TimeSpan(DateTime.Now.Ticks - expirationTime.Ticks);
        double delta = Math.Abs(ts.TotalSeconds);
        if (delta > 8 * hour)
            return true;
        return false;
    }
    public static void ShowAlert(string message, Variant variant, ISnackbar snackbarService, Severity severityType)
    {
        snackbarService.Clear();
        snackbarService.Configuration.PositionClass = Defaults.Classes.Position.BottomCenter;
        snackbarService.Configuration.SnackbarVariant = variant;
        snackbarService.Configuration.MaxDisplayedSnackbars = 10;
        snackbarService.Configuration.VisibleStateDuration = 2000;
        snackbarService.Add($"{message}", severityType);
    }

    public static bool CheckUrlType(string url)
    {
        bool urlType = url.Contains("create") ? true : false;
        return urlType;
    }

    public static string GetIconValue(object iconType, string iconName)
    {
        return iconType.GetType().GetProperty(iconName)?.GetValue(iconType, null)?.ToString() ?? string.Empty;
    }
    public static string GetIconPrefix(string iconName)
    {
        return iconName.Split('.')[0]+"."+iconName.Split('.')[1]?? string.Empty;
    }
    public static string GetIconName(string iconName)
    {
        return iconName.Split(".")[2];
    }

    public static HubConnection ConnectionBuilder(string connection)
    {
      HubConnection hubConnection = new HubConnectionBuilder()
      .WithUrl(connection)
      .WithAutomaticReconnect()
      .Build();

       return hubConnection;
    }
    

    //NOT USED FOR NOW - MIGHT BE USED IN THE FUTURE
    public static ValueTask FocusAsync(this IJSRuntime jSRuntimeService, string className)
    {
        return jSRuntimeService.InvokeVoidAsync("AutoFocusElement", className);
    }
}
