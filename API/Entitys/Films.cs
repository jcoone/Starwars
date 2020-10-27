using System;
using System.Collections.Generic;

namespace API.Entitys
{
    public partial class Films
    {
        public Films()
        {
            FilmToPeople = new HashSet<FilmToPeople>();
            PlanetsToFilms = new HashSet<PlanetsToFilms>();
        }

        public string Url { get; set; }
        public string Title { get; set; }
        public short EpisodeId { get; set; }
        public string OpeningCrawl { get; set; }
        public string Director { get; set; }
        public string Producer { get; set; }
        public DateTime ReleaseDate { get; set; }
        public DateTime Created { get; set; }
        public byte[] Edited { get; set; }

        public virtual ICollection<FilmToPeople> FilmToPeople { get; set; }
        public virtual ICollection<PlanetsToFilms> PlanetsToFilms { get; set; }
    }
}
