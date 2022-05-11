using System;

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
                if (_neighbourhood == Neighbourhood.VonNeumann)
                {
                    int[] neighbours = new int[4];
                    Index[] jIndexes;
                    Index[] kIndexes;
                    if (_conditions == BoundaryConditions.Periodic)
                    {
                        if (j == 1)
                            jIndexes = new[] {^2, j, j, j + 1};
                        else if (j == newField.Length - 2)
                            jIndexes = new Index[] {j - 1, j, j, 1};
                        else
                            jIndexes = new Index[] {j - 1, j, j, j + 1};

                        if (k == 1)
                            kIndexes = new[] {k, ^2, k + 1, k};
                        else if (k == newField[0].Length - 2)
                            kIndexes = new Index[] {k, k - 1, 1, k};
                        else
                            kIndexes = new Index[] {k, k - 1, k + 1, k};
                    }
                    else
                    {
                        jIndexes = new Index[] {j - 1, j, j, j + 1};
                        kIndexes = new Index[] {k, k - 1, k + 1, k};
                    }

                    field[j - 1][k - 1] = _automaton.FindOutput(newField[j][k],
                        newField[jIndexes[0]][kIndexes[0]],
                        newField[jIndexes[1]][kIndexes[1]],
                        newField[jIndexes[2]][kIndexes[2]],
                        newField[jIndexes[3]][kIndexes[3]]
                    );
                }
                else if (_neighbourhood == Neighbourhood.Moore)
                {
                    int[] neighbours = new int[8];
                    Index[] jIndexes;
                    Index[] kIndexes;
                    if (_conditions == BoundaryConditions.Periodic)
                    {
                        if (j == 1)
                            jIndexes = new[] {^2, ^2, ^2, j, j, j + 1, j + 1, j + 1};
                        else if (j == newField.Length - 2)
                            jIndexes = new Index[] {j - 1, j - 1, j - 1, j, j, 1, 1, 1,};
                        else
                            jIndexes = new Index[] {j - 1, j - 1, j - 1, j, j, j + 1, j + 1, j + 1};

                        if (k == 1)
                            kIndexes = new[] {^2, k, k + 1, ^2, k + 1, ^2, k, k + 1};
                        else if (k == newField[0].Length - 2)
                            kIndexes = new Index[] {k - 1, k, 1, k - 1, 1, k - 1, k, 1};
                        else
                            kIndexes = new Index[] {k - 1, k, k + 1, k - 1, k + 1, k - 1, k, k + 1};
                    }
                    else
                    {
                        jIndexes = new Index[] {j - 1, j - 1, j - 1, j, j, j + 1, j + 1, j + 1};
                        kIndexes = new Index[] {k - 1, k, k + 1, k - 1, k + 1, k - 1, k, k + 1};
                    }

                    field[j - 1][k - 1] = _automaton.FindOutput(newField[j][k],
                        newField[jIndexes[0]][kIndexes[0]],
                        newField[jIndexes[1]][kIndexes[1]],
                        newField[jIndexes[2]][kIndexes[2]],
                        newField[jIndexes[3]][kIndexes[3]],
                        newField[jIndexes[4]][kIndexes[4]],
                        newField[jIndexes[5]][kIndexes[5]],
                        newField[jIndexes[6]][kIndexes[6]],
                        newField[jIndexes[7]][kIndexes[7]]
                    );
                }
                else if (_neighbourhood == Neighbourhood.Pentagonal)
                {
                    int[] neighbours = new int[5];
                    Index[] jIndexes;
                    Index[] kIndexes;
                    int direction = _r.Next(0, 4); //LURD

                    if (_conditions == BoundaryConditions.Periodic)
                    {
                        if (direction == 0)
                        {
                            if (j == 1)
                                jIndexes = new[] {^2, ^2, j, j + 1, j + 1};
                            else if (j == newField.Length - 2)
                                jIndexes = new Index[] {j - 1, j - 1, j, 1, 1};
                            else
                                jIndexes = new Index[] {j - 1, j - 1, j, j + 1, j + 1};

                            if (k == 1)
                                kIndexes = new[] {k, ^2, ^2, ^2, k};
                            else
                                kIndexes = new Index[] {k, k - 1, k - 1, k - 1, k};
                        }
                        else if (direction == 1)
                        {
                            if (j == 1)
                                jIndexes = new[] {^2, ^2, ^2, j, j};
                            else
                                jIndexes = new Index[] {j - 1, j - 1, j - 1, j, j};

                            if (k == 1)
                                kIndexes = new[] {^2, k, k + 1, ^2, k + 1};
                            else if (k == newField[0].Length - 2)
                                kIndexes = new Index[] {k - 1, k, 1, k - 1, 1};
                            else
                                kIndexes = new Index[] {k - 1, k, k + 1, k - 1, k + 1};
                        }
                        else if (direction == 2)
                        {
                            if (j == 1)
                                jIndexes = new[] {^2, ^2, j, j + 1, j + 1};
                            else if (j == newField.Length - 2)
                                jIndexes = new Index[] {j - 1, j - 1, j, 1, 1};
                            else
                                jIndexes = new Index[] {j - 1, j - 1, j, j + 1, j + 1};

                            if (k == newField[0].Length - 2)
                                kIndexes = new Index[] {k, 1, 1, k, 1};
                            else
                                kIndexes = new Index[] {k, k + 1, k + 1, k, k + 1};
                        }
                        else
                        {
                            if (j == newField.Length - 2)
                                jIndexes = new Index[] {j, j, 1, 1, 1};
                            else
                                jIndexes = new Index[] {j, j, j + 1, j + 1, j + 1};

                            if (k == 1)
                                kIndexes = new[] {^2, k + 1, ^2, k, k + 1};
                            else if (k == newField[0].Length - 2)
                                kIndexes = new Index[] {k - 1, 1, k - 1, k, 1};
                            else
                                kIndexes = new Index[] {k - 1, k + 1, k - 1, k, k + 1};
                        }

                    }
                    else
                    {
                        if (direction == 0)
                        {
                            jIndexes = new Index[] {j - 1, j - 1, j, j + 1, j + 1};
                            kIndexes = new Index[] {k, k - 1, k - 1, k - 1, k};
                        }
                        else if (direction == 1)
                        {
                            jIndexes = new Index[] {j - 1, j - 1, j - 1, j, j};
                            kIndexes = new Index[] {k - 1, k, k + 1, k - 1, k + 1};
                        }
                        else if (direction == 2)
                        {
                            jIndexes = new Index[] {j - 1, j - 1, j, j + 1, j + 1};
                            kIndexes = new Index[] {k, k + 1, k + 1, k, k + 1};
                        }
                        else
                        {
                            jIndexes = new Index[] {j, j, j + 1, j + 1, j + 1};
                            kIndexes = new Index[] {k - 1, k + 1, k - 1, k, k + 1};
                        }

                    }

                    field[j - 1][k - 1] = _automaton.FindOutput(newField[j][k],
                        newField[jIndexes[0]][kIndexes[0]],
                        newField[jIndexes[1]][kIndexes[1]],
                        newField[jIndexes[2]][kIndexes[2]],
                        newField[jIndexes[3]][kIndexes[3]],
                        newField[jIndexes[4]][kIndexes[4]]
                    );
                }
                else if (_neighbourhood == Neighbourhood.Hexagonal)
                {
                    int[] neighbours = new int[6];
                    Index[] jIndexes;
                    Index[] kIndexes;
                    int direction = _r.Next(0, 2); // / \
                    if (_conditions == BoundaryConditions.Periodic)
                    {
                        if (direction == 0)
                        {
                            if (j == 1)
                                jIndexes = new[] {^2, ^2, j, j, j + 1, j + 1};
                            else if (j == newField.Length - 2)
                                jIndexes = new Index[] {j - 1, j - 1, j, j, 1, 1};
                            else
                                jIndexes = new Index[] {j - 1, j - 1, j, j, j + 1, j + 1};

                            if (k == 1)
                                kIndexes = new[] {k, k + 1, ^2, k + 1, ^2, k};
                            else if (k == newField[0].Length - 2)
                                kIndexes = new Index[] {k, 1, k - 1, 1, k - 1, k};
                            else
                                kIndexes = new Index[] {k, k + 1, k - 1, k + 1, k - 1, k};
                        }
                        else
                        {
                            if (j == 1)
                                jIndexes = new[] {^2, ^2, j, j, j + 1, j + 1};
                            else if (j == newField.Length - 2)
                                jIndexes = new Index[] {j - 1, j - 1, j, j, 1, 1};
                            else
                                jIndexes = new Index[] {j - 1, j - 1, j, j, j + 1, j + 1};

                            if (k == 1)
                                kIndexes = new[] {^2, k, ^2, k + 1, k, k + 1};
                            else if (k == newField[0].Length - 2)
                                kIndexes = new Index[] {k - 1, k, k - 1, 1, k, 1};
                            else
                                kIndexes = new Index[] {k - 1, k, k - 1, k + 1, k, k + 1};
                        }
                    }
                    else
                    {
                        if (direction == 0)
                        {
                            jIndexes = new Index[] {j - 1, j - 1, j, j, j + 1, j + 1};
                            kIndexes = new Index[] {k, k + 1, k - 1, k + 1, k - 1, k};
                        }
                        else
                        {
                            jIndexes = new Index[] {j - 1, j - 1, j, j, j + 1, j + 1};
                            kIndexes = new Index[] {k - 1, k, k - 1, k + 1, k, k + 1};
                        }
                    }

                    field[j - 1][k - 1] = _automaton.FindOutput(newField[j][k],
                        newField[jIndexes[0]][kIndexes[0]],
                        newField[jIndexes[1]][kIndexes[1]],
                        newField[jIndexes[2]][kIndexes[2]],
                        newField[jIndexes[3]][kIndexes[3]],
                        newField[jIndexes[4]][kIndexes[4]],
                        newField[jIndexes[5]][kIndexes[5]]
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

