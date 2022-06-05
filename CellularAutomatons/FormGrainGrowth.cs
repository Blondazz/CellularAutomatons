using CellularAutomatons.GrainAutomatons;
using CellularAutomatons.IO;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using CellularAutomatons.Enums;
using CellularAutomatons.Extensions;
using CellularAutomatons.MonteCarlo;


namespace CellularAutomatons
{
    public partial class FormGrainGrowth : Form
    {
        private bool _isRunning;
        private bool _isRunningMC;
        private bool _isRunningSRX;
        private int[][] _field;
        private Grain[][] _grainField;
        private int _grainAmount;
        private GrainGrowth _gg;
        private GrainAutomaton2D _ga2d;
        private MonteCarlo2D _mc2d;
        private Srx _srx;
        private Stopwatch _sw = new();
        private Graphics _g;
        private List<Color> _colorList = new() { Color.White };
        private List<Color> _recrystColorList = new() { Color.White };
        private BoundaryConditions _conditions;
        private Neighbourhood _neighbourhood;
        private NEnum _NType = 0;
        private TypeEnum _type = 0;
        private int _recrystallized = -1;
        private int[][] _structureField;


        public FormGrainGrowth()
        {
            InitializeComponent();
            pictureBoxGg.SizeMode = PictureBoxSizeMode.Normal;
            comboBoxGg.SelectedIndex = 1;
            comboBoxNeigh.SelectedIndex = 0;
            comboBoxLocation.SelectedIndex = 0;
            comboBoxN.SelectedIndex = 0;
            comboBoxType.SelectedIndex = 0;
        }

