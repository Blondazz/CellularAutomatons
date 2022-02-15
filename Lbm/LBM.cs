using AnimatedGif;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace LBM
{

    public class LBM
    {
        private const int Nx = 256;
        private const int Ny = 256;
        private const double TauAtmos = 2; 

        private List<List<double>> vx;
        private List<List<double>> vy;
        private List<List<Dictionary<string, double>>> fin;
        private List<List<Dictionary<string, double>>> fout;


        private void Init(int y, int x)
        {
            if (x == 0 || x == Nx - 1 || y == 0 || y == Ny - 1)
                vx[x][y] = 1.0 * y / Ny * 0.05;
            else
                vx[x][y] = 0.0;
            vy[x][y] = 0.0;

            double vx2 = Math.Pow(vx[x][y], 2);
            double vy2 = Math.Pow(vy[x][y], 2);
            double eu2 = 1.0 - 1.5 * (vx2 + vy2);

            fin[x][y]["C"] = 16.0 / 36.0 * eu2;
            fin[x][y]["N"] = 4.0 / 36.0 * (eu2 + 3.0 * vy[x][y] + 4.5 * vy2);
            fin[x][y]["E"] = 4.0 / 36.0 * (eu2 + 3.0 * vx[x][y] + 4.5 * vx2);
            fin[x][y]["S"] = 4.0 / 36.0 * (eu2 - 3.0 * vy[x][y] + 4.5 * vy2);
            fin[x][y]["W"] = 4.0 / 36.0 * (eu2 - 3.0 * vx[x][y] + 4.5 * vx2);
            fin[x][y]["NE"] = 1.0 / 36.0 * (eu2 + 3.0 * (vx[x][y] + vy[x][y]) + 4.5 * Math.Pow(vx[x][y] + vy[x][y], 2));
            fin[x][y]["NW"] = 1.0 / 36.0 * (eu2 + 3.0 * (vx[x][y] - vy[x][y]) + 4.5 * Math.Pow(vx[x][y] - vy[x][y], 2));
            fin[x][y]["SE"] =
                1.0 / 36.0 * (eu2 + 3.0 * (-vx[x][y] - vy[x][y]) + 4.5 * Math.Pow(vx[x][y] + vy[x][y], 2));
            fin[x][y]["SW"] =
                1.0 / 36.0 * (eu2 + 3.0 * (-vx[x][y] + vy[x][y]) + 4.5 * Math.Pow(-vx[x][y] + vy[x][y], 2));
        }
        private void Stream(int x, int y)
        {
            fin[x][y]["C"] = fout[x][y]["C"];
            if (x < Nx - 1)
            {
                fin[x][y]["W"] = fout[x + 1][y]["W"];
                fin[x + 1][y]["E"] = fout[x][y]["E"];
            }

            if (y < Ny - 1)
            {
                fin[x][y]["S"] = fout[x][y + 1]["S"];
                fin[x][y + 1]["N"] = fout[x][y]["N"];
            }

            if (x < Nx - 1 && y < Ny - 1)
            {
                fin[x][y]["SW"] = fout[x + 1][y + 1]["SW"];
                fin[x + 1][y + 1]["NE"] = fout[x][y]["NE"];
            }

            if (x > 0 && y < Ny - 1)
            {
                fin[x][y]["SE"] = fout[x - 1][y + 1]["SE"];
                fin[x - 1][y + 1]["NW"] = fout[x][y]["NW"];
            }

            if (x == 0 || x == Nx - 1 || y == 0 || y == Ny - 1)
            {
                fin[x][y]["E"] = fout[x][y]["E"];
                fin[x][y]["NE"] = fout[x][y]["NE"];
                fin[x][y]["SE"] = fout[x][y]["SE"];
                fin[x][y]["W"] = fout[x][y]["W"];
                fin[x][y]["SW"] = fout[x][y]["SW"];
                fin[x][y]["NW"] = fout[x][y]["NW"];
                fin[x][y]["N"] = fout[x][y]["N"];
                fin[x][y]["S"] = fout[x][y]["S"];
            }
        }
        private void Calculate(int y, int x)
        {
            //  double rho = fin[x][y].Values.Sum();
            double rho = fin[x][y].Sum(z => z.Value);

            vx[x][y] = (fin[x][y]["E"] + fin[x][y]["SE"] + fin[x][y]["NE"] - fin[x][y]["W"] - fin[x][y]["SW"] -
                        fin[x][y]["NW"]) / rho;
            vy[x][y] = (fin[x][y]["N"] + fin[x][y]["NW"] + fin[x][y]["NE"] - fin[x][y]["S"] - fin[x][y]["SW"] -
                        fin[x][y]["SE"]) / rho;

            double vx2 = Math.Pow(vx[x][y], 2);
            double vy2 = Math.Pow(vy[x][y], 2);
            double eu2 = 1 - 1.5 * (vx2 + vy2);
            double rho36 = rho / 36.0;

            double c = 16 * rho36 * eu2;
            double n = 4 * rho36 * (eu2 + 3 * vy[x][y] + 4 * vy2);
            double e = 4 * rho36 * (eu2 + 3 * vx[x][y] + 4 * vx2);
            double s = 4 * rho36 * (eu2 - 3 * vy[x][y] + 4 * vy2);
            double w = 4 * rho36 * (eu2 - 3 * vx[x][y] + 4 * vx2);

            double ne = rho36 * (eu2 + 3 * (vx[x][y] + vy[x][y]) + 4.5 * Math.Pow(vx[x][y] + vy[x][y], 2));
            double se = rho36 * (eu2 + 3 * (vx[x][y] - vy[x][y]) + 4.5 * Math.Pow(vx[x][y] - vy[x][y], 2));
            double sw = rho36 * (eu2 + 3 * (-vx[x][y] - vy[x][y]) + 4.5 * Math.Pow(-vx[x][y] - vy[x][y], 2));
            double nw = rho36 * (eu2 + 3 * (-vx[x][y] + vy[x][y]) + 4.5 * Math.Pow(-vx[x][y] + vy[x][y], 2));

            fout[x][y]["C"] = fin[x][y]["C"] + (c - fin[x][y]["C"]) / TauAtmos;
            fout[x][y]["N"] = fin[x][y]["N"] + (n - fin[x][y]["N"]) / TauAtmos;
            fout[x][y]["E"] = fin[x][y]["E"] + (e - fin[x][y]["E"]) / TauAtmos;
            fout[x][y]["S"] = fin[x][y]["S"] + (s - fin[x][y]["S"]) / TauAtmos;
            fout[x][y]["W"] = fin[x][y]["W"] + (w - fin[x][y]["W"]) / TauAtmos;
            fout[x][y]["NE"] = fin[x][y]["NE"] + (ne - fin[x][y]["NE"]) / TauAtmos;
            fout[x][y]["SE"] = fin[x][y]["SE"] + (se - fin[x][y]["SE"]) / TauAtmos;
            fout[x][y]["SW"] = fin[x][y]["SW"] + (sw - fin[x][y]["SW"]) / TauAtmos;
            fout[x][y]["NW"] = fin[x][y]["NW"] + (nw - fin[x][y]["NW"]) / TauAtmos;
        }

       

        public void Start()
        {
            vx = new List<List<double>>();
            vy = new List<List<double>>();
            fin = new List<List<Dictionary<string, double>>>();
            fout = new List<List<Dictionary<string, double>>>();
            for (int i = 0; i < Nx; i++)
            {
                vx.Add(new List<double>(Nx));
                vy.Add(new List<double>(Nx));
                fin.Add(new List<Dictionary<string, double>>());
                fout.Add(new List<Dictionary<string, double>>());
                for (int j = 0; j < Ny; j++)
                {
                    vx[i].Add(0.0);
                    vy[i].Add(0.0);
                    fin[i].Add(new Dictionary<string, double>()
                    {
                        { "C", 1.0 },
                        { "E", 1.0 },
                        { "W", 1.0 },
                        { "S", 1.0 },
                        { "N", 1.0 },
                        { "SE", 1.0 },
                        { "SW", 1.0 },
                        { "NE", 1.0 },
                        { "NW", 1.0 },
                    });
                    fout[i].Add(new Dictionary<string, double>()
                    {
                        { "C", 1.0 },
                        { "E", 1.0 },
                        { "W", 1.0 },
                        { "S", 1.0 },
                        { "N", 1.0 },
                        { "SE", 1.0 },
                        { "SW", 1.0 },
                        { "NE", 1.0 },
                        { "NW", 1.0 },
                    });
                }
            }

            int current = 0;
            int desired = 350;

            for (int x = 0; x < Nx; x++)
            {
                for (int y = 0; y < Ny; y++)
                {
                    Init(x, y);
                }
            }

            while (current < desired)
            {
                Draw($"output/{current}-{desired}.png");

                for (int x = 0; x < Nx; x++)
                {
                    for (int y = 0; y < Ny; y++)
                    {
                        Calculate(x, y);
                    }
                }


                for (int x = 0; x < Nx; x++)
                {
                    for (int y = 0; y < Ny; y++)
                    {
                        Stream(x, y);
                    }
                }

                Console.WriteLine(current);
                current++;
            }

            Draw($"output/{current}-{desired}.png");
            SaveGif("lbm-flow.gif", _images);
        }

        private readonly List<Bitmap> _images = new List<Bitmap>();

        private void Draw(string name)
        {
            var img = new DirectBitmap(Nx, Ny);

            for (int i = Nx - 1; i > -1; i--)
            {
                for (int j = Ny - 1; j > -1; j--)
                {
                    int r = (int)(vx[j][i] * 50 * 255);
                    if (r > 255)
                        r = 255;
                    else if (r < 0)
                        r = 0;
                    var c = Color.FromArgb(r, 0, 0);
                    img.SetPixel(j, i, c);
                }
            }

            img.Bmp.RotateFlip(RotateFlipType.RotateNoneFlipY);
            using var graphics = Graphics.FromImage(img.Bmp);
            using var pen = new Pen(Color.FromArgb(120, 120, 120));
            //for (int i = 0; i < Nx; i += 10)
            //{
            //    for (int j = 0; j < Ny; j += 10)
            //    {
            //        graphics.DrawLine(pen, (float)j, (float)(Ny - i), (float)(j + vx[j][i] * 500),
            //            (float)(Ny - i + vy[j][i] * 500));
            //    }
            //}


            var mu = new List<double>() { 0.0, 0.4, 0.9 };
            var grav = new List<double>() { 0.0, 0.002, 0.005 };
            var color = new List<Color>()
            {
                Color.FromArgb(0, 255, 255),
                Color.FromArgb(255, 255, 0),
                Color.FromArgb(0, 0, 255)
            };

            //for (int h = 0; h < 3; h++)
            //{
            //    for (int i = 1; i < 6; i++)
            //    {
            //        double xpart0 = 0.0;
            //        double xpart1 = 0.0;
            //        double ypart0 = (double)i * Ny / 5 - 1;
            //        double ypart1 = (double)i * Ny / 5 - 1;

            //        double vxpart0 = vx[(int)Math.Floor(xpart0)][(int)Math.Floor(ypart0)];
            //        double vypart0 = vy[(int)Math.Floor(xpart0)][(int)Math.Floor(ypart0)];

            //        while (Nx - 1 > xpart1 && xpart1 >= 0 && 0 < ypart0 && ypart1 <= Ny - 1)
            //        {
            //            double vxpart1 = mu[h] * vxpart0 + (1 - mu[h]) * vx[(int)xpart0][(int)ypart0];
            //            double vypart1 = mu[h] * vypart0 + (1 - mu[h]) * vy[(int)xpart0][(int)ypart0] - grav[h];

            //            xpart1 = xpart0 + 100 * (vxpart0 + vxpart1) / 2;
            //            ypart1 = ypart0 + 100 * (vypart0 + vypart1) / 2;

            //            vxpart0 = vxpart1;
            //            vypart0 = vypart1;

            //            if (Math.Abs(xpart0 - xpart1) <= 0.001 && Math.Abs(ypart0 - ypart1) <= 0.001)
            //                break;
            //            graphics.DrawLine(new Pen(color[h]), (float)xpart0, (float)(Ny - ypart0), (float)xpart1,
            //                (float)(Ny - ypart1));


            //            xpart0 = xpart1;
            //            ypart0 = ypart1;
            //        }
            //    }
            //}
            _images.Add(img.Bmp);
        }

        public static void SaveGif(string fileName, IEnumerable<Image> frames, int delay = 30)
        {
            using var gif = AnimatedGif.AnimatedGif.Create(fileName, 0);

            foreach (var frame in frames)
                gif.AddFrame(frame, delay);
        }
    }
}