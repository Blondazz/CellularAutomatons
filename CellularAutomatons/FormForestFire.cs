using CellularAutomatons.IntAutomatons;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CellularAutomatons
{
    public partial class FormForestFire : Form
    {
        private bool _isRunning;
        private int[][] _field;
        private ForestFire _ff;
        private IntCellularAutomaton2D _ca2d;
        private Stopwatch _sw = new Stopwatch();
        private Graphics _g;
        public FormForestFire()
        {
            InitializeComponent();
            pictureBoxFF.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void buttonRunFF_Click(object sender, EventArgs e)
        {
            _isRunning = !_isRunning;
            if (_isRunning)
            {
                buttonGenerateFF.Enabled = false;
                buttonRunFF.Text = "Stop";
                Task.Factory.StartNew(Run);
            }
            else
            {
                buttonRunFF.Text = "Run";
                buttonGenerateFF.Enabled = true;
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
                _g.DrawImage(Conversions.ConvertJaggedForestFireToBitmap(_field), new Rectangle(Point.Empty, bitmap.Size));
                _sw.Stop();
                if (_sw.ElapsedMilliseconds < 60)
                    await Task.Delay((int)(60 - _sw.ElapsedMilliseconds));
                pictureBoxFF.Image = bitmap;
            }
        }
        private void buttonGenerateFF_Click(object sender, EventArgs e)
        {
            _isRunning = false;
            buttonRunFF.Text = "Run";
            var random = new Random();
            buttonRunFF.Enabled = true;
            int size = (int)numericUpDowSizeFF.Value;
            _field = new int[size][];

            for (int i = 0; i < _field.Length; i++)
            {
                _field[i] = new int[size];
                for (int j = 0; j < _field[i].Length; j++)
                {
                    _field[i][j] = checkBoxRandomFF.Checked ? (random.Next(0, 100) > 50 ? 0 : 1) : 1;
                }
            }

            int ignitionProbability = (int)numericUpDownIgnition.Value;
            int spontaneousIgnitionProbability = (int)numericUpDownSpontaneous.Value;
            int growthProbability = (int)numericUpDownGrowth.Value;
            _ff = new ForestFire(ignitionProbability, spontaneousIgnitionProbability, growthProbability);
            _ca2d = new IntCellularAutomaton2D(_field, 1, _ff);
            var bitmap = new Bitmap(500, 500);
            _g = Graphics.FromImage(bitmap);
            _g.InterpolationMode = InterpolationMode.NearestNeighbor;
            _g.PixelOffsetMode = PixelOffsetMode.Half;
            _g.DrawImage(Conversions.ConvertJaggedForestFireToBitmap(_field), new Rectangle(Point.Empty, bitmap.Size));
            pictureBoxFF.Image = bitmap;
        }

        private void radioButtonRandom_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
