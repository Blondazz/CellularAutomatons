using System;
using System.Collections.Generic;
using System.Linq;

namespace CellularAutomatons.IntAutomatons
{
    public class IntCellularAutomaton2D
    {
        private readonly int[][] _field;
        private readonly int _iterations;
        private readonly IIntAutomaton _automaton;

        public IntCellularAutomaton2D(int[][] field, int iterations, IIntAutomaton automaton)
        {
            _field = field;
            _iterations = iterations;
            _automaton = automaton;
        }

        public List<int[][]> Start()
        {
            int[][] field = _field;
            int[][] newField = AddBordersToField(field);
            List<int[][]> fieldList = new();

            Console.WriteLine("Input:");
            // Print(field);

            for (int i = 0; i < _iterations; i++)
            {
                for (int j = 1; j < newField.Length - 1; j++)
                {
                    for (int k = 1; k < newField[0].Length - 1; k++)
                    {
                        field[j - 1][k - 1] = _automaton.FindOutput(newField[j][k],
                            newField[j - 1][k - 1],
                            newField[j - 1][k],
                            newField[j - 1][k + 1],
                            newField[j][k - 1],
                            newField[j][k + 1],
                            newField[j + 1][k - 1],
                            newField[j + 1][k],
                            newField[j + 1][k + 1]
                        );

                    }
                }
                //Print(field);
                fieldList.Add(field.Select(s => s.ToArray()).ToArray());

                newField = AddBordersToField(field);
            }

            return fieldList;
        }

        public int[][] StartOnce()
        {
            int[][] field = _field;
            int[][] newField = AddBordersToField(field);



            for (int j = 1; j < newField.Length - 1; j++)
            {
                CalculateRow(newField, field, j);
            }


            return field;
        }

        private void CalculateRow(int[][] newField, int[][] field, int j)
        {
            for (int k = 1; k < newField[0].Length - 1; k++)
            {
                field[j - 1][k - 1] = _automaton.FindOutput(newField[j][k],
                    newField[j - 1][k - 1],
                    newField[j - 1][k],
                    newField[j - 1][k + 1],
                    newField[j][k - 1],
                    newField[j][k + 1],
                    newField[j + 1][k - 1],
                    newField[j + 1][k],
                    newField[j + 1][k + 1]
                );
            }
        }

        /// <summary>
        /// returns an array which is the parameter array but surrounded with zeroes 
        /// </summary>
        /// <param name="field"></param>
        /// <returns></returns>
        private int[][] AddBordersToField(int[][] field)
        {
            int[][] newField = new int[field.Length + 2][];
            newField[0] = new int[field[0].Length + 2];
            newField[^1] = new int[field[0].Length + 2];
            for (int i = 0; i < newField.Length - 2; i++)
            {
                newField[i + 1] = new int[field[0].Length + 2];
                for (int j = 0; j < newField[0].Length; j++)
                {
                    if (!(j == 0 || j == newField[0].Length - 1))
                    {
                        newField[i + 1][j] = field[i][j - 1];
                    }
                }
            }
            return newField;
        }
        private void Print(int[][] field)
        {
            for (int j = 0; j < field.Length; j++)
            {
                for (int k = 0; k < field[0].Length; k++)
                {
                    Console.Write(field[j][k]);
                }

                Console.Write('\n');
            }
            Console.WriteLine('\n');
        }
    }
}