using fgcias.domain.clsSignatories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using fgcias.domain.clsFilterParameter;

namespace fgcias.service.SignatoriesServices
{
    public interface ISignatoryService
    {
        Task<SignatoryModel> GetDepartmentById(Int64 departmentId, string token);
        Task<EmployeeModel> AddSignatory(EmployeeModel leaveTypeAddModel, string token);
    }
}
