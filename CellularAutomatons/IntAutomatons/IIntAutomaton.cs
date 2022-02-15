namespace CellularAutomatons.IntAutomatons
{
    public interface IIntAutomaton
    {
        public int FindOutput(int cell, params int[] neighbours);
    }
}