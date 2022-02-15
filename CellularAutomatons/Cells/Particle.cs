using System;
using System.Linq;

namespace CellularAutomatons.Cells
{
    public class Particle
    {
        public ParticleDirection Direction { get; set; }

        public Particle(int rng)
        {
            Direction = (ParticleDirection)(rng % 4);
        }
        public Particle(ParticleDirection direction)
        {
            Direction = direction;
        }

        public void Collide()
        {

            if (Direction == ParticleDirection.Down)
                Direction = ParticleDirection.Left;
            else
                Direction++;
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
