using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CellularAutomatons.Cells
{
    public class LbmCell
    {
        public List<LbmParticle> Particles { get; set; }

        public LbmCell()
        {
            Particles = new List<LbmParticle>();
        }
    }
}
