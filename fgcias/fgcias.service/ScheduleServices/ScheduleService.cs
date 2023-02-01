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
using fgcias.domain.clsSchedule;


namespace fgcias.service.ScheduleServices
{
    public class ScheduleService : IScheduleService
    {
        
        private readonly HttpClient client;
        public ScheduleService(HttpClient _client)
        {
            this.client = _client;
        }
        #region Get Schedule
        public async Task<List<ScheduleModel>> GetSchedules(bool isActive, string token)
        {
            List<ScheduleModel> scheduleModel = new List<ScheduleModel>();

            int isActiveValue = Convert.ToInt32(isActive);

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await client.GetAsync("/attendance/schedules/active=" + isActiveValue);
            if (response.IsSuccessStatusCode)
            {
                scheduleModel = await response.Content.ReadAsAsync<List<ScheduleModel>>();
            }
            return scheduleModel;
        }
        #endregion

        #region Add Schedule
        public async Task<ScheduleModel> AddSchedule(ScheduleModel scheduleModel, string token)
        {
            try
            {
              ScheduleModel schedModel = new ScheduleModel();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                HttpResponseMessage responseMessage = await client.PostAsJsonAsync("/attendance/schedules", scheduleModel);
                if(responseMessage.IsSuccessStatusCode)
                {
                    schedModel = await responseMessage.Content.ReadAsAsync<ScheduleModel>();
                }
                return schedModel;
            }
            
            catch(Exception ex)
            {
                return null;
            }
        }
        #endregion

        #region Update Schedule
        public async Task<ScheduleModel> UpdateSchedule(ScheduleModel scheduleModel, string token)
        {
            try 
            { 
                ScheduleModel schedules = new ScheduleModel();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                HttpResponseMessage responseMessage = await client.PutAsJsonAsync("/attendance/schedules", scheduleModel);
                if(responseMessage.IsSuccessStatusCode)
                {
                    schedules = JsonConvert.DeserializeObject<ScheduleModel>(await responseMessage.Content.ReadAsStringAsync());
                }
                return schedules;
            }
            catch( Exception ex)
            {
                return null;
            }
        }

        #endregion

    }
}
