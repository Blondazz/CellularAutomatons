using System.Collections.Generic;

namespace CellularAutomatons.Cells
{
    public class LgaCell
    {
        public List<Particle> Particles { get; set; }

        public LgaCell()
        {
            Particles = new List<Particle>();
        }
    }
}
