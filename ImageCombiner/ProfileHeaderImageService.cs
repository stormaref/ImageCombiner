using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Net;
using System.Linq;

namespace ImageCombiner
{
    public class ProfileHeaderImageService
    {
        public ProfileHeaderImageService()
        {
        }

        private const double ratio = 0.675;
        private const double headerRatio = 1.925;
        private int width;
        private int imagesInRow;
        private int height;

        public void GenerateHeaderImage(WebClient wc, List<string> urls, string filePath)
        {
            imagesInRow = GetImagesInRowCount(urls.Count, headerRatio);
            var images = urls.Select(s => ResizeImage(Image.FromStream(new MemoryStream(GetImageBytes(wc,s))), height, ratio)).ToList();
            CreateImage(filePath, images, 2000);
        }

        private byte[] GetImageBytes(WebClient wc,string url)
        {
            //todo read image from rediscache
            return wc.DownloadData(url);
        }
        
        private void CreateImage(string filePath, List<Image> images,int headerImageHeight)
        {
            int forMax = images.Count % imagesInRow == 0 ? images.Count / imagesInRow : images.Count / imagesInRow + 1;
            var bitmapImage = new Bitmap(imagesInRow * width, forMax * height);
            for (int i = 0; i < forMax; i++)
            {
                for (int j = 0; j < imagesInRow; j++)
                {
                    using (Graphics g = Graphics.FromImage(bitmapImage))
                    {
                        int index = imagesInRow * i + j;
                        try
                        {
                            Image image = images[index];
                            g.DrawImage(image, j * width, i * height);
                        }
                        catch (ArgumentOutOfRangeException ex)
                        {
                            //its ok
                        }
                    }
                }
            }
            var newImage = ResizeImage(bitmapImage, headerImageHeight, headerRatio);
            newImage.Save(filePath, ImageFormat.Jpeg);
        }

        private Image ScaleImage(Image image, int maxWidth, int maxHeight)
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

        private Image ResizeImage(Image image, int height, double ratio)
        {
            int width = (int)(height * ratio);
            var newImage = new Bitmap(width, height);

            using (var graphics = Graphics.FromImage(newImage))
                graphics.DrawImage(image, 0, 0, width, height);

            return newImage;
        }

        private int GetImagesInRowCount(int c, double r)
        {
            height = 550;
            var min = Calculate(700, c, r, false);
            for (int i = 560; i < 1100; i += 10)
            {
                var calculated = Calculate(i, c, r, false);
                if (calculated < min)
                {
                    min = calculated;
                    height = i;
                }
            }
            return (int)Calculate(height, c, r, true);
        }

        private double Calculate(int h, int c, double r, bool isRow)
        {
            var soorat = r * h * c;
            width = (int)(ratio * h);
            var x = Math.Sqrt(soorat / width);
            var floor = (int)Math.Floor(x);
            var ceiling = (int)Math.Ceiling(x);
            if (!isRow)
                return Math.Abs(x - ceiling) > Math.Abs(x - floor) ? Math.Abs(x - floor) : Math.Abs(x - ceiling);
            else
                return Math.Abs(x - ceiling) > Math.Abs(x - floor) ? floor : ceiling;
        }
    }
}
