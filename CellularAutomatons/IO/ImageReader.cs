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
    }
}
