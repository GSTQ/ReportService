using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ReportService.DBDataLoader;
using ReportService.Domain;

namespace ReportService.Controllers
{
    [Route("api/[controller]")]
    public class ReportController : Controller
    {
        public ReportController(IDBDataLoader dbDataLoader)
        {
            _dbDataLoader = dbDataLoader;
        }

        [HttpGet]
        [Route("{year}/{month}")]
        public async Task<IActionResult> Download(int year, int month)
        { 
            var employees = await _dbDataLoader.GetEmployeesAsync().ConfigureAwait(false);
            var departments = await _dbDataLoader.GetDepartmentsAsync().ConfigureAwait(false);

            var report = new Report();
            report.Build(year, month, employees.ToArray(), departments.ToArray());

            return File(report.GetBinary(), "application/octet-stream", "report.txt");
        }

        private readonly IDBDataLoader _dbDataLoader;
    }
}
