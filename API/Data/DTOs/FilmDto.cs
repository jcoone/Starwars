using System;
using System.Collections.Generic;
using API.Entitys;
using AutoMapper.Configuration.Conventions;
using Newtonsoft.Json;

namespace API.Data.DTOs
{
    public class FilmDto
    {
        public string Url { get; set; }
        public string Title { get; set; }
        public short EpisodeId { get; set; }
        public string OpeningCrawl { get; set; }
        public string Director { get; set; }
        public string Producer { get; set; }
        public DateTime ReleaseDate { get; set; }
        public DateTime Created { get; set; }
        public DateTime Edited { get; set; }

        // Filter the filem to people.
        [MapTo("Characters")]
        public  string[] Characters  { get; set; }
       
        [MapTo("Planets")]
        public virtual IList<String> Planets { get; set; }

        
    }
}