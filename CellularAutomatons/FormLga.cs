using CellularAutomatons.Cells;
using CellularAutomatons.LgaAutomaton;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CellularAutomatons
{
    public partial class FormLga : Form
    {
        private bool _isRunning;
        private LgaCell[][] _field;
        private LgaCellularAutomaton _lgaAutomaton;
        private Graphics _g;
        private Random _random = new Random();
        private Stopwatch _sw = new Stopwatch();
        public FormLga()
        {
            InitializeComponent();
            pictureBoxLga.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void FormLga_Load(object sender, EventArgs e)
        {

        }

        private void buttonRunLga_Click(object sender, EventArgs e)
        {
            _isRunning = !_isRunning;
            if (_isRunning)
            {
                buttonGenerateLga.Enabled = false;
                buttonRunLga.Text = "Stop";
                Task.Factory.StartNew(Run);
            }
            else
            {
                buttonRunLga.Text = "Run";
                buttonGenerateLga.Enabled = true;
            }
        }

        private async Task Run()
        {
            while (_isRunning)
            {
                _sw.Reset();
                _sw.Start();
                _field = _lgaAutomaton.StartOnce();
                var bitmap = new Bitmap(500, 500);
                _g = Graphics.FromImage(bitmap);
                _g.InterpolationMode = InterpolationMode.NearestNeighbor;
                _g.PixelOffsetMode = PixelOffsetMode.Half;
                _g.DrawImage(Conversions.ConvertLgaToBitmap(_field), new Rectangle(Point.Empty, bitmap.Size));
                _sw.Stop();
                if (_sw.ElapsedMilliseconds < 17)
                    await Task.Delay((int)(17 - _sw.ElapsedMilliseconds));
                pictureBoxLga.Image = bitmap;
            }
        }

        private void buttonGenerateLga_Click(object sender, EventArgs e)
        {
            _isRunning = false;
            buttonRunLga.Text = "Run";
            buttonRunLga.Enabled = true;
            int size = (int)numericUpDownSizeLga.Value;
            int barrier = (int)(size * ((float)numericUpDownBarrier.Value / 100f));
            int chance = (int)numericUpDownChance.Value;
            int hole = (int)(size / 2f - (0.1 * size));
            _field = new LgaCell[size][];
            for (int i = 0; i < size; i++)
            {
                _field[i] = new LgaCell[size];
                for (int j = 0; j < size; j++)
                {
                    if (j == barrier && (i < hole || i > size - hole))
                        _field[i][j] = null;
                    else
                        _field[i][j] = new LgaCell();
                    if (j < barrier && _random.Next(0, 100) > 100 - chance)
                        _field[i][j].Particles.Add(new Particle(_random.Next(0, 100)));
                }
            }
            _lgaAutomaton = new LgaCellularAutomaton(_field);
            var bitmap = new Bitmap(500, 500);
            _g = Graphics.FromImage(bitmap);
            _g.InterpolationMode = InterpolationMode.NearestNeighbor;
            _g.PixelOffsetMode = PixelOffsetMode.Half;
            _g.DrawImage(Conversions.ConvertLgaToBitmap(_field), new Rectangle(Point.Empty, bitmap.Size));
            pictureBoxLga.Image = bitmap;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
