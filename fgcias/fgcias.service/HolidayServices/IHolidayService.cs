using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using fgcias.domain.clsHoliday;
// using fgcias.domain.clsFilterParameter;

namespace fgcias.service.HolidayServices
{
    public interface IHolidayService
    {
        Task<List<HolidayModel>> GetHolidays(long year, string token);
     
        Task<HolidayModel> AddHoliday(HolidayModel holidayModel, string token);

        Task<HolidayModel> UpdateHolidayById(HolidayModel holidayModel, string token);
    }
}
