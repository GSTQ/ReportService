using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ReportService.Domain;

namespace ReportService.SalaryLoader
{
    public class WebSalaryLoader : ISalaryLoader
    {
        public async Task<int> GetSalaryAsync(Employee employee)
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create($"{_url}/{employee.Inn}");
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";

            var buhCodeInJson = JsonConvert.SerializeObject(new { employee.BuhCode });

            await WriteBody(httpWebRequest, buhCodeInJson);

            var httpResponse = await httpWebRequest.GetResponseAsync();
            var response = await ReadResponse(httpResponse);
            return (int)Decimal.Parse(response);
        }

        private Task<String> ReadResponse(WebResponse httpResponse)
        {
            using (var reader = new StreamReader(httpResponse.GetResponseStream(), true))
            {
                var response = reader.ReadToEndAsync();
                return response;
            }
        }

        private async Task WriteBody(HttpWebRequest httpWebRequest, string content)
        {
            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                await streamWriter.WriteAsync(content);
                await streamWriter.FlushAsync();
                streamWriter.Close();
            }
        }

        private string _url = "http://salary.local/api/empcode";
    }
}
