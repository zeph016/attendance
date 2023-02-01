using fgcias.domain.clsFilterParameter;
using fgcias.domain.clsSignatories;
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace fgcias.service.GlobalServices
{
    public class GlobalService : IGlobalService
    {
      private readonly HttpClient client;

      public GlobalService(HttpClient _client) => client = _client;

      #region Get Departments
      public async Task<List<DepartmentModel>> GetDepartments(FilterParameter filterParameter, string token)
      {
          List<DepartmentModel> department = new List<DepartmentModel>();
          client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
          HttpResponseMessage responseMessage = await client.GetAsync("/masterlist/employees/departments");
          if (responseMessage.IsSuccessStatusCode)
              department = await responseMessage.Content.ReadAsAsync<List<DepartmentModel>>();
          return department;
      }
      #endregion

      #region Get Sections
      public async Task<List<SectionModel>> GetSections(FilterParameter filterParameter, string token)
      {
          List<SectionModel> section = new List<SectionModel>();
          client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
          HttpResponseMessage responseMessage = await client.GetAsync("/masterlist/sections/");
          if (responseMessage.IsSuccessStatusCode)
              section = await responseMessage.Content.ReadAsAsync<List<SectionModel>>();
          return section;
      }
      #endregion

      #region Get Employees
      public async Task<List<EmployeeModel>> GetEmployees(FilterParameter filterParameter, string token)
      {
          try
          {
              List<EmployeeModel> userAccounts = new List<EmployeeModel>();
              client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
              HttpResponseMessage response = await client.PostAsJsonAsync("masterlist/employees/fgciemployees", filterParameter);
              if (response.IsSuccessStatusCode)
              {
                  userAccounts = await response.Content.ReadAsAsync<List<EmployeeModel>>();
              }
              return userAccounts.OrderBy(x => x.Name).ToList();
          }
          catch (Exception ex)
          {
              return null;
          }
      }
      #endregion

    }
}