        private void buttonRunGg_Click(object sender, EventArgs e)
        {
            _isRunning = !_isRunning;
            if (_isRunning)
            {
                buttonGenerateGg.Enabled = false;
                buttonSave.Enabled = false;
                buttonPng.Enabled = false;
                buttonRunMC.Enabled = false;
                buttonRunSRX.Enabled = false;
                checkBoxEnergy.Enabled = false;
                checkBoxEnergy.Checked = false;
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
                if(_type == TypeEnum.Normal)
                    _g.DrawImage(Conversions.ConvertJaggedGrainToBitmap(_field, _grainAmount, _colorList), new Rectangle(Point.Empty, bitmap.Size));
                else
                    _g.DrawImage(Conversions.ConvertJaggedGrainToBitmapWithStruct(_field, _structureField, _grainAmount, _colorList), new Rectangle(Point.Empty, bitmap.Size));
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
            _neighbourhood = (Neighbourhood)comboBoxNeigh.SelectedIndex;
            _type = (TypeEnum) comboBoxType.SelectedIndex;
            if (_type == TypeEnum.Image)
            {
                _structureField = ImageReader.ReadGrainData(width, height);
                comboBoxGg.SelectedIndex = 0;
                comboBoxGg.Enabled = false;
            }
            _conditions = (BoundaryConditions)comboBoxGg.SelectedIndex;

            var location = (Location)comboBoxLocation.SelectedIndex;

            for (int i = 0; i < _field.Length; i++)
            {
                _field[i] = new int[width];
                for (int j = 0; j < _field[i].Length; j++)
                {
                    _field[i][j] = 0;
                }
            }
            if (location == Enums.Location.Random)
                if(_type == TypeEnum.Normal)
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
                            color = Color.FromArgb(0, random.Next(0, 256), random.Next(0, 256));
                        } while (_colorList.Contains(color));
                        _colorList.Add(color);
                    }
                else
                {
                    for (int i = 0; i < _grainAmount; i++)
                    {
                        var random = new Random();
                        int x, y;
                        Color color;
                        do
                        {
                            x = random.Next(0, height);
                            y = random.Next(0, width);
                        } while (_field[x][y] != 0 || _structureField[x][y] == 0);
                        _field[x][y] = i + 1;
                        do
                        {
                            color = Color.FromArgb(0, random.Next(0, 256), random.Next(0, 256));
                        } while (_colorList.Contains(color));
                        _colorList.Add(color);
                    }
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
                        if(_type == TypeEnum.Image)
                            if(_structureField[distanceY / 2 + j * distanceY][distanceX / 2 + i * distanceX] == 1)
                                _field[distanceY / 2 + j * distanceY][distanceX / 2 + i * distanceX] = grains;
                        if(_type == TypeEnum.Normal)
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
            if (_type == TypeEnum.Normal)
                _g.DrawImage(Conversions.ConvertJaggedGrainToBitmap(_field, _grainAmount, _colorList), new Rectangle(Point.Empty, bitmap.Size));
            else
                _g.DrawImage(Conversions.ConvertJaggedGrainToBitmapWithStruct(_field, _structureField, _grainAmount, _colorList), new Rectangle(Point.Empty, bitmap.Size));
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
            if (_type == TypeEnum.Normal)
                _g.DrawImage(Conversions.ConvertJaggedGrainToBitmap(_field, _grainAmount, _colorList), new Rectangle(Point.Empty, bitmap.Size));
            else
                _g.DrawImage(Conversions.ConvertJaggedGrainToBitmapWithStruct(_field, _structureField, _grainAmount, _colorList), new Rectangle(Point.Empty, bitmap.Size));
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
                checkBoxEnergy.Enabled = true;
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
                buttonRunSRX.Enabled = true;
                GrainToInt();
                _srx = new Srx(_field, _conditions, _neighbourhood, _type, _structureField);
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
                if(_type == TypeEnum.Normal)
                    _g.DrawImage(
                        !checkBoxEnergy.Checked
                            ? Conversions.ConvertJaggedGrainToBitmap(_grainField, _grainAmount, _colorList)
                            : Conversions.ConvertJaggedGrainEnergyToBitmap(_grainField),
                        new Rectangle(Point.Empty, bitmap.Size));
                else
                    _g.DrawImage(
                        !checkBoxEnergy.Checked
                            ? Conversions.ConvertJaggedGrainToBitmapWithStruct(_grainField, _structureField, _grainAmount, _colorList)
                            : Conversions.ConvertJaggedGrainEnergyToBitmapWithStruct(_grainField, _structureField),
                        new Rectangle(Point.Empty, bitmap.Size));
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

        private void buttonRunSRX_Click(object sender, EventArgs e)
        {
            _isRunningSRX = !_isRunningSRX;
            if (_isRunningSRX)
            {
                buttonGenerateGg.Enabled = false;
                buttonSave.Enabled = false;
                buttonPng.Enabled = false;
                labelSave.Text = string.Empty;
                buttonRunSRX.Text = "Stop";
                buttonRunGg.Enabled = false;
                buttonRunMC.Enabled = false;
                numericUpDownKt.Enabled = false;
                _srx.BorderH = (int)numericUpDownBorderEnergy.Value;
                _srx.MiddleH = (int)numericUpDownCenterEnergy.Value;
                Task.Factory.StartNew(RunSRX);

            }
            else
            {
                buttonRunGg.Enabled = true;
                buttonRunMC.Enabled = true;
                buttonRunSRX.Text = "Run";
                buttonGenerateGg.Enabled = true;
                buttonSave.Enabled = true;
                buttonPng.Enabled = true;
                numericUpDownKt.Enabled = true;
                buttonRunSRX.Enabled = true;
                GrainToInt();
            }
        }

        private async Task RunSRX()
        {
            try
            {
                var iterations = 0;
                var newGrains = (int)numericUpDownSRXAmount.Value;
                AddGrains(newGrains);
                while (_isRunningSRX)
                {
                    if(_NType == NEnum.Frames)
                        if (iterations % (int) numericUpDownSRXFrames.Value == 0 && !CheckIfSrxFinished())
                        {
                            AddGrains(newGrains);
                        }
                    _grainField = _srx.StartOnce(_field);
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
                    if(_type == TypeEnum.Normal)
                        _g.DrawImage(Conversions.ConvertJaggedGrainToBitmapSRX(_grainField, _grainAmount, _colorList, _recrystColorList), new Rectangle(Point.Empty, bitmap.Size));
                    else
                        _g.DrawImage(Conversions.ConvertJaggedGrainToBitmapSRXWithStruct(_grainField, _structureField, _grainAmount, _colorList, _recrystColorList), new Rectangle(Point.Empty, bitmap.Size));

                    try
                    {
                        pictureBoxGg.Image = bitmap;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                        throw;
                    }

                    iterations++;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        private void AddGrains(int amount)
        {
            var grainList = new List<Grain>();
            foreach (var grainRow in _grainField)
            {
                grainList.AddRange(grainRow);
            }
            grainList = grainList.Where(g => g.Value >0).ToList();
            grainList.Shuffle();
            if(_type == TypeEnum.Image)
                grainList.RemoveAll(x => _structureField[x.X][x.Y] == 0);
            if (grainList.Count < amount)
                return;
            for (int i = 0; i < amount; i++)
            {
                var random = new Random();
                Color color;
                grainList[i].IsRecrystallized = true;
                grainList[i].Value = _recrystallized;
                _field[grainList[i].X][grainList[i].Y] = _recrystallized;
                _recrystallized--;
                do
                {
                    color = Color.FromArgb(random.Next(0, 256), 0, random.Next(0, 256));
                } while (_recrystColorList.Contains(color));
                _recrystColorList.Add(color);
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

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void comboBoxN_SelectedIndexChanged(object sender, EventArgs e)
        {
            _NType = (NEnum)comboBoxN.SelectedIndex;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
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
            if (_type == TypeEnum.Normal)
                _g.DrawImage(
                    !checkBoxEnergy.Checked
                        ? Conversions.ConvertJaggedGrainToBitmap(_grainField, _grainAmount, _colorList)
                        : Conversions.ConvertJaggedGrainEnergyToBitmap(_grainField),
                    new Rectangle(Point.Empty, bitmap.Size));
            else
                _g.DrawImage(
                    !checkBoxEnergy.Checked
                        ? Conversions.ConvertJaggedGrainToBitmapWithStruct(_grainField, _structureField, _grainAmount, _colorList)
                        : Conversions.ConvertJaggedGrainEnergyToBitmapWithStruct(_grainField, _structureField),
                    new Rectangle(Point.Empty, bitmap.Size));

            try
            {
                pictureBoxGg.Image = bitmap;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        private bool CheckIfSrxFinished()
        {
            for (int i = 0; i < _field.Length; i++)
            {
                for (int j = 0; j < _field[i].Length; j++)
                {
                    if (_field[i][j] > 0)
                        return false;
                }
            }

            return true;
        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            comboBoxGg.Enabled = true;
        }
    }
}
