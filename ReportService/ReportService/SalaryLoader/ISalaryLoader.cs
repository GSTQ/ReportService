using ReportService.Domain;
using System;
using System.Threading.Tasks;

namespace ReportService.SalaryLoader
{
    public interface ISalaryLoader
    {
        Task<Int32> GetSalaryAsync(Employee employee);
    }
}
