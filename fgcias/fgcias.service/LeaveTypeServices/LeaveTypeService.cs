using fgcias.domain.clsFilterParameter;
using fgcias.domain.clsLeaveTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace fgcias.service.LeaveTypeServices
{
    public class LeaveTypeService : ILeaveTypeService
    {

        private readonly HttpClient client;

        public LeaveTypeService(HttpClient _client)
        {
            this.client = _client;
        }

        #region Get LeaveType
        public async Task<List<LeaveTypesModel>> GetLeaveType(FilterParameter filterParameter, string token)
        {
            List<LeaveTypesModel> leaveTypes = new List<LeaveTypesModel>();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage responseMessage = await client.GetAsync("/attendance/leave-types/active=" + (filterParameter.IsActive ? 1 : 0));
            if (responseMessage.IsSuccessStatusCode)
                leaveTypes = await responseMessage.Content.ReadAsAsync<List<LeaveTypesModel>>();

            return leaveTypes;
        }
        #endregion

        #region Add Leave Type
        public async Task<LeaveTypesModel> AddleaveType(LeaveTypesModel leaveTypeAddModel, string token)
        {
            try
            {
              LeaveTypesModel leaveTypes = new LeaveTypesModel();
              client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
              HttpResponseMessage responseMessage = await client.PostAsJsonAsync("/attendance/leave-types/", leaveTypeAddModel);
              if(responseMessage.IsSuccessStatusCode)
              {
                leaveTypes = await responseMessage.Content.ReadAsAsync<LeaveTypesModel>();
              }
              return leaveTypes;
            }
            catch (Exception ex)
            {
              return null;
            }
        }
        #endregion

        #region Update Leave Type
        public async Task<LeaveTypesModel> UpdateleaveType(LeaveTypesModel leaveTypeUpdateModel, string token)
        {
            LeaveTypesModel leaveTypes = new LeaveTypesModel();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await client.PutAsJsonAsync("/attendance/leave-types/", leaveTypeUpdateModel);
            if (response.IsSuccessStatusCode)
            {
                leaveTypes = JsonConvert.DeserializeObject<LeaveTypesModel>(await response.Content.ReadAsStringAsync());
            }
            return leaveTypes;
        }
        #endregion

        
    }
}
