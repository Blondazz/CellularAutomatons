using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CellularAutomatons.IntAutomatons;
using CellularAutomatons.IO;

namespace CellularAutomatons
{
    public partial class Form1D : Form
    {
        public Form1D()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int rule = (int)numericUpDown1DRule.Value;
            int[] input = new int[500];
            input[249] = 1;
            IntCellularAutomaton ca = new IntCellularAutomaton(input, 500, rule);
            var result = ca.GenerateJaggedArray();
            var bitmap = Conversions.JaggedArrayBinaryToBitmap(result);
            pictureBox1D.Image = bitmap;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
