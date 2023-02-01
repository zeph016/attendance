using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using fgcias.domain.clsAuditTrail;
using fgcias.domain.clsEnums;
using fgcias.domain.clsLocation;

namespace fgcias.domain.clsHoliday
{
    public class HolidayModel:AuditTrailModel
    {
        public HolidayModel()
        {
            ListofLocations = new List<LocationModel>();
        }
        public DateTime? SelectedDate { get; set; }
        public Enums.HolidayType Type { get; set; }
        public List<long> Locations { get; set; } = new List<long>();
        public string Name { get; set; } = String.Empty;
        public string LocationNames { get; set; }
        public List<LocationModel> ListofLocations { get; set; }

    }
}
