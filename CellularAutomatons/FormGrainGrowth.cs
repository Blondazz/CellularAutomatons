using CellularAutomatons.GrainAutomatons;
using CellularAutomatons.IO;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CellularAutomatons
{
    public partial class FormGrainGrowth : Form
    {
        private bool _isRunning;
        private bool _isRunningMC;
        private int[][] _field;
        private Grain[][] _grainField;
        private int _grainAmount;
        private GrainGrowth _gg;
        private GrainAutomaton2D _ga2d;
        private MonteCarlo2D _mc2d;
        private Stopwatch _sw = new Stopwatch();
        private Graphics _g;
        private List<Color> _colorList = new() { Color.White };
        private BoundaryConditions _conditions;
        private Neighbourhood _neighbourhood;


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
                bool xd = false;
                Task.Factory.StartNew(Run);
                Console.WriteLine(_isRunning);

            }
            else
            {
                buttonRunGg.Text = "Run";
                buttonGenerateGg.Enabled = true;
                buttonSave.Enabled = true;
                buttonPng.Enabled = true;
                if (CheckIfIsFinished())
                {
                    buttonRunMC.Enabled = true;
                    _mc2d = new MonteCarlo2D(_field, _conditions, _neighbourhood);
                }
            }
        }

        private async Task Run()
        {
            while (_isRunning)
            {
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

        private bool CheckIfIsFinished()
        {
            for (int i = 0; i < _field.Length; i++)
            {
                for (int j = 0; j < _field[0].Length; j++)
                {
                    if (_field[i][j] == 0)
                        return false;
                }
            }
            return true;
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
            _conditions = (BoundaryConditions)comboBoxGg.SelectedIndex; 
            _neighbourhood = (Neighbourhood)comboBoxNeigh.SelectedIndex;
            var location = (Location)comboBoxLocation.SelectedIndex;

            for (int i = 0; i < _field.Length; i++)
            {
                _field[i] = new int[width];
                for (int j = 0; j < _field[i].Length; j++)
                {
                    _field[i][j] = 0;
                }
            }
            if (location == GrainAutomatons.Location.Random)
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
            else
            {
                var distanceX = width / _grainAmount;
                var distanceY = height / _grainAmount;
                var grains = 0;
                for (int i = 0; i < _grainAmount; i++)
                {
                    for (int j = 0; j < _grainAmount; j++)
                    {
                        grains++;
                        var random = new Random();
                        Color color;
                        _field[distanceY / 2 + j * distanceY][distanceX / 2 + i * distanceX] = grains;
                        do
                        {
                            color = Color.FromArgb(random.Next(0, 256), random.Next(0, 256), random.Next(0, 256));
                        } while (_colorList.Contains(color));
                        _colorList.Add(color);
                    }
                }
            }

            _gg = new GrainGrowth();
            _ga2d = new GrainAutomaton2D(_field, _gg, _conditions, _neighbourhood);
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

        private void FormGrainGrowth_Load(object sender, EventArgs e)
        {

        }

        private void buttonRunMC_Click(object sender, EventArgs e)
        {
            _isRunningMC = !_isRunningMC;
            if (_isRunningMC)
            {
                buttonGenerateGg.Enabled = false;
                buttonSave.Enabled = false;
                buttonPng.Enabled = false;
                labelSave.Text = string.Empty;
                buttonRunMC.Text = "Stop";
                buttonRunGg.Enabled = false;
                numericUpDownKt.Enabled = false;
                _mc2d._kt = (double)numericUpDownKt.Value;
                Task.Factory.StartNew(RunMC);

            }
            else
            {
                buttonRunGg.Enabled = true;
                buttonRunMC.Text = "Run";
                buttonGenerateGg.Enabled = true;
                buttonSave.Enabled = true;
                buttonPng.Enabled = true;
                numericUpDownKt.Enabled = true;
                GrainToInt();
            }
        }

        private async Task RunMC()
        {
            while (_isRunningMC)
            {
                _grainField = _mc2d.StartOnce(_field);
                GrainToInt();
                Bitmap bitmap;
                if (_field.Length == _grainField[0].Length)
                {
                    bitmap = new Bitmap(500, 500);
                }
                else
                {
                    bitmap = new Bitmap(_grainField[0].Length, _grainField.Length);
                }
                _g = Graphics.FromImage(bitmap);
                _g.InterpolationMode = InterpolationMode.NearestNeighbor;
                _g.PixelOffsetMode = PixelOffsetMode.Half;
                _g.DrawImage(Conversions.ConvertJaggedGrainToBitmap(_grainField, _grainAmount, _colorList), new Rectangle(Point.Empty, bitmap.Size));

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

        private void GrainToInt()
        {
            for (int i = 0; i < _grainField.Length; i++)
            {
                for (int j = 0; j < _grainField[i].Length; j++)
                {
                    _field[i][j] = _grainField[i][j].Value;
                }
            }
        }

        private void numericUpDownWidth_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
