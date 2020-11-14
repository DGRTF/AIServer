using AIServer.DataHandlers;
using NUnit.Framework;
using System.Drawing;

namespace AIServerUnitTests
{
    [TestFixture]
    class ImageHandlerTest
    {
        [Test]
        public void ImageHandler_ImageHandlerCreate_InputDataPropertyHaveAveragePixelsToRGB()
        {
            var image = new Bitmap(28, 28);

            for (int y = 0; y < image.Height; y++)
                for (int x = 0; x < image.Width; x++)
                {
                    var newPixel = Color.FromArgb(y + 1, x + 1, x + y);
                    image.SetPixel(x, y, newPixel);
                }

            var imageHandler = new ImageHandler(image);

            Assert.AreEqual(imageHandler.InputData.Length, 784);
        }
    }
}
