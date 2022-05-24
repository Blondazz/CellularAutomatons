using System;
using System.Linq;

namespace CellularAutomatons.MonteCarlo
{
    public static class EnergyCalculator
    {
        private static Random rng = new Random();
        public static (int, int, int) FindOutput(int cell, params int[] neighbours)
        {
            var neighList = neighbours.ToList();
            neighList.RemoveAll(n => n == 0);
            if (neighList.All(x => x == cell))
                return (0, 0, cell);
            var initialEnergy = neighList.Count(neighbour => cell != neighbour);
            int randomNeighbour = 0;
            do
            {
                randomNeighbour = neighList[rng.Next(0, neighList.Count)];
            } while (randomNeighbour == cell);

            var potentialEnergy = neighList.Count(neighbour => randomNeighbour != neighbour);
            return (initialEnergy, potentialEnergy, randomNeighbour);
        }
    }
}
