using CellularAutomatons.GrainAutomatons;
using CellularAutomatons.IntAutomatons;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Threading.Tasks;
using System.Windows.Forms;
using CellularAutomatons.IO;

namespace CellularAutomatons
{
    public partial class FormGrainGrowth : Form
    {
        private bool _isRunning;
        private int[][] _field;
        private int _grainAmount;
        private GrainGrowth _gg;
        private GrainAutomaton2D _ga2d;
        private Stopwatch _sw = new Stopwatch();
        private Graphics _g; 
        private List<Color> _colorList = new() {Color.White};
        

        public FormGrainGrowth()
        {
            InitializeComponent();
            pictureBoxGg.SizeMode = PictureBoxSizeMode.Normal;
            comboBoxGg.SelectedIndex = 1;
            comboBoxNeigh.SelectedIndex = 0;
            comboBoxLocation.SelectedIndex = 0;
        }

        private void buttonRunGg_Click(object sender, EventArgs e)
        {
            _isRunning = !_isRunning;
            if (_isRunning)
            {
                buttonGenerateGg.Enabled = false;
                buttonSave.Enabled = false;
                buttonPng.Enabled = false;
                labelSave.Text = string.Empty;
                buttonRunGg.Text = "Stop";
                Task.Factory.StartNew(Run);

            }
            else
            {
                buttonRunGg.Text = "Run";
                buttonGenerateGg.Enabled = true;
                buttonSave.Enabled = true;
                buttonPng.Enabled = true;

            }
        }
        private async Task Run()
        {
            while (_isRunning)
            {
                object xd = new object();
                _sw.Reset();
                _sw.Start();
                _field = _ga2d.StartOnce();
                Bitmap bitmap;
                if (_field.Length == _field[0].Length)
                {
                    bitmap = new Bitmap(500, 500);
                }
                else
                {
                    bitmap = new Bitmap(_field[0].Length, _field.Length);
                }
                _g = Graphics.FromImage(bitmap);
                _g.InterpolationMode = InterpolationMode.NearestNeighbor;
                _g.PixelOffsetMode = PixelOffsetMode.Half;
                _g.DrawImage(Conversions.ConvertJaggedGrainToBitmap(_field, _grainAmount, _colorList), new Rectangle(Point.Empty, bitmap.Size));
                _sw.Stop();
                try
                {
                    pictureBoxGg.Image = bitmap;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }
        }
        private void buttonGenerateGg_Click(object sender, EventArgs e)
        {
            _isRunning = false;
            buttonRunGg.Text = "Run";
            labelSave.Text = string.Empty;
            buttonRunGg.Enabled = true;
            buttonSave.Enabled = true;
            buttonPng.Enabled = true;
            int width = (int)numericUpDownWidth.Value;
            int height = (int)numericUpDownHeight.Value;
            _field = new int[height][];
            _grainAmount = (int)numericUpDownGrains.Value;
            var condition = (BoundaryConditions) comboBoxGg.SelectedIndex;
            var neighbourhood = (Neighbourhood) comboBoxNeigh.SelectedIndex;
            var location = (Location) comboBoxLocation.SelectedIndex;

            for (int i = 0; i < _field.Length; i++)
            {
                _field[i] = new int[width];
                for (int j = 0; j < _field[i].Length; j++)
                {
                    _field[i][j] = 0;
                }
            }

            for (int i = 0; i < _grainAmount; i++)
            {
                var random = new Random();
                int x, y;
                Color color;
                do
                {
                    x = random.Next(0, height);
                    y = random.Next(0, width);
                } while (_field[x][y] != 0);
                _field[x][y] = i + 1;
                do
                {
                    color = Color.FromArgb(random.Next(0, 256), random.Next(0, 256), random.Next(0, 256));
                } while (_colorList.Contains(color));
                _colorList.Add(color);
            }

            _gg = new GrainGrowth();
            _ga2d = new GrainAutomaton2D(_field, _gg, condition, neighbourhood);
            Bitmap bitmap;
            if (height == width)
            {
                bitmap = new Bitmap(500, 500);
            }
            else
            {
                bitmap = new Bitmap(width, height);
            }
            _g = Graphics.FromImage(bitmap);
            _g.InterpolationMode = InterpolationMode.NearestNeighbor;
            _g.PixelOffsetMode = PixelOffsetMode.Half;
            _g.DrawImage(Conversions.ConvertJaggedGrainToBitmap(_field, _grainAmount, _colorList), new Rectangle(Point.Empty, bitmap.Size));
            pictureBoxGg.Image = bitmap;
        }

        private void pictureBoxGg_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            TxtSaver.SaveGrain(_field, "grain.txt");
            labelSave.Text = "Saved to grain.txt";
        }

        private void buttonPng_Click(object sender, EventArgs e)
        {
            Bitmap bitmap = new Bitmap(_field[0].Length, _field.Length);
            using var g = Graphics.FromImage(bitmap);
            g.DrawImage(Conversions.ConvertJaggedGrainToBitmap(_field, _grainAmount, _colorList), new Rectangle(Point.Empty, bitmap.Size));
            bitmap.Save("Grain.png", System.Drawing.Imaging.ImageFormat.Png);
            bitmap.Dispose();
            g.Dispose();
        }
    }
}
