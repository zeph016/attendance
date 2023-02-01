using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fgcias.domain.clsAuditTrail
{
    public class AuditTrailModel
    {
        public AuditTrailModel() { }
        public AuditTrailModel(AuditTrailModel trail)
        {
            this.Id = trail.Id;
            this.IsActive = trail.IsActive;
            this.CreatedById = trail.CreatedById;
            this.ModifiedById = trail.ModifiedById;
            this.DateCreated = trail.DateCreated;
            this.DateModified = trail.DateModified;
            this.Version = trail.Version;
        }

        public long Id { get; set; }
        public bool IsActive { get; set; }
        public long CreatedById { get; set; }
        public Nullable<long> ModifiedById { get; set; }
        public DateTime DateCreated { get; set; }
        public Nullable<DateTime> DateModified { get; set; }
        public byte[] Version { get; set; }
    }
}
