using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using fgcias.domain.clsEnums;

namespace fgcias.domain.clsUserAccount
{
    public class UserAccountModel
    {
        public UserAccountModel()
        {
            SystemName = "FGCIHub";
        }
        public UserAccountModel(UserAccountModel userAccount)
        {
            EmployeeId = userAccount.EmployeeId;
            FirstName = userAccount.FirstName;
            MiddleName = userAccount.MiddleName;
            LastName = userAccount.LastName;
            NameExtension = userAccount.NameExtension;
            Token = userAccount.Token;
        }
        public Int64 EmployeeId { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string MiddleName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string NameExtension { get; set; } = string.Empty;
        public string Designation { get; set; } = string.Empty;
        public string DepartmentName { get; set; } = string.Empty;
        public string SectionName { get; set; } = string.Empty;
        public string IdNumber { get; set; } = string.Empty;
        public DateTime Birthday { get; set; }
        public string CompanyName { get; set; } = string.Empty;
        public string StatusName { get; set; } = string.Empty;
        public DateTime DateHired { get; set; } 
        public string Address { get; set; } = string.Empty;
        public byte[] Picture { get; set; } = new byte[]{};
        public string EmployeeName
        {
            get
            {
                var _middlename = "";
                if (!String.IsNullOrEmpty(MiddleName))
                    _middlename = " " + MiddleName.Substring(0, 1) + ".";

                return LastName + ", " + FirstName + _middlename; ;
            }
            set{ }
        }
        public string UserName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string SystemName { get; set; } = string.Empty;
        public string Token { get; set; } = string.Empty;
        public System.Net.HttpStatusCode httpResponse { get; set; }
        public string httpResponseMesg { get; set; } = string.Empty;
        public Enums.AttendanceAccessLevel AccessLevel { get; set; }    
    }
}