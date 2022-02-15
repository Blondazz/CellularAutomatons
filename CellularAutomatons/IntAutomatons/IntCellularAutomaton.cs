using System;
using System.Collections;
using System.Linq;

namespace CellularAutomatons.IntAutomatons
{
    public class IntCellularAutomaton
    {
        private readonly int[] _input;
        private readonly int _height;
        private readonly byte[] _ruleBinary;
        public IntCellularAutomaton(int[] input, int height, int rule)
        {
            _input = input;
            _height = height;
            var ruleBitArray = new BitArray(new int[] { rule });
            bool[] boolBitArray = new bool[ruleBitArray.Count];
            ruleBitArray.CopyTo(boolBitArray, 0);
            _ruleBinary = boolBitArray.Take(8).Select(bit => (byte)(bit ? 1 : 0)).ToArray();
            Array.Reverse(_ruleBinary);
        }

        private int[] CreateBorders(int[] input)
        {
            int[] newInput = new int[input.Length + 2];
            newInput[0] = 0;
            newInput[^1] = 0;
            for (int i = 0; i < input.Length; i++)
            {
                newInput[i + 1] = input[i];
            }
            return newInput;
        }

        public int[][] GenerateJaggedArray()
        {
            int[][] result = new int[_height][];
            result[0] = _input;
            int[] input = _input;
            for (int i = 1; i < _height; i++)
            {
                int[] row = new int[_input.Length];
                input = CreateBorders(input);
                for (int j = 1; j < row.Length; j++)
                {
                    row[j - 1] = FindOutput(input, j, _ruleBinary);
                }
                result[i] = row;
                input = row;
            }
            return result;
        }

        private int FindOutput(int[] input, int j, byte[] ruleBinary)
        {
            int a = input[j - 1];
            int b = input[j];
            int c = input[j + 1];

            if (a == 1 && b == 1 && c == 1)
                return ruleBinary[0];
            if (a == 1 && b == 1 && c == 0)
                return ruleBinary[1];
            if (a == 1 && b == 0 && c == 1)
                return ruleBinary[2];
            if (a == 1 && b == 0 && c == 0)
                return ruleBinary[3];
            if (a == 0 && b == 1 && c == 1)
                return ruleBinary[4];
            if (a == 0 && b == 1 && c == 0)
                return ruleBinary[5];
            if (a == 0 && b == 0 && c == 1)
                return ruleBinary[6];
            return ruleBinary[7];
        }
    }
}
