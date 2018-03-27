using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportService.Domain
{
    public class Report
    {
        public String Data { get; set; }

        public void Build(int year, int month, Employee[] employees, String[] departments)
        {
            this.AddHeader(MonthNameResolver.MonthName.GetName(year, month), year);

            foreach (var department in departments)
            {
                var employeeList = employees
                    .Where(_ => _.Department == department)
                    .ToArray();

                this.AddNewLine();
                this.AddHorizontalLine();
                this.AddNewLine();
                this.AddDepartment(department);

                foreach (var employee in employeeList)
                {
                    this.AddNewLine();
                    this.AddEmployeeName(employee);
                    this.AddTab();
                    this.AddSalary(employee);
                }

                this.AddNewLine();
                this.AddTotalByDepartment(employeeList.Sum(_ => _.Salary));
            }

            this.AddNewLine();
            this.AddHorizontalLine();
            this.AddNewLine();
            this.AddTotalByCompany(employees.Sum(_ => _.Salary));
        }

        public byte[] GetBinary()
        {
            return Encoding.UTF8.GetBytes(Data);
        }

        public async Task Save(string path)
        {
            using (var outputStream = File.CreateText(path))
            {
                await outputStream.WriteAsync(Data);
            };
        }
    }
}
