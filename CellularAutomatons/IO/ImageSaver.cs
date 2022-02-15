using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using AnimatedGif;
using CellularAutomatons.Helpers;
using Microsoft.VisualBasic.CompilerServices;

namespace CellularAutomatons.IO
{
    public static class ImageSaver
    {
        public static void Save(string image, string path)
        {
            using var sw = new StreamWriter(path);
            sw.WriteLine(image);
        }

        public static void Save(Bitmap image, string path)
        {
            image.Save(path, ImageFormat.Bmp);
        }

        public static void Save(int[][] image, string path)
        {
            var bitmap = ConvertJaggedArrayToBitmap(image);
            bitmap.Save(path, ImageFormat.Bmp);
        }

        private static Bitmap ConvertJaggedArrayToBitmap(IReadOnlyList<int[]> image)
        {
            Bitmap bitmap = new Bitmap(image[0].Length, image.Count);
            for (int i = 0; i < image.Count; i++)
            {
                for (int j = 0; j < image[i].Length; j++)
                {
                    bitmap.SetPixel(j, i, image[i][j] == 0 ? Color.Black : Color.White);
                }
            }

            return bitmap;
        }

        private static DirectBitmap ConvertJaggedForestFireToBitmap(IReadOnlyList<int[]> image)
        {
            var dBitmap = new DirectBitmap(image[0].Length, image.Count);
            for (int i = 0; i < image.Count; i++)
            {
                for (int j = 0; j < image[0].Length; j++)
                {
                    if (image[i][j] == 0)
                        dBitmap.SetPixel(j, i, Color.Black);
                    else if (image[i][j] == -1)
                        dBitmap.SetPixel(j, i, Color.DodgerBlue);
                    else if (image[i][j] == 1)
                        dBitmap.SetPixel(j, i, Color.DarkGreen);
                    else if (image[i][j] == 2)
                        dBitmap.SetPixel(j, i, Color.Red);
                    else if (image[i][j] == 3)
                        dBitmap.SetPixel(j, i, Color.FromArgb(200, 0, 0));
                    else if (image[i][j] == 4)
                        dBitmap.SetPixel(j, i, Color.FromArgb(150, 0, 0));
                    else if (image[i][j] == 5)
                        dBitmap.SetPixel(j, i, Color.FromArgb(100, 0, 0));
                    else if (image[i][j] == 6)
                        dBitmap.SetPixel(j, i, Color.FromArgb(50, 0, 0));
                }
            }

            return dBitmap;
        }
        public static void SaveGifFromList(List<int[][]> frames, string path)
        {
            using var gif = AnimatedGif.AnimatedGif.Create(path, 66);
            foreach (var bitmap in frames.Select(ConvertJaggedArrayToBitmap))
            {
                var bitmap2 = ResizeImage(bitmap, 400, 400);
                gif.AddFrame(bitmap2, -1, GifQuality.Bit4);
            }

        }

        public static void SaveGifGameOfLife(List<int[][]> frames, string path)
        {
            using var gif = AnimatedGif.AnimatedGif.Create(path, 66);
            foreach (var bitmap in frames.Select(Conversions.ConvertJaggedForestFireToBitmap))
            {
                gif.AddFrame(bitmap, -1, GifQuality.Bit4);
            }
        }
        private static Bitmap ResizeImage(Image image, int width, int height)
        {
            var destRect = new Rectangle(0, 0, width, height);
            var destImage = new Bitmap(width, height);

            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (var graphics = Graphics.FromImage(destImage))
            {
                // graphics.CompositingMode = CompositingMode.SourceCopy;
                 graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.NearestNeighbor;
                graphics.SmoothingMode = SmoothingMode.None;
                graphics.PixelOffsetMode = PixelOffsetMode.HighSpeed;

                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            return destImage;
        }
    }

}
