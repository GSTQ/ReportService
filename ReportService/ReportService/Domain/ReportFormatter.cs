using System;

namespace ReportService.Domain
{
    public static class ReportFormatter
    {
        public static void AddNewLine(this Report report)
        {
            report.Data = report.Data + Environment.NewLine;
        }

        public static void AddHorizontalLine(this Report report)
        {
            report.Data = report.Data + "--------------------------------------------";
        }

        public static void AddTab(this Report report)
        {
            report.Data = report.Data = report.Data + "         ";
        }

        public static void AddHeader(this Report report, string month, int year)
        {
            report.Data = report.Data + $"{month} {year}";
        }

        public static void AddEmployeeName(this Report report, Employee employee)
        {
            report.Data = report.Data + employee.Name;
        }

        public static void AddSalary(this Report report, Employee employee)
        {
            report.Data = report.Data + $"{employee.Salary}р";
        }

        public static void AddDepartment(this Report report, string department)
        {
            report.Data = report.Data + department;
        }

        public static void AddTotalByDepartment(this Report report, int total)
        {
            report.Data = report.Data + $"Всего по отделу {total}р";
        }

        public static void AddTotalByCompany(this Report report, int total)
        {
            report.Data = report.Data + $"Всего по предприятию {total}р";
        }
    }
}
