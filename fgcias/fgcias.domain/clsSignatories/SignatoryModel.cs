using fgcias.domain.clsAuditTrail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fgcias.domain.clsSignatories
{
    public class SignatoryModel : AuditTrail
    {

        public SignatoryModel()
        {
            SectionId = 0;
            BiometricAccountId = 0; 
            TwoDayPriority = 0; 
            ThreeDayPriority = 0;
            OvertimePriority = 0;
            IsOverallPriority = true;
        }


        public long SectionId { get; set; }
        public long BiometricAccountId { get; set; }
        public int TwoDayPriority { get; set; }
        public int ThreeDayPriority { get; set; }
        public int OvertimePriority { get; set; }
        public bool IsOverallPriority { get; set; }

    }
}
