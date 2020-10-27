using System;
using System.Collections.Generic;

namespace API.Entitys
{
    public partial class Planets
    {
        public Planets()
        {
            PlanetsToFilms = new HashSet<PlanetsToFilms>();
        }

        public string Url { get; set; }
        public string Name { get; set; }
        public short RotationPeriod { get; set; }
        public short OrbitalPeriod { get; set; }
        public int Diameter { get; set; }
        public string Gravity { get; set; }
        public string Terrain { get; set; }
        public short SurfaceWater { get; set; }
        public string Population { get; set; }
        public DateTime Created { get; set; }
        public byte[] Edited { get; set; }

        public virtual ICollection<PlanetsToFilms> PlanetsToFilms { get; set; }
    }
}
