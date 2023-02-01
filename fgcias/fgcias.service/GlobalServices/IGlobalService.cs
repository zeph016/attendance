using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using fgcias.domain.clsFilterParameter;
using fgcias.domain.clsSignatories;

namespace fgcias.service.GlobalServices
{
    public interface IGlobalService
    {
        Task<List<DepartmentModel>> GetDepartments(FilterParameter filterParameter, string token);
        Task<List<SectionModel>> GetSections(FilterParameter filterParameter, string token);
        Task<List<EmployeeModel>> GetEmployees(FilterParameter filterParameter, string token);
    }
}