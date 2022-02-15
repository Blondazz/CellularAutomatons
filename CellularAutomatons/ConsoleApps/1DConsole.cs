using System;
using CellularAutomatons.IntAutomatons;
using CellularAutomatons.IO;

namespace CellularAutomatons.ConsoleApps
{
    public class Z4 : IConsole
    {
        private readonly int _height;
        private readonly int _width;
        private readonly int _rule;

        public Z4(int width, int height, int rule)
        {
            _width = width;
            _height = height;
            _rule = rule;
        }

        public void Start()
        {
            int[] input = new int[_width];
            input[_width / 2 - 1] = 1;
            IntCellularAutomaton ca = new IntCellularAutomaton(input, _height, _rule);
            var result = ca.GenerateJaggedArray();
            ImageSaver.Save(result, $"output/cellularAutomaton{_rule}.bmp");
            Console.WriteLine($"Image saved at output/cellularAutomaton{_rule}.bmp");
        }
    }
}