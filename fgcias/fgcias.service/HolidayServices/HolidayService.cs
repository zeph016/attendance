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
using fgcias.domain.clsHoliday;
// using fgcias.domain.clsFilterParameter;

namespace fgcias.service.HolidayServices
{
    public class HolidayService : IHolidayService
    {
        private readonly HttpClient client;
        public HolidayService(HttpClient _client) => client = _client;

        #region Get holidays
        public async Task<List<HolidayModel>> GetHolidays(long year, string token)
        {
            List<HolidayModel> holidayModel = new List<HolidayModel>();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await client.GetAsync("/attendance/holidays/year="+year);
            if (response.IsSuccessStatusCode)
                holidayModel = await response.Content.ReadAsAsync<List<HolidayModel>>();
            return holidayModel;
        }
        #endregion

        #region Add Holidays
        public async Task<HolidayModel> AddHoliday(HolidayModel holidayModel, string token)
        {
            try
            {
                HolidayModel holidays = new HolidayModel();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                HttpResponseMessage responseMessage = await client.PostAsJsonAsync("/attendance/holidays", holidayModel);
                if(responseMessage.IsSuccessStatusCode)
                {
                    holidays = await responseMessage.Content.ReadAsAsync<HolidayModel>();
                }
                return holidays;
            }
            catch(Exception ex)
            {
                return null;
            }

        }
        
        #endregion

        #region Update Holiday by Id
        public async Task<HolidayModel> UpdateHolidayById(HolidayModel holidayModel, string token)
        {
             try
            {
                HolidayModel holidays = new HolidayModel();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                HttpResponseMessage responseMessage = await client.PutAsJsonAsync("/attendance/holidays", holidayModel);
                if(responseMessage.IsSuccessStatusCode)
                {
                    holidays = JsonConvert.DeserializeObject<HolidayModel>(await responseMessage.Content.ReadAsStringAsync());
                }
                return holidays;
            }
            catch(Exception ex)
            {
                return null;
            }
        }
        #endregion


    }
}
