using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using fgcias.domain.clsAuditTrail;

namespace fgcias.domain.clsLocation
{
    public class LocationModel : AuditTrailModel
  { 
        public LocationModel()
        {
            Id = 0;
            IsActive = true;
            Name = "";
        }
        public Int64 Id {get; set;}
        public string Name { get; set; }
        public bool IsActive {get; set;}
  }
}
