
using System;
using CellularAutomatons.Enums;
using CellularAutomatons.GrainAutomatons;

namespace CellularAutomatons.Helpers
{
    public static class NeighbourhoodHelper
    {
        private static Random rng = new();
        public static (Index[], Index[]) GetNeighbours(int j, int k, Neighbourhood neighbourhood,
            BoundaryConditions conditions, int[][] field)
        {
            Index[] jIndexes = new Index[1];
            Index[] kIndexes = new Index[1];
            if (neighbourhood == Neighbourhood.VonNeumann)
            {
                if (conditions == BoundaryConditions.Periodic)
                {
                    if (j == 1)
                        jIndexes = new[] { ^2, j, j, j + 1 };
                    else if (j == field.Length - 2)
                        jIndexes = new Index[] { j - 1, j, j, 1 };
                    else
                        jIndexes = new Index[] { j - 1, j, j, j + 1 };

                    if (k == 1)
                        kIndexes = new[] { k, ^2, k + 1, k };
                    else if (k == field[0].Length - 2)
                        kIndexes = new Index[] { k, k - 1, 1, k };
                    else
                        kIndexes = new Index[] { k, k - 1, k + 1, k };
                }
                else
                {
                    jIndexes = new Index[] { j - 1, j, j, j + 1 };
                    kIndexes = new Index[] { k, k - 1, k + 1, k };
                }
            }
            else if (neighbourhood == Neighbourhood.Moore)
            {
                if (conditions == BoundaryConditions.Periodic)
                {
                    if (j == 1)
                        jIndexes = new[] { ^2, ^2, ^2, j, j, j + 1, j + 1, j + 1 };
                    else if (j == field.Length - 2)
                        jIndexes = new Index[] { j - 1, j - 1, j - 1, j, j, 1, 1, 1, };
                    else
                        jIndexes = new Index[] { j - 1, j - 1, j - 1, j, j, j + 1, j + 1, j + 1 };

                    if (k == 1)
                        kIndexes = new[] { ^2, k, k + 1, ^2, k + 1, ^2, k, k + 1 };
                    else if (k == field[0].Length - 2)
                        kIndexes = new Index[] { k - 1, k, 1, k - 1, 1, k - 1, k, 1 };
                    else
                        kIndexes = new Index[] { k - 1, k, k + 1, k - 1, k + 1, k - 1, k, k + 1 };
                }
                else
                {
                    jIndexes = new Index[] { j - 1, j - 1, j - 1, j, j, j + 1, j + 1, j + 1 };
                    kIndexes = new Index[] { k - 1, k, k + 1, k - 1, k + 1, k - 1, k, k + 1 };
                }
            }
            else if (neighbourhood == Neighbourhood.Pentagonal)
            {
                int direction = rng.Next(0, 4); //LURD

                if (conditions == BoundaryConditions.Periodic)
                {
                    if (direction == 0)
                    {
                        if (j == 1)
                            jIndexes = new[] { ^2, ^2, j, j + 1, j + 1 };
                        else if (j == field.Length - 2)
                            jIndexes = new Index[] { j - 1, j - 1, j, 1, 1 };
                        else
                            jIndexes = new Index[] { j - 1, j - 1, j, j + 1, j + 1 };

                        if (k == 1)
                            kIndexes = new[] { k, ^2, ^2, ^2, k };
                        else
                            kIndexes = new Index[] { k, k - 1, k - 1, k - 1, k };
                    }
                    else if (direction == 1)
                    {
                        if (j == 1)
                            jIndexes = new[] { ^2, ^2, ^2, j, j };
                        else
                            jIndexes = new Index[] { j - 1, j - 1, j - 1, j, j };

                        if (k == 1)
                            kIndexes = new[] { ^2, k, k + 1, ^2, k + 1 };
                        else if (k == field[0].Length - 2)
                            kIndexes = new Index[] { k - 1, k, 1, k - 1, 1 };
                        else
                            kIndexes = new Index[] { k - 1, k, k + 1, k - 1, k + 1 };
                    }
                    else if (direction == 2)
                    {
                        if (j == 1)
                            jIndexes = new[] { ^2, ^2, j, j + 1, j + 1 };
                        else if (j == field.Length - 2)
                            jIndexes = new Index[] { j - 1, j - 1, j, 1, 1 };
                        else
                            jIndexes = new Index[] { j - 1, j - 1, j, j + 1, j + 1 };

                        if (k == field[0].Length - 2)
                            kIndexes = new Index[] { k, 1, 1, k, 1 };
                        else
                            kIndexes = new Index[] { k, k + 1, k + 1, k, k + 1 };
                    }
                    else
                    {
                        if (j == field.Length - 2)
                            jIndexes = new Index[] { j, j, 1, 1, 1 };
                        else
                            jIndexes = new Index[] { j, j, j + 1, j + 1, j + 1 };

                        if (k == 1)
                            kIndexes = new[] { ^2, k + 1, ^2, k, k + 1 };
                        else if (k == field[0].Length - 2)
                            kIndexes = new Index[] { k - 1, 1, k - 1, k, 1 };
                        else
                            kIndexes = new Index[] { k - 1, k + 1, k - 1, k, k + 1 };
                    }

                }

                else
                {
                    if (direction == 0)
                    {
                        jIndexes = new Index[] { j - 1, j - 1, j, j + 1, j + 1 };
                        kIndexes = new Index[] { k, k - 1, k - 1, k - 1, k };
                    }
                    else if (direction == 1)
                    {
                        jIndexes = new Index[] { j - 1, j - 1, j - 1, j, j };
                        kIndexes = new Index[] { k - 1, k, k + 1, k - 1, k + 1 };
                    }
                    else if (direction == 2)
                    {
                        jIndexes = new Index[] { j - 1, j - 1, j, j + 1, j + 1 };
                        kIndexes = new Index[] { k, k + 1, k + 1, k, k + 1 };
                    }
                    else
                    {
                        jIndexes = new Index[] { j, j, j + 1, j + 1, j + 1 };
                        kIndexes = new Index[] { k - 1, k + 1, k - 1, k, k + 1 };
                    }

                }
            }
            else if (neighbourhood == Neighbourhood.Hexagonal)
            {
                int direction = rng.Next(0, 2); // / \
                if (conditions == BoundaryConditions.Periodic)
                {
                    if (direction == 0)
                    {
                        if (j == 1)
                            jIndexes = new[] {^2, ^2, j, j, j + 1, j + 1};
                        else if (j == field.Length - 2)
                            jIndexes = new Index[] {j - 1, j - 1, j, j, 1, 1};
                        else
                            jIndexes = new Index[] {j - 1, j - 1, j, j, j + 1, j + 1};

                        if (k == 1)
                            kIndexes = new[] {k, k + 1, ^2, k + 1, ^2, k};
                        else if (k == field[0].Length - 2)
                            kIndexes = new Index[] {k, 1, k - 1, 1, k - 1, k};
                        else
                            kIndexes = new Index[] {k, k + 1, k - 1, k + 1, k - 1, k};
                    }
                    else
                    {
                        if (j == 1)
                            jIndexes = new[] {^2, ^2, j, j, j + 1, j + 1};
                        else if (j == field.Length - 2)
                            jIndexes = new Index[] {j - 1, j - 1, j, j, 1, 1};
                        else
                            jIndexes = new Index[] {j - 1, j - 1, j, j, j + 1, j + 1};

                        if (k == 1)
                            kIndexes = new[] {^2, k, ^2, k + 1, k, k + 1};
                        else if (k == field[0].Length - 2)
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
            }

            return (jIndexes, kIndexes);
        }
    }
}
