using System.Drawing;
using System.IO;

namespace CellularAutomatons.IO
{
    public static class ImageReader
    {
        public static string ReadString(string path)
        {
            using (var sr = new StreamReader(path))
            {
                return sr.ReadToEnd();
            }
        }

        public static Bitmap ReadBitmap(string path)
        {
            return new Bitmap(Image.FromFile("image.bmp"));
        }

        public static int[][] ReadGrainData(int width, int height)
        {
            var bitmap = new Bitmap(Image.FromFile(@"InputImage\binarized.bmp"), width, height);
            return Conversions.ImageToJaggedArrayBinary(bitmap);
        }
    }
}
