using System;
using CellularAutomatons.Helpers;

namespace CellularAutomatons.GrainAutomatons
{
    public class GrainAutomaton2D
    {
        private readonly int[][] _field;
        private readonly IGrainAutomaton _automaton;
        private readonly BoundaryConditions _conditions;
        private readonly Neighbourhood _neighbourhood;
        private Random _r = new Random();

        public GrainAutomaton2D(int[][] field, IGrainAutomaton automaton,
            BoundaryConditions conditions, Neighbourhood neighbourhood)
        {
            _field = field;
            _automaton = automaton;
            _conditions = conditions;
            _neighbourhood = neighbourhood;
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
                var indexes = NeighbourhoodHelper.GetNeighbours(j, k, _neighbourhood, _conditions, _field);
                if (_neighbourhood == Neighbourhood.VonNeumann)
                {
                    field[j - 1][k - 1] = _automaton.FindOutput(newField[j][k],
                        newField[indexes.Item1[0]][indexes.Item2[0]],
                        newField[indexes.Item1[1]][indexes.Item2[1]],
                        newField[indexes.Item1[2]][indexes.Item2[2]],
                        newField[indexes.Item1[3]][indexes.Item2[3]]
                    );
                }
                else if (_neighbourhood == Neighbourhood.Moore)
                {
                    field[j - 1][k - 1] = _automaton.FindOutput(newField[j][k],
                        newField[indexes.Item1[0]][indexes.Item2[0]],
                        newField[indexes.Item1[1]][indexes.Item2[1]],
                        newField[indexes.Item1[2]][indexes.Item2[2]],
                        newField[indexes.Item1[3]][indexes.Item2[3]],
                        newField[indexes.Item1[4]][indexes.Item2[4]],
                        newField[indexes.Item1[5]][indexes.Item2[5]],
                        newField[indexes.Item1[6]][indexes.Item2[6]],
                        newField[indexes.Item1[7]][indexes.Item2[7]]
                    );
                }
                else if (_neighbourhood == Neighbourhood.Pentagonal)
                {
                    field[j - 1][k - 1] = _automaton.FindOutput(newField[j][k],
                        newField[indexes.Item1[0]][indexes.Item2[0]],
                        newField[indexes.Item1[1]][indexes.Item2[1]],
                        newField[indexes.Item1[2]][indexes.Item2[2]],
                        newField[indexes.Item1[3]][indexes.Item2[3]],
                        newField[indexes.Item1[4]][indexes.Item2[4]]
                    );
                }
                else if (_neighbourhood == Neighbourhood.Hexagonal)
                {
                    
                    field[j - 1][k - 1] = _automaton.FindOutput(newField[j][k],
                        newField[indexes.Item1[0]][indexes.Item2[0]],
                        newField[indexes.Item1[1]][indexes.Item2[1]],
                        newField[indexes.Item1[2]][indexes.Item2[2]],
                        newField[indexes.Item1[3]][indexes.Item2[3]],
                        newField[indexes.Item1[4]][indexes.Item2[4]],
                        newField[indexes.Item1[5]][indexes.Item2[5]]
                    );
                }
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

