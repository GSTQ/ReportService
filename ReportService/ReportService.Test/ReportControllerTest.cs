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
            var expectedData = "Январь 2017\r\n--------------------------------------------\r\nФинОтдел\r\nАндрей Сергеевич Бубнов         70000р\r\nГригорий Евсеевич Зиновьев         65000р\r\nЯков Михайлович Свердлов         80000р\r\nАлексей Иванович Рыков         90000р\r\nВсего по отделу 305000р\r\n--------------------------------------------\r\nБухгалтерия\r\nВасилий Васильевич Кузнецов         50000р\r\nДемьян Сергеевич Коротченко         55000р\r\nМихаил Андреевич Суслов         35000р\r\nВсего по отделу 140000р\r\n--------------------------------------------\r\nИТ\r\nФрол Романович Козлов         90000р\r\nДмитрий Степанович Полянски         120000р\r\nАндрей Павлович Кириленко         110000р\r\nАрвид Янович Пельше         120000р\r\nВсего по отделу 440000р\r\n--------------------------------------------\r\nВсего по предприятию 885000р";

            Assert.Equal(expectedData, data);
        }
    }
}
