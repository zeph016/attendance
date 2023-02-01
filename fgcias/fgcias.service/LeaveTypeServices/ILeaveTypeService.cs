using fgcias.domain.clsFilterParameter;
using fgcias.domain.clsLeaveTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fgcias.service.LeaveTypeServices
{
    public interface ILeaveTypeService
    {
        Task<List<LeaveTypesModel>> GetLeaveType(FilterParameter filterParameter, string token);
        Task<LeaveTypesModel> AddleaveType(LeaveTypesModel leaveTypeAddModel, string token);
        Task<LeaveTypesModel> UpdateleaveType(LeaveTypesModel leaveTypeUpdateModel, string token);
    }
}
