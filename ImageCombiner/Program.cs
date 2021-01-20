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
        private static int imagesInRow = 2;
        private static int height = 1000;
        private static readonly double ratio = 0.675;
        private static readonly double headerRatio = 1.925;
        private static int width;

        static void Main(string[] args)
        {
            WebClient wc = new WebClient();
            List<string> vs = new List<string> {
                "https://m.media-amazon.com/images/M/MV5BMTk3NGQ4NjMtZTU1Mi00MTJjLTllMjUtOTNlN2I3NzU5ZjE1XkEyXkFqcGdeQXVyNTkyMjQwNw@@",
                "https://m.media-amazon.com/images/M/MV5BZTU1N2VhNjctZWVjMy00MDMwLTg4MDMtMjRjMDM2NDFlMzM4XkEyXkFqcGdeQXVyNzExNDQ2NDM@",
                "https://m.media-amazon.com/images/M/MV5BMTk3NGQ4NjMtZTU1Mi00MTJjLTllMjUtOTNlN2I3NzU5ZjE1XkEyXkFqcGdeQXVyNTkyMjQwNw@@",
                "https://m.media-amazon.com/images/M/MV5BZTU1N2VhNjctZWVjMy00MDMwLTg4MDMtMjRjMDM2NDFlMzM4XkEyXkFqcGdeQXVyNzExNDQ2NDM@",
                "https://m.media-amazon.com/images/M/MV5BMTk3NGQ4NjMtZTU1Mi00MTJjLTllMjUtOTNlN2I3NzU5ZjE1XkEyXkFqcGdeQXVyNTkyMjQwNw@@",
                "https://m.media-amazon.com/images/M/MV5BZTU1N2VhNjctZWVjMy00MDMwLTg4MDMtMjRjMDM2NDFlMzM4XkEyXkFqcGdeQXVyNzExNDQ2NDM@",
                "https://m.media-amazon.com/images/M/MV5BMTk3NGQ4NjMtZTU1Mi00MTJjLTllMjUtOTNlN2I3NzU5ZjE1XkEyXkFqcGdeQXVyNTkyMjQwNw@@",
                "https://m.media-amazon.com/images/M/MV5BZTU1N2VhNjctZWVjMy00MDMwLTg4MDMtMjRjMDM2NDFlMzM4XkEyXkFqcGdeQXVyNzExNDQ2NDM@",
                "https://m.media-amazon.com/images/M/MV5BMTk3NGQ4NjMtZTU1Mi00MTJjLTllMjUtOTNlN2I3NzU5ZjE1XkEyXkFqcGdeQXVyNTkyMjQwNw@@",
                "https://m.media-amazon.com/images/M/MV5BZTU1N2VhNjctZWVjMy00MDMwLTg4MDMtMjRjMDM2NDFlMzM4XkEyXkFqcGdeQXVyNzExNDQ2NDM@",
                "https://m.media-amazon.com/images/M/MV5BMTk3NGQ4NjMtZTU1Mi00MTJjLTllMjUtOTNlN2I3NzU5ZjE1XkEyXkFqcGdeQXVyNTkyMjQwNw@@",
                "https://m.media-amazon.com/images/M/MV5BMTk3NGQ4NjMtZTU1Mi00MTJjLTllMjUtOTNlN2I3NzU5ZjE1XkEyXkFqcGdeQXVyNTkyMjQwNw@@",
                "https://m.media-amazon.com/images/M/MV5BZTU1N2VhNjctZWVjMy00MDMwLTg4MDMtMjRjMDM2NDFlMzM4XkEyXkFqcGdeQXVyNzExNDQ2NDM@",
                "https://m.media-amazon.com/images/M/MV5BMTk3NGQ4NjMtZTU1Mi00MTJjLTllMjUtOTNlN2I3NzU5ZjE1XkEyXkFqcGdeQXVyNTkyMjQwNw@@",
                "https://m.media-amazon.com/images/M/MV5BZTU1N2VhNjctZWVjMy00MDMwLTg4MDMtMjRjMDM2NDFlMzM4XkEyXkFqcGdeQXVyNzExNDQ2NDM@",
                "https://m.media-amazon.com/images/M/MV5BMTk3NGQ4NjMtZTU1Mi00MTJjLTllMjUtOTNlN2I3NzU5ZjE1XkEyXkFqcGdeQXVyNTkyMjQwNw@@",
                "https://m.media-amazon.com/images/M/MV5BZTU1N2VhNjctZWVjMy00MDMwLTg4MDMtMjRjMDM2NDFlMzM4XkEyXkFqcGdeQXVyNzExNDQ2NDM@",
                "https://m.media-amazon.com/images/M/MV5BMTk3NGQ4NjMtZTU1Mi00MTJjLTllMjUtOTNlN2I3NzU5ZjE1XkEyXkFqcGdeQXVyNTkyMjQwNw@@",
                "https://m.media-amazon.com/images/M/MV5BZTU1N2VhNjctZWVjMy00MDMwLTg4MDMtMjRjMDM2NDFlMzM4XkEyXkFqcGdeQXVyNzExNDQ2NDM@",
                "https://m.media-amazon.com/images/M/MV5BMTk3NGQ4NjMtZTU1Mi00MTJjLTllMjUtOTNlN2I3NzU5ZjE1XkEyXkFqcGdeQXVyNTkyMjQwNw@@",
                "https://m.media-amazon.com/images/M/MV5BZTU1N2VhNjctZWVjMy00MDMwLTg4MDMtMjRjMDM2NDFlMzM4XkEyXkFqcGdeQXVyNzExNDQ2NDM@",
                "https://m.media-amazon.com/images/M/MV5BMTk3NGQ4NjMtZTU1Mi00MTJjLTllMjUtOTNlN2I3NzU5ZjE1XkEyXkFqcGdeQXVyNTkyMjQwNw@@",
            };
            imagesInRow = GetImagesInRowCount(vs.Count, headerRatio);
            var images = vs.Select(s => ResizeImage(Image.FromStream(new MemoryStream(wc.DownloadData(s))),height)).ToList();

     

            int forMax = 0;
            if (images.Count % imagesInRow == 0)
                forMax = images.Count / imagesInRow;
            else
                forMax = images.Count / imagesInRow + 1;

            var headerWidth = imagesInRow * width;
            var headerHeight = forMax * height;
            var bitmapImage = new Bitmap(headerWidth, headerHeight);

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
            bitmapImage.Save("mammad.jpg", ImageFormat.Jpeg);
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

        public static int GetImagesInRowCount(int c,double r)
        {
            height = 700;
            var min = Calculate(700, c, r,false);
            for (int i = 710; i < 1100; i+= 10)
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

        private static double Calculate(int h, int c,double r, bool isRow)
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
