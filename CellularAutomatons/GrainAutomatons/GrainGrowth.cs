using System.Linq;

namespace CellularAutomatons.GrainAutomatons
{
    public class GrainGrowth : IGrainAutomaton
    {
        public int FindOutput(int cell, params int[] neighbours)
        {
            return cell != 0 ? cell : neighbours.FirstOrDefault(neighbour => neighbour != 0);
        }
    }
}
