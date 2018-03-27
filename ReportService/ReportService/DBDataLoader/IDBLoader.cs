using ReportService.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ReportService.DBDataLoader
{
    public interface IDBDataLoader
    {
        Task<IEnumerable<String>> GetDepartmentsAsync();
        Task<IEnumerable<Employee>> GetEmployeesAsync();
    }
}
