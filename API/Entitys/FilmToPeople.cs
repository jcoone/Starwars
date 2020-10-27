using System;
using System.Collections.Generic;

namespace API.Entitys
{
    public partial class FilmToPeople
    {
        public string FilmUrl { get; set; }
        public string PeopleUrl { get; set; }

        public virtual Films FilmUrlNavigation { get; set; }
        public virtual Peoples PeopleUrlNavigation { get; set; }
    }
}
