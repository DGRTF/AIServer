using AIServer.Controllers;
using Microsoft.AspNetCore.Http;
using NUnit.Framework;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace AIServerUnitTests
{
    [TestFixture]
    public class AiNumberControllerTests
    {

        [Test]
        public void DefineNumber_Image_SingleNumber()
        {
            var aiNumber = new AiNumberController();
            aiNumber.DefineNumber(new FileImplTest());

        }
    }

    class FileImplTest : IFormFile
    {
        public string ContentType { get; }
        public string ContentDisposition { get; }
        public IHeaderDictionary Headers { get; }
        public long Length { get; }
        public string Name { get; }
        public string FileName { get; }
        public void CopyTo(Stream target) { }
        public Task CopyToAsync(Stream target, CancellationToken cancellationToken = default) { return new Task(() => { }); }
        public Stream OpenReadStream() 
        {
            var image = new Bitmap(28, 28);

            for (int y = 0; y < image.Height; y++)
                for (int x = 0; x < image.Width; x++)
                {
                    var newPixel = Color.FromArgb(y + 1, x + 1, x + y);
                    image.SetPixel(x, y, newPixel);
                }

            var stream = new MemoryStream();

            image.Save(stream, ImageFormat.Jpeg);
            return stream;
        }
    }
}
