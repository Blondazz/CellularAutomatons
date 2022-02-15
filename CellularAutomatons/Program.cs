using System;
using System.Drawing;
using System.Windows.Forms;
using CellularAutomatons.IntAutomatons;
using CellularAutomatons.IO;

namespace CellularAutomatons
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Console.WriteLine("Choose an automaton \n1. 1D\n2. Game of Life\n3. Forest Fire\n4. LGA\n5. LBM");
            int choice = Int32.Parse(Console.ReadLine()!);
            switch (choice)
            {
                case 1:
                    Console.WriteLine("1. Console \n2. Winform");
                    int choice2 = Int32.Parse(Console.ReadLine()!);
                    if (choice2 is 1)
                    {
                        Console.WriteLine("Please input the size of the image:");
                        int size = Int32.Parse(Console.ReadLine()!);
                        Console.WriteLine("Please input the binary rule (0-255)");
                        int rule = Int32.Parse(Console.ReadLine()!);
                        int[] input = new int[size];
                        input[size / 2 - 1] = 1;
                        IntCellularAutomaton ca = new IntCellularAutomaton(input, size, rule);
                        var result = ca.GenerateJaggedArray();
                        ImageSaver.Save(result, $"output/cellularAutomaton{rule}.bmp");
                    }
                    else
                    {
                        Application.Run(new Form1D());
                    }
                    break;
                case 2:
                    Console.WriteLine("1. Console \n2. Winform");
                    int choice3 = Int32.Parse(Console.ReadLine()!);
                    if (choice3 is 1)
                    {
                        Console.WriteLine("Please input the width and height of the image:");
                        int width = Int32.Parse(Console.ReadLine()!);
                        int height = Int32.Parse(Console.ReadLine()!);
                        var random = new Random();
                        var arr = new int[height][];
                        for (int i = 0; i < width; i++)
                        {
                            arr[i] = new int[width];
                            for (int j = 0; j < height; j++)
                            {
                                arr[i][j] = random.Next(0, 100) > 50 ? 1 : 0;
                            }
                        }

                        Console.WriteLine("How many iterations?");
                        int iterations = Int32.Parse(Console.ReadLine()!);
                        var ca2d = new IntCellularAutomaton2D(arr, iterations, new GameOfLife());
                        var fieldList = ca2d.Start();
                    }
                    else
                    {
                        Application.Run(new FormGameOfLife());
                    }
                    break;
                case 3:
                    Console.WriteLine("1. Console \n2. Winform");
                    int choice4 = Int32.Parse(Console.ReadLine()!);
                    if (choice4 is 1)
                    {
                        Console.WriteLine("How many iterations?");
                        int iterations = Int32.Parse(Console.ReadLine()!);
                        int IgnitionProbability = 30;
                        int SpontaneousIgnitionProbability = 1;
                        int GrowthProbability = 15;
                        Console.WriteLine("1. Binarized image simulation");
                        Console.WriteLine("2. All trees simulation");
                        Console.WriteLine("3. Random trees simulation");
                        int ffChoice = Int32.Parse(Console.ReadLine()!);
                        int[][] field = new int[200][];
                        if (ffChoice is 1)
                        {
                            Bitmap bitmap = ImageReader.ReadBitmap("image.bmp");
                            bitmap = Binarize.BinarizeBitmap(bitmap, 100);
                            field = new int[bitmap.Height][];
                            for (int i = 0; i < bitmap.Height; i++)
                            {
                                field[i] = new int[bitmap.Width];
                                for (int j = 0; j < bitmap.Width; j++)
                                {
                                    field[i][j] = bitmap.GetPixel(j, i).R == 0 ? -1 : 1;
                                }
                            }
                        }
                        else if (ffChoice is 2 or 3)
                        {
                            SpontaneousIgnitionProbability = 10;
                            GrowthProbability = 20;
                            Random r = new Random();
                            for (int i = 0; i < field.Length; i++)
                            {
                                field[i] = new int[200];
                                for (int j = 0; j < field[0].Length; j++)
                                {
                                    if (ffChoice == 2)
                                        field[i][j] = 1;
                                    else field[i][j] = r.Next(0, 10) > 6 ? 1 : 0;
                                }
                            }
                        }


                        field[10][10] = 2;
                        field[11][10] = 2;
                        field[10][11] = 2;
                        field[11][11] = 2;
                        IntCellularAutomaton2D ca2d = new IntCellularAutomaton2D(field, iterations, new ForestFire(IgnitionProbability, SpontaneousIgnitionProbability, GrowthProbability));
                        var fieldList = ca2d.Start();
                        ImageSaver.SaveGifGameOfLife(fieldList, "forestfire.gif");
                    }
                    else
                    {
                        Application.Run(new FormForestFire());
                    }
                    break;
                case 4:
                    Application.Run(new FormLga());
                    break;
                case 5:
                    var lbm = new LBM.LBM();
                    lbm.Start();
                    break;
            }
            
        }
    }
}
