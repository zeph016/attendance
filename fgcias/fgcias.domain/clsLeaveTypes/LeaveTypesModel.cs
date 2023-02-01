using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using fgcias.domain.clsAuditTrail;

namespace fgcias.domain.clsLeaveTypes
{
    public class LeaveTypesModel
    {
        // public LeaveTypesModel(AuditTrailModel trail)
        // {
        //     Id = 0;
        //     IsActive = true;
        //     Name = "";
        //     Description = "";
        // }
        public Int64 Id { get; set; }
        public bool IsActive { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
