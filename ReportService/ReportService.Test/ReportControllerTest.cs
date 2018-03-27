using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ReportService.Controllers;
using Xunit;

namespace ReportService.Test
{
    public class ReportControllerTest
    {
        [Fact]
        public async Task TestDownload()
        {
            var dbDataLoader = new MockDBDataLoader();
            var controller = new ReportController(dbDataLoader);
            var result = await controller.Download(2017, 1);
            var content = result as FileContentResult;

            Assert.NotNull(result);
            Assert.NotNull(content);
            Assert.Equal("application/octet-stream", content.ContentType);
            Assert.Equal("report.txt", content.FileDownloadName);
            Assert.NotNull(content.FileContents);
            Assert.Equal(1122, content.FileContents.Length);

            var data = Encoding.UTF8.GetString(content.FileContents, 0, content.FileContents.Length);
            var expectedData = "������ 2017\r\n--------------------------------------------\r\n��������\r\n������ ��������� ������         70000�\r\n�������� �������� ��������         65000�\r\n���� ���������� ��������         80000�\r\n������� �������� �����         90000�\r\n����� �� ������ 305000�\r\n--------------------------------------------\r\n�����������\r\n������� ���������� ��������         50000�\r\n������ ��������� ����������         55000�\r\n������ ��������� ������         35000�\r\n����� �� ������ 140000�\r\n--------------------------------------------\r\n��\r\n���� ��������� ������         90000�\r\n������� ���������� ��������         120000�\r\n������ �������� ���������         110000�\r\n����� ������ ������         120000�\r\n����� �� ������ 440000�\r\n--------------------------------------------\r\n����� �� ����������� 885000�";

            Assert.Equal(expectedData, data);
        }
    }
}
