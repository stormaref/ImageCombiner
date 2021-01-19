using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Net;
using System.Linq;

namespace ImageCombiner
{
    class Program
    {
        static void Main(string[] args)
        {
            WebClient wc = new WebClient();
            List<string> vs = new List<string> {
                "https://m.media-amazon.com/images/M/MV5BMTk3NGQ4NjMtZTU1Mi00MTJjLTllMjUtOTNlN2I3NzU5ZjE1XkEyXkFqcGdeQXVyNTkyMjQwNw@@",
                "https://m.media-amazon.com/images/M/MV5BZTU1N2VhNjctZWVjMy00MDMwLTg4MDMtMjRjMDM2NDFlMzM4XkEyXkFqcGdeQXVyNzExNDQ2NDM@"
            };
            var images = vs.Select(s => ResizeImage(Image.FromStream(new MemoryStream(wc.DownloadData(s))),1000)).ToList();
            var width = 0;
            foreach (var item in images)
            {
                width += item.Width;
            }
            var bitmapImage = new Bitmap(width, 1000);
            using (Graphics g = Graphics.FromImage(bitmapImage))
            {
                g.DrawImage(img1, 0, 0);
                g.DrawImage(img2, img1.Width, 0);
                bitmapImage.Save("mammad.jpg", ImageFormat.Jpeg);
            }
        }
        public static Image ScaleImage(Image image, int maxWidth, int maxHeight)
        {
            var ratioX = (double)maxWidth / image.Width;
            var ratioY = (double)maxHeight / image.Height;
            var ratio = Math.Min(ratioX, ratioY);

            var newWidth = (int)(image.Width * ratio);
            var newHeight = (int)(image.Height * ratio);

            var newImage = new Bitmap(newWidth, newHeight);

            using (var graphics = Graphics.FromImage(newImage))
                graphics.DrawImage(image, 0, 0, newWidth, newHeight);

            return newImage;
        }

        public static Image ResizeImage(Image image, int height)
        {
            int width = (int)(height * 0.675);
            var newImage = new Bitmap(width, height);

            using (var graphics = Graphics.FromImage(newImage))
                graphics.DrawImage(image, 0, 0, width, height);

            return newImage;
        }

    }
}
