using ReportService.DBDataLoader;
using ReportService.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ReportService.Test
{
    public class MockDBDataLoader : IDBDataLoader
    {
        public async Task<IEnumerable<String>> GetDepartmentsAsync()
        {
            var departments = new List<string>()
            {
                "ФинОтдел",
                "Бухгалтерия",
                "ИТ"
            };
            return await Task.FromResult(departments);
        }

        public async Task<IEnumerable<Employee>> GetEmployeesAsync()
        {
            var employees = new List<Employee>()
            {
                new Employee()
                {
                    Name = "Андрей Сергеевич Бубнов",
                    Department = "ФинОтдел",
                    Salary = 70000
                },
                new Employee()
                {
                    Name = "Григорий Евсеевич Зиновьев",
                    Department = "ФинОтдел",
                    Salary = 65000
                },
                new Employee()
                {
                    Name = "Яков Михайлович Свердлов",
                    Department = "ФинОтдел",
                    Salary = 80000
                },
                new Employee()
                {
                    Name = "Алексей Иванович Рыков",
                    Department = "ФинОтдел",
                    Salary =  90000
                },
                new Employee()
                {
                    Name = "Василий Васильевич Кузнецов",
                    Department = "Бухгалтерия",
                    Salary = 50000
                },
                new Employee()
                {
                    Name = "Демьян Сергеевич Коротченко",
                    Department = "Бухгалтерия",
                    Salary = 55000
                },
                new Employee()
                {
                    Name = "Михаил Андреевич Суслов",
                    Department = "Бухгалтерия",
                    Salary = 35000
                },
                new Employee()
                {
                    Name = "Фрол Романович Козлов",
                    Department = "ИТ",
                    Salary = 90000
                },
                new Employee()
                {
                    Name = "Дмитрий Степанович Полянски",
                    Department = "ИТ",
                    Salary = 120000
                },
                new Employee()
                {
                    Name = "Андрей Павлович Кириленко",
                    Department = "ИТ",
                    Salary = 110000
                },
                new Employee()
                {
                    Name = "Арвид Янович Пельше",
                    Department = "ИТ",
                    Salary = 120000
                },

            };

            return await Task.FromResult(employees);

        }
    }
}
