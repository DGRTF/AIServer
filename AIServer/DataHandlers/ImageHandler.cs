using System.Drawing;
using System.IO;

namespace AIServer.DataHandlers
{
    public class ImageHandler
    {
        public ImageHandler(Stream stream)
        {
            Init(stream);
        }

        public float[] InputData { get; private set; } = new float[784];

        void Init(Stream stream)
        {
            var image = new Bitmap(stream);
            var resultImage = new Bitmap(image, 28, 28);

            int count = 0;
            for (int y = 0; y < resultImage.Height; y++)
                for (int x = 0; x < resultImage.Width; x++)
                {
                    var currentPixel = resultImage.GetPixel(x, y);

                    int r = currentPixel.R;
                    int g = currentPixel.G;
                    int b = currentPixel.B;

                    r = g = b = (r + g + b) / 3;

                    var newPixel = Color.FromArgb(r, g, b);

                    resultImage.SetPixel(x, y, newPixel);
                    InputData[count] = r;
                    count++;
                }
        }
    }
}
