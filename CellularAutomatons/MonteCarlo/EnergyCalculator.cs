using System;
using System.Linq;
using CellularAutomatons.GrainAutomatons;

namespace CellularAutomatons.MonteCarlo
{
    public static class EnergyCalculator
    {
        private static Random rng = new Random();
        public static (int, int, int) FindOutputMC(int cell, params int[] neighbours)
        {
            var neighList = neighbours.ToList();
            neighList.RemoveAll(n => n == 0);
            if (neighList.All(x => x == cell))
                return (0, 0, cell);
            var initialEnergy = neighList.Count(neighbour => cell != neighbour);
            int randomNeighbour = 0;
            randomNeighbour = neighList[rng.Next(0, neighList.Count)];

            var potentialEnergy = neighList.Count(neighbour => randomNeighbour != neighbour);
            return (initialEnergy, potentialEnergy, randomNeighbour);
        }

        public static (double, int, int) FindOutputSRX(int XX, int YY, Grain cell, params int[] neighbours)
        {
            var neighList = neighbours.ToList();
            neighList.RemoveAll(n => n == 0);
            if (neighList.All(x => x > 0))
                return (0, 0, cell.Value);
            var recrystVal = neighList.First(x => x < 0);
            double initialEnergy = neighList.Count(neighbour => cell.Value != neighbour);
            if (cell.Energy > 0 && !cell.IsRecrystallized)
                initialEnergy += (XX * (rng.NextDouble()/5*2+0.2));
            int randomNeighbour = 0;
            randomNeighbour = neighList[rng.Next(0, neighList.Count)];
            
            
            var potentialEnergy = neighList.Count(neighbour => randomNeighbour != neighbour);

            return (initialEnergy, potentialEnergy, recrystVal);
        }
    }
}
