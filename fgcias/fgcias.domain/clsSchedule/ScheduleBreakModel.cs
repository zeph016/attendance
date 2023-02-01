using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fgcias.domain.clsSchedule
{
    public class ScheduleBreakModel
    {
        public Int64 Id { get; set; }
        public string TimeStart { get; set; } = String.Empty;
        public string TimeEnd { get; set; } = String.Empty;
        public long ScheduleId { get; set; }
        public bool isActive { get; set; }

        public TimeSpan? StartBreak {get; set;}
        public TimeSpan? EndBreak {get; set; }
        
    }
}
