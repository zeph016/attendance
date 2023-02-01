using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using fgcias.domain.clsLocation;
using fgcias.domain.clsFilterParameter;

namespace fgcias.service.LocationServices
{
    public interface ILocationService
    {
        Task<List<LocationModel>> GetLocations(FilterParameter filterParameter, string token);
        Task<LocationModel> GetLocationById(Int64 locationId, string token);
        Task<LocationModel> AddLocationName(LocationModel locationAddModel, string token);
        Task<LocationModel> UpdateLocationName(LocationModel locationUpdateModel, string token);
    }
}
