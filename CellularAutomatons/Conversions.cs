using CellularAutomatons.Cells;
using CellularAutomatons.Helpers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using CellularAutomatons.GrainAutomatons;


namespace CellularAutomatons
{
    public static class Conversions
    {
        public static List<int> ImageStringToListInt(string image)
        {
            var imageArray = image.Split(Environment.NewLine);
            var pixels = (from s in imageArray
                          from s2 in s.Split("\t")
                          select Int32.Parse(s2))
                .ToList();
            return pixels;
        }

        public static int GetRowCount(string image)
        {
            return image.Split(Environment.NewLine).Length;
        }

        public static string IntListToImageString(List<int> image, int rowCount)
        {
            var sb = new StringBuilder();
            int colCount = image.Count / rowCount;
            for (int i = 0; i < image.Count; i++)
            {
                sb.Append((i + 1) % colCount == 0 ? $"{image[i]}\n" : $"{image[i]}\t");
            }
            return sb.ToString();
        }

        public static Bitmap JaggedArrayBinaryToBitmap(IReadOnlyList<int[]> image)
        {
            var dBitmap = new DirectBitmap(image[0].Length, image.Count);
            for (int i = 0; i < image.Count; i++)
            {
                for (int j = 0; j < image[0].Length; j++)
                {
                    Color color = image[i][j] == 0 ? Color.Black : Color.White;
                    dBitmap.SetPixel(j, i, color);
                }
            }
            var bitmap = new Bitmap(dBitmap.Bitmap);
            dBitmap.Dispose();
            return bitmap;
        }
        public static Bitmap ConvertLgaToBitmap(IReadOnlyList<LgaCell[]> image)
        {
            var dBitmap = new DirectBitmap(image[0].Length, image.Count);
            for (int i = 0; i < image.Count; i++)
            {
                for (int j = 0; j < image[i].Length; j++)
                {
                    if (image[i][j] is not null)
                    {
                        if (image[i][j].Particles.Count == 0)
                            dBitmap.SetPixel(j, i, Color.Black);
                        if (image[i][j].Particles.Count > 0)
                            dBitmap.SetPixel(j, i, Color.White);
                    }
                    else
                        dBitmap.SetPixel(j, i, Color.DarkRed);
                }
            }

            var bitmap = new Bitmap(dBitmap.Bitmap);
            dBitmap.Dispose();
            return bitmap;
        }
        public static Bitmap ConvertLbmToBitmap(IReadOnlyList<LbmCell[]> image)
        {
            var dBitmap = new DirectBitmap(image[0].Length, image.Count);
            for (int i = 0; i < image.Count; i++)
            {
                for (int j = 0; j < image[i].Length; j++)
                {
                    if (image[i][j] is not null)
                    {
                        if (image[i][j].Particles.Count == 0)
                            dBitmap.SetPixel(j, i, Color.Black);
                        if (image[i][j].Particles.Count > 0)
                        {
                            var sum = image[i][j].Particles.Sum(p => p.Value);
                            if (sum > 1)
                                dBitmap.SetPixel(j, i, Color.FromArgb(255, 255, 255));
                            else
                                dBitmap.SetPixel(j, i, Color.FromArgb(
                                    (int)(255 * sum),
                                    (int)(255 * sum),
                                    (int)(255 * sum)
                                ));
                        }
                            
                    }
                    else
                        dBitmap.SetPixel(j, i, Color.DarkRed);
                }
            }

            var bitmap = new Bitmap(dBitmap.Bitmap);
            dBitmap.Dispose();
            return bitmap;
        }
        public static Bitmap ConvertJaggedForestFireToBitmap(IReadOnlyList<int[]> image)
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

            var bitmap = new Bitmap(dBitmap.Bitmap);
            dBitmap.Dispose();
            return bitmap;
        }

