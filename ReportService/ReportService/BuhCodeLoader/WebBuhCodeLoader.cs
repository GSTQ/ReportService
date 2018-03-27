using System.Net.Http;
using System.Threading.Tasks;

namespace ReportService.BuhCodeLoader
{
    public class WebBuhCodeLoader : IBuhCodeLoader
    {
        public async Task<string> GetBuhCodeAsync(string inn)
        {
            var client = new HttpClient();
            return await client.GetStringAsync($"http://buh.local/api/inn/{inn}");
        }
    }
}
