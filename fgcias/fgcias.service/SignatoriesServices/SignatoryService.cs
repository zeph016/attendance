using fgcias.domain.clsFilterParameter;
using fgcias.domain.clsSignatories;
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace fgcias.service.SignatoriesServices
{
    public class SignatoryService : ISignatoryService
    {

        private readonly HttpClient client;
        public SignatoryService(HttpClient _client) => client = _client;
        
        #region Get DepartmentID
        public Task<SignatoryModel> GetDepartmentById(long departmentId, string token)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Get AddSignatory
        public async Task<EmployeeModel> AddSignatory(EmployeeModel leaveTypeAddModel, string token)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
