using System;
using System.Collections.Generic;
using CellularAutomatons.Enums;
using CellularAutomatons.Extensions;
using CellularAutomatons.GrainAutomatons;
using CellularAutomatons.Helpers;

namespace CellularAutomatons.MonteCarlo
{
    public class Srx
    {
        private readonly int[][] _field;
        private Grain[][] _grainField { get; set; }
        private readonly BoundaryConditions _conditions;
        private readonly Neighbourhood _neighbourhood;
        private Random _r = new();
        public int BorderH { get; set; }
        public int MiddleH { get; set; }
        public TypeEnum Type { get; set; }
        public int[][] StructureField { get; set; }

        public Srx(int[][] field, BoundaryConditions conditions, Neighbourhood neighbourhood, TypeEnum type, int[][] structureField)
        {
            _field = field;
            _conditions = conditions;
            _neighbourhood = neighbourhood;
            Type = type;
            StructureField = structureField;
        }

        public Grain[][] StartOnce(int[][] field)
        {
            int[][] newField = AddBordersToField(field);
            BoxField(_field);
            var grainList = new List<Grain>();
            foreach (var grainRow in _grainField)
            {
                grainList.AddRange(grainRow);
            }
            if (Type == TypeEnum.Image)
                grainList.RemoveAll(x => StructureField[x.X][x.Y] == 0);
            grainList.Shuffle();

            foreach (var grain in grainList)
            {
                var indexes =
                    NeighbourhoodHelper.GetNeighbours(grain.X + 1, grain.Y + 1,
                        _neighbourhood, _conditions, _field);
                (double, int, int) energy = (0, 0, 0);
                if (_neighbourhood == Neighbourhood.VonNeumann)
                {
                    energy = EnergyCalculator.FindOutputSRX(MiddleH, BorderH, grain, newField[grain.X + 1][grain.Y + 1],
                        newField[indexes.Item1[0]][indexes.Item2[0]],
                        newField[indexes.Item1[1]][indexes.Item2[1]],
                        newField[indexes.Item1[2]][indexes.Item2[2]],
                        newField[indexes.Item1[3]][indexes.Item2[3]]
                    );
                }
                else if (_neighbourhood == Neighbourhood.Moore)
                {
                    energy = EnergyCalculator.FindOutputSRX(MiddleH, BorderH, grain,
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
                    energy = EnergyCalculator.FindOutputSRX(MiddleH, BorderH, grain,
                        newField[indexes.Item1[0]][indexes.Item2[0]],
                        newField[indexes.Item1[1]][indexes.Item2[1]],
                        newField[indexes.Item1[2]][indexes.Item2[2]],
                        newField[indexes.Item1[3]][indexes.Item2[3]],
                        newField[indexes.Item1[4]][indexes.Item2[4]]
                    );
                }
                else if (_neighbourhood == Neighbourhood.Hexagonal)
                {

                    energy = EnergyCalculator.FindOutputSRX(MiddleH, BorderH, grain,
                        newField[indexes.Item1[0]][indexes.Item2[0]],
                        newField[indexes.Item1[1]][indexes.Item2[1]],
                        newField[indexes.Item1[2]][indexes.Item2[2]],
                        newField[indexes.Item1[3]][indexes.Item2[3]],
                        newField[indexes.Item1[4]][indexes.Item2[4]],
                        newField[indexes.Item1[5]][indexes.Item2[5]]
                    );
                }


                var diff = energy.Item2 - energy.Item1;
                if (diff <= 0)
                {
                    grain.Value = energy.Item3;
                    grain.Energy = 0;
                    grain.IsRecrystallized = true;
                }
                newField[grain.X + 1][grain.Y + 1] = grain.Value;
            }

            return _grainField;
        }

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

        private void BoxField(int[][] field)
        {
            _grainField = new Grain[field.Length][];
            for (int i = 0; i < field.Length; i++)
            {
                _grainField[i] = new Grain[field[i].Length];
                for (int j = 0; j < field[i].Length; j++)
                {
                    _grainField[i][j] = new Grain(i, j, field[i][j]);
                }
            }
        }

        static T[][] CopyArrayBuiltIn<T>(T[][] source)
        {
            T[][] newArr = new T[source.Length][];
            for (int i = 0; i < newArr.Length; i++)
            {
                newArr[i] = (T[])source[i].Clone();
            }

            return newArr;
        }
    }
}
