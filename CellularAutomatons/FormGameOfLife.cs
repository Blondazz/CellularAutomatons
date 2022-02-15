using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using CellularAutomatons.IntAutomatons;

namespace CellularAutomatons
{
    public partial class FormGameOfLife : Form
    {
        private bool _isRunning;
        private int[][] _field;
        private GameOfLife _gof = new GameOfLife();
        private IntCellularAutomaton2D _ca2d;
        private Stopwatch _sw = new Stopwatch();
        private Graphics _g;
        public FormGameOfLife()
        {
            InitializeComponent();
            pictureBoxGof.SizeMode = PictureBoxSizeMode.StretchImage;
            
        }

        private void ButtonGofRun_Click(object sender, EventArgs e)
        {
            _isRunning = !_isRunning;
            if (_isRunning)
            {
                ButtonGofReset.Enabled = false;
                ButtonGofRun.Text = "Stop";
                Task.Factory.StartNew(Run);
            }
            else
            {
                ButtonGofRun.Text = "Run";
                ButtonGofReset.Enabled = true;
            }
        }

        private async Task Run()
        {
            while (_isRunning)
            {
                _sw.Reset();
                _sw.Start();
                _field = _ca2d.StartOnce();
                var bitmap = new Bitmap(500, 500);
                _g = Graphics.FromImage(bitmap);
                _g.InterpolationMode = InterpolationMode.NearestNeighbor;
                _g.PixelOffsetMode = PixelOffsetMode.Half;
                _g.DrawImage(Conversions.JaggedArrayBinaryToBitmap(_field), new Rectangle(Point.Empty, bitmap.Size));
                _sw.Stop();
                if (_sw.ElapsedMilliseconds < 60)
                    await Task.Delay((int)(60 - _sw.ElapsedMilliseconds));
                pictureBoxGof.Image = bitmap;
            }
        }

        private void ButtonGofReset_Click(object sender, EventArgs e)
        {
            _isRunning = false;
            ButtonGofRun.Text = "Run";
            var random = new Random();
            ButtonGofRun.Enabled = true;
            int size = (int)numericUpDownGofSize.Value;
            _field = new int[size][];
            for (int i = 0; i < _field.Length; i++)
            {
                _field[i] = new int[size];
                for (int j = 0; j < _field[i].Length; j++)
                {
                    _field[i][j] = random.Next(0, 100) > 50 ? 0 : 1;
                }
            }

            _ca2d = new IntCellularAutomaton2D(_field, 1, _gof);
            var bitmap = new Bitmap(500, 500);
            _g = Graphics.FromImage(bitmap);
            _g.InterpolationMode = InterpolationMode.NearestNeighbor;
            _g.PixelOffsetMode = PixelOffsetMode.Half;
            _g.DrawImage(Conversions.JaggedArrayBinaryToBitmap(_field), new Rectangle(Point.Empty, bitmap.Size));
            pictureBoxGof.Image = bitmap;
        }
    }
}
