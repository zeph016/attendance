global using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using fgcias;
using MudBlazor.Services;
using Blazored.LocalStorage;
using fgcias.service.UserAccountServices;
using fgcias.service.HolidayServices;
using fgcias.service.LocationServices;
using fgcias.service.ScheduleServices;
using fgcias.service.LeaveTypeServices;
using fgcias.service.SignatoriesServices;
using fgcias.service.GlobalServices;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.Configuration.GetValue<string>("BaseAPIUrl")) });
// builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddMudServices();
builder.Services.AddBlazoredLocalStorage();

builder.Services.AddScoped<IUserAccountService, UserAccountService>();
builder.Services.AddScoped<IHolidayService, HolidayService>();
builder.Services.AddScoped<IScheduleService, ScheduleService>();
builder.Services.AddScoped<ILocationService, LocationService>();
builder.Services.AddScoped<ILeaveTypeService, LeaveTypeService>();
builder.Services.AddScoped<ISignatoryService, SignatoryService>();
builder.Services.AddScoped<IGlobalService, GlobalService>();
//Microsoft.AspNetCore.Components.Authorization;
builder.Services.AddOptions();
builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthStateProvider>();
//

await builder.Build().RunAsync();
