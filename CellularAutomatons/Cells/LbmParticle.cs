using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CellularAutomatons.Cells
{
    public class LbmParticle
    {
        public ParticleDirection Direction { get; set; }
        public float Value { get; set; }

        public LbmParticle(int rng)
        {
            Direction = (ParticleDirection)(rng % 4);
        }
        public LbmParticle(ParticleDirection direction, float value)
        {
            Direction = direction;
            Value = value;
        }

        public void Bounce()
        {
            Direction = Direction switch
            {
                ParticleDirection.Down => ParticleDirection.Up,
                ParticleDirection.Up => ParticleDirection.Down,
                ParticleDirection.Left => ParticleDirection.Right,
                ParticleDirection.Right => ParticleDirection.Left,
                _ => throw new ArgumentOutOfRangeException()
            };
        }
    }
}
