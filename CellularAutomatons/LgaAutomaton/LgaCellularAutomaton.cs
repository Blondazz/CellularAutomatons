using CellularAutomatons.Cells;
using System;
using CellularAutomatons.Enums;

namespace CellularAutomatons.LgaAutomaton
{
    public class LgaCellularAutomaton
    {
        private readonly LgaCell[][] _field;

        public LgaCellularAutomaton(LgaCell[][] field)
        {
            _field = field;
        }
        public LgaCell[][] StartOnce()
        {
            LgaCell[][] field = _field;
            LgaCell[][] newField = AddBordersToField(field);
            for (int i = 0; i < field.Length; i++)
            {
                for (int j = 0; j < field[i].Length; j++)
                {
                    if (field[i][j] is not null)
                        field[i][j] = new LgaCell();
                }
            }

            for (int i = 1; i < newField.Length - 1; i++)
            {
                for (int j = 1; j < newField[i].Length - 1; j++)
                {
                    if (newField[i][j] is not null)
                        foreach (var particle in newField[i][j].Particles)
                        {
                            if (particle.Direction == ParticleDirection.Left)
                            {
                                if (newField[i][j - 1] is null)
                                {
                                    particle.Bounce();
                                    field[i - 1][j - 1].Particles.Add(particle);
                                }

                                else
                                    field[i - 1][j - 2].Particles.Add(particle);
                            }
                            else if (particle.Direction == ParticleDirection.Up)
                            {
                                if (newField[i - 1][j] is null)
                                {
                                    particle.Bounce();
                                    field[i - 1][j - 1].Particles.Add(particle);
                                }

                                else
                                    field[i - 2][j - 1].Particles.Add(particle);
                            }
                            else if (particle.Direction == ParticleDirection.Right)
                            {
                                if (newField[i][j + 1] is null)
                                {
                                    particle.Bounce();
                                    field[i - 1][j - 1].Particles.Add(particle);
                                }

                                else
                                    field[i - 1][j].Particles.Add(particle);
                            }
                            else if (particle.Direction == ParticleDirection.Down)
                            {
                                if (newField[i + 1][j] is null)
                                {
                                    particle.Bounce();
                                    field[i - 1][j - 1].Particles.Add(particle);
                                }

                                else
                                    field[i][j - 1].Particles.Add(particle);
                            }
                        }
                }
            }
            CheckCollisions(field);
            return field;
        }

        private void CheckCollisions(LgaCell[][] field)
        {
            foreach (var t in field)
            {
                foreach (var lgaCell in t)
                {
                    if (lgaCell is not null && lgaCell.Particles.Count == 2)
                        if (Math.Abs((int)lgaCell.Particles[0].Direction - (int)lgaCell.Particles[1].Direction) == 2)
                        {
                            lgaCell.Particles[0].Collide();
                            lgaCell.Particles[1].Collide();
                        }
                }
            }
        }

        /// <summary>
        /// returns an array which is the parameter array but surrounded with zeroes 
        /// </summary>
        /// <param name="field"></param>
        /// <returns></returns>
        private LgaCell[][] AddBordersToField(LgaCell[][] field)
        {
            LgaCell[][] newField = new LgaCell[field.Length + 2][];
            newField[0] = new LgaCell[field[0].Length + 2];
            newField[^1] = new LgaCell[field[0].Length + 2];
            for (int i = 0; i < newField.Length - 2; i++)
            {
                newField[i + 1] = new LgaCell[field[0].Length + 2];
                for (int j = 0; j < newField[0].Length; j++)
                {
                    if (!(j == 0 || j == newField[0].Length - 1))
                    {
                        if (field[i][j - 1] is not null)
                        {
                            newField[i + 1][j] = new LgaCell();
                            foreach (var particle in field[i][j - 1].Particles)
                                newField[i + 1][j].Particles.Add(particle);
                        }

                    }
                }
            }
            return newField;
        }


    }
}