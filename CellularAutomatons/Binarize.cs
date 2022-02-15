using System.Drawing;

namespace CellularAutomatons
{
    public static class Binarize
    {
        public static string BinarizeString(string image, int threshold)
        {
            var pixelList = Conversions.ImageStringToListInt(image);
            for (int i = 0; i < pixelList.Count; i++)
            {
                if (pixelList[i] >= threshold)
                    pixelList[i] = 255;
                else
                    pixelList[i] = 0;
            }

            return Conversions.IntListToImageString(pixelList, Conversions.GetRowCount(image));
        }

        public static Bitmap BinarizeBitmap(Bitmap image, int threshold)
        {
            for (int i = 0; i < image.Width; i++)
            {
                for (int j = 0; j < image.Height; j++)
                {
                    image.SetPixel(i, j,
                        image.GetPixel(i, j).R >= threshold ? Color.FromArgb(255, 255, 255) : Color.FromArgb(0, 0, 0));
                }
            }

            return image;

        }
    }
}
