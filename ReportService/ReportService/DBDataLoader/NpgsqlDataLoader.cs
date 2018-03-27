using Npgsql;
using ReportService.BuhCodeLoader;
using ReportService.Domain;
using ReportService.SalaryLoader;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ReportService.DBDataLoader
{
    public class NpgsqlDataLoader : IDBDataLoader
    {
        public NpgsqlDataLoader(ISalaryLoader salaryLoader, IBuhCodeLoader buhCodeLoader)
        {
            _salaryLoader = salaryLoader;
            _buhCodeLoader = buhCodeLoader;
        }

        public async Task<IEnumerable<String>> GetDepartmentsAsync()
        {
            var departments = new List<String>();
            using (var connection = new NpgsqlConnection(_connString))
            {
                await connection.OpenAsync();

                var cmd = new NpgsqlCommand("SELECT d.name from deps d where d.active = true", connection);
                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        departments.Add(reader.GetString(0));
                    }
                }
            }
            return departments;
        }

        public async Task<IEnumerable<Employee>> GetEmployeesAsync()
        {
            var employees = new List<Employee>();
            using (var connection = new NpgsqlConnection(_connString))
            {
                await connection.OpenAsync();

                var command = new NpgsqlCommand(@"
                    SELECT 
                        e.name,
                        e.inn,
                        d.name 
                    from emps e 
                    left join deps d on e.departmentid = d.id", connection);

                using (var reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        var employee = new Employee()
                        {
                            Name = reader.GetString(0),
                            Inn = reader.GetString(1),
                            Department = reader.GetString(2)
                        };
                        employee.BuhCode = await _buhCodeLoader.GetBuhCodeAsync(employee.Inn).ConfigureAwait(false);
                        employee.Salary = await _salaryLoader.GetSalaryAsync(employee).ConfigureAwait(false);
                        employees.Add(employee);
                    }
                }
            }
            return employees;
        }

        private readonly ISalaryLoader _salaryLoader;
        private readonly IBuhCodeLoader _buhCodeLoader;

        private static string _connString = "Host=192.168.99.100;Username=postgres;Password=1;Database=employee";
    }
}
