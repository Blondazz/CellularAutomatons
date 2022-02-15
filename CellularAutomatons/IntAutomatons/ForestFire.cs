using System;
using System.Linq;

namespace CellularAutomatons.IntAutomatons
{
    public class ForestFire : IIntAutomaton
    {
        private readonly int _ignitionProbability;
        private readonly int _spontaneousIgnitionProbability;
        private readonly int _growthProbability;
        private readonly Random _random = new Random();

        public ForestFire(int ignitionProbability, int spontaneousIgnitionProbability, int growthProbability)
        {
            _ignitionProbability = ignitionProbability;
            _spontaneousIgnitionProbability = spontaneousIgnitionProbability;
            _growthProbability = growthProbability;
        }
        public int FindOutput(int cell, params int[] neighbours)
        {
            if (cell == -1)
                return -1;
            int count = 0;

            if (cell is 0)
            {
                count += neighbours.Count(neighbour => neighbour is 1);

                return _random.Next(0, 10000) < _growthProbability * count + 1 ? 1 : cell;
            }
            if (cell is 1)
            {
                count += neighbours.Count(neighbour => neighbour is 2);

                if (count is 0)
                    return _random.Next(0, 5000000) < _spontaneousIgnitionProbability ? 2 : cell;
                return _random.Next(0, 100) < _ignitionProbability * count ? 2 : cell;
            }
            if (cell is 6)
                return 0;
            if (cell >= 2)
                return cell + 1;
            return 0;

        }
    }
}