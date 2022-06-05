namespace CellularAutomatons.GrainAutomatons
{
    public class Grain
    {
        public int Value { get; set; }
        public int X { get; init; }
        public int Y { get; init; }
        public double Energy { get; set; }
        public bool IsRecrystallized { get; set; }

        public Grain(int x, int y, int value = 0)
        {
            X = x;
            Y = y;
            Value = value;
        }
    }
}