        public static Bitmap ConvertJaggedGrainToBitmap(IReadOnlyList<int[]> image, int grainAmount, IReadOnlyList<Color> colorList, IReadOnlyList<Color> colorListStruct)
        {
            var dBitmap = new DirectBitmap(image[0].Length, image.Count);
            for (int i = 0; i < image.Count; i++)
            {
                for (int j = 0; j < image[0].Length; j++)
                {
                    if (image[i][j] > 0)
                        dBitmap.SetPixel(j, i, colorList[image[i][j]]);
                    else if (image[i][j] < 0)
                        dBitmap.SetPixel(j, i, colorListStruct[-image[i][j]]);
                    else
                        dBitmap.SetPixel(j, i, colorList[image[i][j]]);
                }
            }
            var bitmap = new Bitmap(dBitmap.Bitmap);
            dBitmap.Dispose();
            return bitmap;
        }
        public static Bitmap ConvertJaggedGrainToBitmapWithStruct(IReadOnlyList<int[]> image, IReadOnlyList<int[]> structField, int grainAmount, IReadOnlyList<Color> colorList, IReadOnlyList<Color> colorListStruct)
        {
            var dBitmap = new DirectBitmap(image[0].Length, image.Count);
            for (int i = 0; i < image.Count; i++)
            {
                for (int j = 0; j < image[0].Length; j++)
                {
                    if (structField[i][j] == 1)
                    {
                        if(image[i][j]>0)
                            dBitmap.SetPixel(j, i, colorList[image[i][j]]);
                        else if (image[i][j] < 0)
                            dBitmap.SetPixel(j, i, colorListStruct[-image[i][j]]);
                        else
                            dBitmap.SetPixel(j, i, colorList[image[i][j]]);
                    }

                }
            }
            var bitmap = new Bitmap(dBitmap.Bitmap);
            dBitmap.Dispose();
            return bitmap;
        }
        public static Bitmap ConvertJaggedGrainToBitmap(IReadOnlyList<Grain[]> image, int grainAmount, IReadOnlyList<Color> colorList)
        {
            var dBitmap = new DirectBitmap(image[0].Length, image.Count);
            for (int i = 0; i < image.Count; i++)
            {
                for (int j = 0; j < image[0].Length; j++)
                {
                    dBitmap.SetPixel(j, i, colorList[image[i][j].Value]);
                }
            }
            var bitmap = new Bitmap(dBitmap.Bitmap);
            dBitmap.Dispose();
            return bitmap;
        }
        public static Bitmap ConvertJaggedGrainToBitmapWithStruct(IReadOnlyList<Grain[]> image, IReadOnlyList<int[]> structField, int grainAmount, IReadOnlyList<Color> colorList)
        {
            var dBitmap = new DirectBitmap(image[0].Length, image.Count);
            for (int i = 0; i < image.Count; i++)
            {
                for (int j = 0; j < image[0].Length; j++)
                {
                    if (structField[i][j] == 1)
                        dBitmap.SetPixel(j, i, colorList[image[i][j].Value]);
                }
            }
            var bitmap = new Bitmap(dBitmap.Bitmap);
            dBitmap.Dispose();
            return bitmap;
        }

        public static Image ConvertJaggedGrainEnergyToBitmap(IReadOnlyList<Grain[]> grainField)
        {
            var dBitmap = new DirectBitmap(grainField[0].Length, grainField.Count);
            for (int i = 0; i < grainField.Count; i++)
            {
                for (int j = 0; j < grainField[0].Length; j++)
                {
                    Color color = grainField[i][j].Energy == 0 ? Color.Black : Color.White;
                        dBitmap.SetPixel(j, i, color);
                }
            }
            var bitmap = new Bitmap(dBitmap.Bitmap);
            dBitmap.Dispose();
            return bitmap;
        }
        public static Image ConvertJaggedGrainEnergyToBitmapWithStruct(IReadOnlyList<Grain[]> grainField, IReadOnlyList<int[]> structField)
        {
            var dBitmap = new DirectBitmap(grainField[0].Length, grainField.Count);
            for (int i = 0; i < grainField.Count; i++)
            {
                for (int j = 0; j < grainField[0].Length; j++)
                {
                    Color color = grainField[i][j].Energy == 0 ? Color.Black : Color.White;
                    if (structField[i][j] == 1)
                        dBitmap.SetPixel(j, i, color);
                }
            }
            var bitmap = new Bitmap(dBitmap.Bitmap);
            dBitmap.Dispose();
            return bitmap;
        }

        public static Image ConvertJaggedGrainToBitmapSRX(IReadOnlyList<Grain[]> image, int grainAmount, List<Color> colorListGreen, List<Color> colorListRed)
        {
            var dBitmap = new DirectBitmap(image[0].Length, image.Count);
            for (int i = 0; i < image.Count; i++)
            {
                for (int j = 0; j < image[0].Length; j++)
                {
                    dBitmap.SetPixel(j, i,
                        image[i][j].Value > 0 ? colorListGreen[image[i][j].Value] : colorListRed[-image[i][j].Value]);
                }
            }
            var bitmap = new Bitmap(dBitmap.Bitmap);
            dBitmap.Dispose();
            return bitmap;
        }
        public static Image ConvertJaggedGrainToBitmapSRXWithStruct(IReadOnlyList<Grain[]> image, IReadOnlyList<int[]> structField, int grainAmount, List<Color> colorListGreen, List<Color> colorListRed)
        {
            var dBitmap = new DirectBitmap(image[0].Length, image.Count);
            for (int i = 0; i < image.Count; i++)
            {
                for (int j = 0; j < image[0].Length; j++)
                {
                    if (structField[i][j] == 1)
                        dBitmap.SetPixel(j, i,
                        image[i][j].Value > 0 ? colorListGreen[image[i][j].Value] : colorListRed[-image[i][j].Value]);
                }
            }
            var bitmap = new Bitmap(dBitmap.Bitmap);
            dBitmap.Dispose();
            return bitmap;
        }

        public static int[][] ImageToJaggedArrayBinary(Bitmap bitmap)
        {
            int[][] field = new int[bitmap.Width][];
            for (int i = 0; i < field.Length; i++)
            {
                field[i] = new int[bitmap.Height];
                for (int j = 0; j < field[i].Length; j++)
                {
                    field[i][j] = bitmap.GetPixel(j, i) == Color.FromArgb(255,255,255,255) ? 0 : 1;
                }
            }

            return field;
        }
    }
}
