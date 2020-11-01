using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using API.Entitys;
using Newtonsoft.Json;
using System;

namespace API.Data
{
    public static class Seed
    {
        static HttpClient httpClient = new HttpClient();

        public static async Task SeedDataBase(StarwarsContext context)
        {

            // Look to see if we have seeded anything
          
        //     var films = await GetDataMode("films");
        
        //     if (films != null)
        //     {
        //         SeedFilms(films);  
        //     }


        //    var  poeple = await GetDataMode("people");
        //     if (poeple != null)
        //     {
        //            SeedPeople(poeple);           
        //     }

            var result = await GetDataMode("species");
            if (result != null)
            {
                SeedSpecies(result);
            }

        }

        public static async Task<dynamic> GetDataMode(string path)
        {
            dynamic result = null;
            string url = $"https://swapi.dev/api/{path}/";
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(url))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    result = JsonConvert.DeserializeObject(apiResponse);
                }
            }

            return result;

        }

        // Ok This is done next I want characters in.
        private static void SeedFilms(dynamic json)
        {

            dynamic _films = json["results"];
            // parse though the films and add to the context.
            foreach (var _film in _films)
            {
                using (StarwarsContext context = new StarwarsContext())
                {
                    context.Add(new Films
                    {
                        Url = _film["url"],
                        Title = _film["title"],
                        EpisodeId = _film["episode_id"],
                        OpeningCrawl = _film["opening_crawl"],
                        Director = _film["director"],
                        Producer = _film["producer"],
                        ReleaseDate = _film["release_date"],
                        Created = (DateTime)_film["created"],
                       Edited = (DateTime)_film["edited"]
                    });

                    context.SaveChanges();                 
                }
            }
        }

        private static void SeedPeople(dynamic json)
        {
            dynamic _people = json["results"];

            foreach (var _person in _people)
            {
              
                using (StarwarsContext context = new StarwarsContext())
                {
                string s = _person["created"];
                if (String.IsNullOrEmpty(s)) return;

                    context.Add(new Peoples
                    {
                        Url = _person["url"],
                        Name = _person["name"],
                        Height = (short)_person["height"],
                        Mass = (short)_person["mass"],
                        HairColor = _person["hair_color"],
                        SkinColor = _person["skin_color"],
                        EyeColor = _person["eye_color"],
                        BirthYear = _person["birth_year"],
                        Gender = _person["gender"],
                        Homeworld = _person["homeworld"],
                        Created = (DateTime)_person["created"],
                        Edited = (DateTime)_person["edited"]
                    });

                    var films = _person["films"];
                    foreach (var fl in films)
                    {
                         context.Add(new FilmToPeople { FilmUrl = fl, PeopleUrl = _person["url"] });
                    }
              
                  context.SaveChanges();
                
                }
            }
        }

       private static void SeedSpecies(dynamic json)
        {
            dynamic _species = json["results"];

            foreach (var _specie in _species)
            {
                using (StarwarsContext context = new StarwarsContext())
                {
                     
                    context.Add(new Species
                    {
                        Url = _specie["url"],
                        Name = _specie["name"],
                        Classification = _specie["classification"],
                        Designation = _specie["designation"],
                        AverageHeight = ShortParse(_specie["average_height"]),
                        SkinColors = _specie["skin_colors"],
                        HairColors = _specie["hair_colors"],
                        EyeColors = _specie["hair_colors"],
                        AverageLifespan = ShortParse(_specie["average_lifespan"]),
                        Homeworld = _specie["homeworld"],
                        Language = _specie["language"],
                        Created = (DateTime)_specie["created"],
                        Edited = (DateTime)_specie["edited"]
                    });

                     var peoplesp = _specie["people"];
                    foreach (var ps in peoplesp)
                    {
                        context.Add(new SpeciesToPeople { PeopleUrl = ps , SpeciesUrl = _specie["url"] });
                    } 
                  context.SaveChanges();
                  
                }
            }
        }

        /// <summary>  
        /// Api returns strings where I expect a number this is to handle the error will use a dto to change the result back.  
        /// </summary>
        private static short ShortParse(dynamic value)
        {
            string v = value;
            short number;
            bool result = Int16.TryParse(v, out number);
            if (result)
            {
               return number;
            }
            return -1;
        }

    }
}