using System.Linq;

namespace CellularAutomatons.IntAutomatons
{
    public class GameOfLife : IIntAutomaton
    {
        public int FindOutput(int cell, params int[] neighbours)
        {
            int count = neighbours.Count(neighbour => neighbour == 1);

            if (cell is 1 && count is 2)
                return 1;
            if (count is 3)
                return 1;
            return 0;
        }
    }
}