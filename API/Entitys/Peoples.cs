using System;
using System.Collections.Generic;

namespace API.Entitys
{
    public partial class Peoples
    {
        public Peoples()
        {
            FilmToPeople = new HashSet<FilmToPeople>();
        }

        public string Url { get; set; }
        public string Name { get; set; }
        public short? Height { get; set; }
        public short? Mass { get; set; }
        public string HairColor { get; set; }
        public string SkinColor { get; set; }
        public string EyeColor { get; set; }
        public string BirthYear { get; set; }
        public string Gender { get; set; }
        public DateTime Created { get; set; }
        public byte[] Edited { get; set; }
        public string Homeworld { get; set; }

        public virtual ICollection<FilmToPeople> FilmToPeople { get; set; }
    }
}
