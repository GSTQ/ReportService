using System.Threading.Tasks;

namespace ReportService.BuhCodeLoader
{
    public interface IBuhCodeLoader
    {
        Task<string> GetBuhCodeAsync(string inn);
    }
}
