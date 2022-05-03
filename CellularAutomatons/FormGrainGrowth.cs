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
        private GrainGrowth _gg;
        private GrainAutomaton2D _ga2d;
        private Stopwatch _sw = new Stopwatch();
        private Graphics _g; 
        private List<Color> _colorList = new() {Color.White};
        

        public FormGrainGrowth()
        {
            InitializeComponent();
            pictureBoxGg.SizeMode = PictureBoxSizeMode.StretchImage;
            comboBoxGg.SelectedIndex = 1;
        }

        private void buttonRunGg_Click(object sender, EventArgs e)
        {
            _isRunning = !_isRunning;
            if (_isRunning)
            {
                buttonGenerateGg.Enabled = false;
                buttonSave.Enabled = false;
                labelSave.Text = string.Empty;
                buttonRunGg.Text = "Stop";
                Task.Factory.StartNew(Run);

            }
            else
            {
                buttonRunGg.Text = "Run";
                buttonGenerateGg.Enabled = true;
                buttonSave.Enabled = true;

            }
        }
        private async Task Run()
        {
            while (_isRunning)
            {
                _sw.Reset();
                _sw.Start();
                _field = _ga2d.StartOnce();
                var bitmap = new Bitmap(500, 500);
                _g = Graphics.FromImage(bitmap);
                _g.InterpolationMode = InterpolationMode.NearestNeighbor;
                _g.PixelOffsetMode = PixelOffsetMode.Half;
                int grainAmount = (int)numericUpDownGrains.Value;
                _g.DrawImage(Conversions.ConvertJaggedGrainToBitmap(_field, grainAmount, _colorList), new Rectangle(Point.Empty, bitmap.Size));
                _sw.Stop();
                //if (_sw.ElapsedMilliseconds < 60)
                //    await Task.Delay((int)(60 - _sw.ElapsedMilliseconds));
                pictureBoxGg.Image = bitmap;
            }
        }
        private void buttonGenerateGg_Click(object sender, EventArgs e)
        {
            _isRunning = false;
            buttonRunGg.Text = "Run";
            labelSave.Text = string.Empty;
            var random = new Random();
            buttonRunGg.Enabled = true;
            buttonSave.Enabled = true;
            int size = (int)numericUpDownSizeGg.Value;
            _field = new int[size][];
            int grainAmount = (int)numericUpDownGrains.Value;
            var condition = (BoundaryConditions) comboBoxGg.SelectedIndex;

            for (int i = 0; i < _field.Length; i++)
            {
                _field[i] = new int[size];
                for (int j = 0; j < _field[i].Length; j++)
                {
                    _field[i][j] = 0;
                }
            }

            for (int i = 0; i < grainAmount; i++)
            {
                _field[random.Next(0, size)][random.Next(0, size)] = i + 1;
                _colorList.Add(Color.FromArgb(random.Next(0, 256), random.Next(0, 256), random.Next(0, 256)));
            }

            _gg = new GrainGrowth();
            _ga2d = new GrainAutomaton2D(_field, 1, _gg, condition);
            var bitmap = new Bitmap(500, 500);
            _g = Graphics.FromImage(bitmap);
            _g.InterpolationMode = InterpolationMode.NearestNeighbor;
            _g.PixelOffsetMode = PixelOffsetMode.Half;
            _g.DrawImage(Conversions.ConvertJaggedGrainToBitmap(_field, grainAmount, _colorList), new Rectangle(Point.Empty, bitmap.Size));
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
    }
}
