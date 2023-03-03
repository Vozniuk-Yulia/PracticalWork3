using Microsoft.VisualBasic.FileIO;
using System;
using System.Drawing;

namespace Task3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] paths =
            {
                @"E:\knute\oop\laboratory9\PracticalWork3\Task3\images\photo1.jpg",
                @"E:\knute\oop\laboratory9\PracticalWork3\Task3\images\photo2.jpg"
            };
            Func<Bitmap, Bitmap>[] operations =
            {
                InvertImg,
                ScaleImg
            };
            Action<Bitmap> showImage = ShowImage;
            Bitmap[] images = new Bitmap[paths.Length];
            for (int i = 0; i < paths.Length; i++)
            {
                images[i] = new Bitmap(paths[i]);
            }
            for (int i = 0; i < images.Length; i++)
            {
                foreach (var operation in operations)
                {
                    Bitmap processedImage = operation(images[i]);
                    showImage(processedImage);
                }
            }
        }
        static Bitmap InvertImg(Bitmap image)
        {
            Bitmap temp = image;
            Bitmap bmap = (Bitmap)temp.Clone();
            Color c;
            for (int i = 0; i < bmap.Width; i++)
            {
                for (int j = 0; j < bmap.Height; j++)
                {
                    c = bmap.GetPixel(i, j);
                    bmap.SetPixel(i, j, Color.FromArgb(255 - c.R, 255 - c.G, 255 - c.B));
                }
            }
            image = (Bitmap)bmap.Clone();
            return image;
        }
        static Bitmap ScaleImg(Bitmap image)
        {
            int maxWidth = 5000;
            int maxHeight = 200;
            var ratioX = (double)maxWidth / image.Width;
            var ratioY = (double)maxHeight / image.Height;
            var ratio = Math.Min(ratioX, ratioY);

            var newWidth = (int)(image.Width * ratio);
            var newHeight = (int)(image.Height * ratio);

            var newImage = new Bitmap(newWidth, newHeight);

            using (var graphics = Graphics.FromImage(newImage))
            {
                graphics.DrawImage(image, 0, 0, newWidth, newHeight);

            }
            return newImage;
        }
        static void ShowImage(Bitmap image)
        {
            image.Save("newimage.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
            Console.WriteLine("Image saved.");
            Console.WriteLine("Image displayed.");
        }
    }
}