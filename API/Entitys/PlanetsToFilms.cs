using System;
using System.Collections.Generic;

namespace API.Entitys
{
    public partial class PlanetsToFilms
    {
        public string PlanetUrl { get; set; }
        public string FilmsUrl { get; set; }

        public virtual Films FilmsUrlNavigation { get; set; }
        public virtual Planets PlanetUrlNavigation { get; set; }
    }
}
