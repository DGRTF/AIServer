using System;
using System.Collections.Generic;
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

        public List<float> InputData { get; private set; } = new List<float>();

        void Init(Stream stream)
        {
            var image = new Bitmap(stream);
            var resultImage = new Bitmap(image, 28, 28);
            for (int y = 0; y < resultImage.Height; y++)
                for (int x = 0; x < resultImage.Width; x++)
                {
                    // получаем (x, y) пиксель
                    UInt32 pixel = (UInt32)(resultImage.GetPixel(x, y).ToArgb());
                    // получаем компоненты цветов пикселя
                    float R = (float)((pixel & 0x00FF0000) >> 16); // красный
                    float G = (float)((pixel & 0x0000FF00) >> 8); // зеленый
                    float B = (float)(pixel & 0x000000FF); // синий
                    // делаем цвет черно-белым (оттенки серого) - находим среднее арифметическое
                    R = G = B = (R + G + B) / 3.0f;
                    // собираем новый пиксель по частям (по каналам)
                    UInt32 newPixel = 0xFF000000 | ((UInt32)R << 16) | ((UInt32)G << 8) | ((UInt32)B);
                    // добавляем его в Bitmap нового изображения
                    resultImage.SetPixel(x, y, Color.FromArgb((int)newPixel));

                    //int item = (y + 1) * (x + 1) - 1;
                    var r = resultImage.GetPixel(x, y).R;
                    InputData.Add(r);
                }

            resultImage.Save("C:/Users/User/Desktop/bwimg.jpg");
            var img = new Bitmap(image, 28, 28);
            //for (int y = 0; y < img.Height; y++)
            //    for (int x = 0; x < img.Width; x++)
            //    {
            //        int item = (y + 1) * (x + 1) - 1;
            //        var pixel = Color.FromArgb((int)InputData[item], (int)InputData[item], (int)InputData[item]);
            //        img.SetPixel(x, y, pixel);
            //    }

            int xx = 0;
            int yy = 0;
            foreach (var n in InputData)
            {
                var pixel = Color.FromArgb((int)n, (int)n, (int)n);
                img.SetPixel(xx, yy, pixel);
                if (xx < img.Height - 1)
                    xx++;
                else
                {
                    yy++;
                    xx = 0;
                }
            }

            img.Save("C:/Users/User/Desktop/bwi.jpg");
        }
    }
}
