using System;
using System.Collections.Generic;
using System.Linq;
using fgcias.domain.clsUserAccount;
using fgcias.domain.clsHoliday;
using fgcias.domain.clsLocation;
using fgcias.domain.clsSchedule;
using fgcias.domain.clsSignatories;

namespace fgcias.Common
{
    public static class GlobalClass
    {
        public static string token { get; set; } = string.Empty;
        public static long currentYear = DateTime.Now.Year;
        public static DateTime? currentDate = DateTime.Now;
        public static string pageTitle { get; set; } = string.Empty;
        public static UserAccountModel currentUserAccount { get; set; } = new UserAccountModel(); 
    }
    public static class GlobalClassList
    {
        public static List<HolidayModel> globalHolidayList = new List<HolidayModel>();
        public static List<LocationModel> globalLocationList = new List<LocationModel>();
        public static List<ScheduleModel> globalScheduleList = new List<ScheduleModel>();
        public static List<ScheduleBreakModel> globalSchedulBreakList = new List<ScheduleBreakModel>();
        public static List<SignatoryModel> globalSignatoryList = new List<SignatoryModel>();
        public static List<SectionModel> globalSectionList = new List<SectionModel>();
        public static List<DepartmentModel> globalDepartmentList = new List<DepartmentModel>();
        public static List<EmployeeModel> globalEmployeeList = new List<EmployeeModel>();

    }
}