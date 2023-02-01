using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fgcias.domain.clsSignatories
{
    public class EmployeeModel
    {
        public EmployeeModel()
        {
          IsLookup = true;
          IsName = true;
          Name = "";
        }
        public int EmployeeId {get;set;}
        public bool IsLookup { get; set; }
        public bool IsName { get; set; } 
        public string Name { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string MiddleName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string NameExtension { get; set; }
        public string Designation { get; set; }
        public string DepartmentName { get; set; }
        public string SectionName { get; set; }
        public string IdNumber { get; set; }
        public DateTime Birthday { get; set; }
        public string CompanyName { get; set; }
        public string StatusName { get; set; }
        public DateTime DateHired { get; set; }
        public string Address { get; set; }
        public byte[] Picture { get; set; }
        public string EmployeeName
        {
            get
            {
                var _employeename = "";
                if (!string.IsNullOrEmpty(NameExtension))
                    _employeename = FirstName + " " + LastName + " " + NameExtension;
                else
                    _employeename = FirstName + " " + LastName;
                return _employeename;
            }
        }
    }
}
