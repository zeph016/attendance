using fgcias.domain.clsSchedule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fgcias.service.ScheduleServices
{
    public interface IScheduleService
    {
        Task<List<ScheduleModel>> GetSchedules(bool isActive, string token);
        Task<ScheduleModel> AddSchedule(ScheduleModel scheduleModel, string token);
        Task<ScheduleModel> UpdateSchedule(ScheduleModel scheduleModel, string token);
    }
}
