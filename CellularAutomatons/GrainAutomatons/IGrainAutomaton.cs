namespace CellularAutomatons.GrainAutomatons
{
    public interface IGrainAutomaton
    {
        public int FindOutput(int cell, params int[] neighbours);
    }
}