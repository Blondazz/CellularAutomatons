using System.Linq;

namespace CellularAutomatons.GrainAutomatons
{
    public class GrainGrowth : IGrainAutomaton
    {
        public int FindOutput(int cell, params int[] neighbours)
        {
            if (cell != 0)
                return cell;
            if (!neighbours.Contains(0))
                return neighbours[0];
            var list = neighbours.GroupBy(i => i).OrderByDescending(grp => grp.Count())
                .Select(grp => grp.Key);
            int most = 0;
            if (list.Count() > 1)
            {
                most = list.First();
                if (most == 0)
                    most = list.Skip(1).First();
            }
            return most;
            // return cell != 0 ? cell : neighbours.FirstOrDefault(neighbour => neighbour != 0);
        }
    }
}
