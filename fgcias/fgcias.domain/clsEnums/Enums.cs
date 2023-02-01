using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace fgcias.domain.clsEnums
{
    public class Enums
    {
        public enum CrudeMode : byte
        {
            [Description("Add")]
            Add = 0,
            [Description("Edit")]
            Edit = 1,
            [Description("Delete")]
            Delete = 2,
            [Description("Voided")]
            Void = 3
        }

        public enum AttendanceAccessLevel
        {
            [Description("Administrator")]
            Administrator = 0,
            [Description("Regular")]
            AccountingAdmin = 1,
            [Description("Department Head")]
            AccountingRequestor = 2,
            [Description("Attendance In-Charge")]
            AccountingIssuer = 3,
            [Description("HR Officer")]
            AccountingViewer = 4,
            [Description("Audit Officer")]
            OthersRequestor = 5
        }
        public enum HolidayType
        {
            [Description("Regular")] 
            Regular = 0,
            [Description("Special")]
            Special = 1
        }
        public enum AccessLevel : byte
        {
            [Description("Administrator")]
            Administrator = 0,
            [Description("IT")]
            IT = 1,
            [Description("Employee")]
            Client = 2,
        }
    }
}