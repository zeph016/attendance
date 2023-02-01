using fgcias.domain.clsLocation;
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
using fgcias.domain.clsFilterParameter;

namespace fgcias.service.LocationServices
{
    public class LocationService : ILocationService
    {
        private  readonly HttpClient client;
        public LocationService(HttpClient _client) => client = _client;
        
        #region Get Locations
        public async Task<List<LocationModel>> GetLocations(FilterParameter filterParameter, string token)
        {
            List<LocationModel> location = new List<LocationModel>();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage responseMessage = await client.GetAsync("/attendance/locations/active=" + (filterParameter.IsActive ? 1:0));
            if (responseMessage.IsSuccessStatusCode)
                location = await responseMessage.Content.ReadAsAsync<List<LocationModel>>();
            return location;
        }
        #endregion

        #region Get LocationsById
        public async Task<LocationModel> GetLocationById(long locationId, string token)
        {
            LocationModel location = new LocationModel();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage responseMessage = await client.GetAsync("/attendance/locations/" + (locationId));
            if (responseMessage.IsSuccessStatusCode)
                location = await responseMessage.Content.ReadAsAsync<LocationModel>();
            return location;
        }
        #endregion

        #region Add LocationName
        public async Task<LocationModel> AddLocationName(LocationModel locationAddModel, string token)
        {
            try
            {
              LocationModel location = new LocationModel();
              client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
              HttpResponseMessage responseMessage = await client.PostAsJsonAsync("/attendance/locations/", locationAddModel);
              if(responseMessage.IsSuccessStatusCode)
                location = await responseMessage.Content.ReadAsAsync<LocationModel>();
              return location;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return new LocationModel();
            }
        }
        #endregion

        #region Update Location
        public async Task<LocationModel> UpdateLocationName(LocationModel locationUpdateModel, string token)
        {
            LocationModel location = new LocationModel();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage responseMessage = await client.PutAsJsonAsync("/attendance/locations/", locationUpdateModel);
            if (responseMessage.IsSuccessStatusCode && responseMessage != null)
                location = await responseMessage.Content.ReadAsAsync<LocationModel>();
            return location;
        }
        // public async Task<LocationModel> UpdateLocationName(LocationModel locationUpdateModel, string token)
        // {
        //     LocationModel locationUp = new LocationModel();
        //     client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        //     HttpResponseMessage response = await client.PutAsJsonAsync("/attendance/locations/", locationUpdateModel);
        //     if (response.IsSuccessStatusCode)
        //     {
        //         locationUp = JsonConvert.DeserializeObject<LocationModel>(await response.Content.ReadAsStringAsync());
        //     }
        //     return locationUp;
        // }
        #endregion
    }
}
