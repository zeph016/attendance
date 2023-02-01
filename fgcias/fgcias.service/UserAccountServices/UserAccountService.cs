using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Microsoft.Extensions.Configuration;
using fgcias.domain.clsUserAccount;

namespace fgcias.service.UserAccountServices
{   
    public class UserAccountService : IUserAccountService
    {
        private readonly HttpClient client;
        public UserAccountService(HttpClient _client) => client = _client;

        public async Task<UserAccountModel> AuthenticateToken(UserAccountModel userAccount, string token)
        {
            try
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var parameter = JsonConvert.SerializeObject(new { systemname = userAccount.SystemName });
                var bodyContent = new StringContent(parameter, Encoding.UTF8, "application/json");
                var httpResponse = await client.PostAsync("/hub/accounts/authenticate/system", bodyContent);
                if (httpResponse.IsSuccessStatusCode)
                {
                    userAccount = await httpResponse.Content.ReadAsAsync<UserAccountModel>();
                    userAccount.httpResponse = httpResponse.StatusCode;
                }
                else
                    userAccount.httpResponse = httpResponse.StatusCode;
                return userAccount;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
    }
}