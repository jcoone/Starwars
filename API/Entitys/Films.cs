using System;
using System.Collections.Generic;
using System.Linq;

namespace API.Entitys
{
    public partial class Films
    {
        public Films()
        {
            FilmToPeople = new HashSet<FilmToPeople>();
            PlanetsToFilms = new HashSet<PlanetsToFilms>();
        }

        /// <summary>  
        /// Gets or sets Unique Url ID property.  
        /// </summary>  
        public string Url { get; set; }

        /// <summary>  
        /// Gets or sets The Film Title.  
        /// </summary>  
        public string Title { get; set; }

        /// <summary>  
        /// Gets or sets The Episode Id.  
        /// </summary>
        public short EpisodeId { get; set; }
        public string OpeningCrawl { get; set; }
        public string Director { get; set; }
        public string Producer { get; set; }
        public DateTime ReleaseDate { get; set; }
        public DateTime Created { get; set; }
        public DateTime Edited { get; set; }

        public virtual ICollection<FilmToPeople> FilmToPeople { get; set; }
        public virtual ICollection<PlanetsToFilms> PlanetsToFilms { get; set; }

        public string[] Characters { 
            get 
            { 
                return FilmToPeople.Select(c => c.PeopleUrl).ToArray(); 
                }
        }
    }
}
