using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using fgcias.domain.clsAuditTrail;
using fgcias.domain.clsLocation;

namespace fgcias.domain.clsSchedule
{
    public class ScheduleModel
    {
        public Int64 id { get; set;}
        public string Name { get; set; } = String.Empty;
        public string TimeInAm { get; set; } = String.Empty;
        public string TimeOutAm { get; set; } = String.Empty;
        public string TimeInPm { get; set; } = String.Empty;
        public string TimeOutPm { get; set; } = String.Empty;
        public string OvertimePmStart { get; set; } = String.Empty;
        public bool HasOvertimeAm { get; set; }
        public string OvertimeAmStart { get; set; } = String.Empty;
        public int GracePeriod { get; set; }
        public bool HasOffsetSchedule { get; set; }
        public string OffsetTimeIn { get; set; } = String.Empty;
        public string OffsetTimeOut { get; set; } = String.Empty;
        public bool HasHalfRestDay { get; set; }
        public int Location { get; set; }
        public string LocationName { get; set; } = String.Empty;
        public List<string> RestDay { get; set; } = new List<string>();
        public List<ScheduleBreakModel> ScheduleBreaks { get; set; } = new List<ScheduleBreakModel>();
        public List<LocationModel> LocationList { get; set; } = new List<LocationModel>();
        public bool isActive { get; set; }
        
    }
}
