using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using API.Entitys;
using Newtonsoft.Json;

namespace API.Data
{
    public static class Seed
    {
        static HttpClient httpClient = new HttpClient();

        public static async Task SeedDataBase(StarwarsContext context)
        {
            
           // Look to see if we have seeded anything
           if(await context.Films.AnyAsync()) return;
            context.Dispose();
            var result = await GetDataMode("films");
            if (result != null) 
            {
                SeedFilms(result);
            }
            result = await GetDataMode("people");
            if (result != null) 
            {
                SeedPeople(result, context);
            }

            result = await GetDataMode("people");
            if (result != null) 
            {
                SeedSpecies(result, context);
            }

        }

        public static async Task<dynamic> GetDataMode (string path)
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
                        Created = _film["created"]
                    });

                    // get the array objects
                    var characters = _film["characters"];
                    foreach (var ch in characters)
                    {
                     //context.Add(new FilmToPeople { FilmUrl = _film["url"], PeopleUrl = ch });
                    }
                    var planets = _film["planets"];
                    foreach (var pl in planets)
                    {
                        // context.Add(new PlanetsToFilms { FilmsUrl = _film["url"], PlanetUrl = pl });
                    }
                    var starships = _film["starships"];
                    foreach (var st in starships)
                    {
                        // context.Add(new FilmToCraft { FilmUrl = _film["url"], CraftUrl = st });
                    }
                    var vehicles = _film["vehicles"];
                    foreach (var ch in vehicles)
                    {
                        // context.Add(new FilmToCraft { FilmUrl = _film["url"], CraftUrl = ch });
                    }
                    var species = _film["species"];

                    foreach (var sp in species)
                    {
                        // context.Add(new FilmsToSpecies { FilmUrl = _film["url"], SpeciesUrl = sp });
                    }
                    context.SaveChanges();
                    context.Dispose();
                }
            }
        }

        private static void SeedPeople(dynamic json, StarwarsContext _context)
        {
             dynamic _people = json["results"];

            foreach (var _person in _people)
            {

                _context.Add(new Peoples
                {
                    Url = _people["url"],
                    Name = _people["name"],
                    Height = _people["height"],
                    Mass = _people["mass"],
                    HairColor =  _people["hair_color"],
                    SkinColor = _people["skin_color"],
                    EyeColor = _people["eye_color"],
                    BirthYear = _people["birth_year"],
                    Gender = _people[""],
                    Homeworld = _people[""], 
                    Created = _people["created"]
                });

                // get the array objects
                var peoplesp = _people["species"];
                foreach (var ps in peoplesp)
                {
                    // _context.Add(new SpeciesToPeople { PeopleUrl = _people["url"], SpeciesUrl = ps });
                }
                var vehicles = _people["Vehicles"];
                foreach (var vh in vehicles)
                {
                    // _context.Add(new PersonToCraft { PersonUrl = _people["url"], CraftUrl = vh });
                }

                 var starships = _people["starships"];
                foreach (var ss in starships)
                {
                    // _context.Add(new PersonToCraft { PersonUrl = _people["url"], CraftUrl = ss });
                }

            }
        }
       
  private static void SeedSpecies(dynamic json, StarwarsContext _context)
        {
             dynamic _species = json["results"];

            foreach (var _specie in _species)
            {

                _context.Add(new Species
                {
                    Url = _specie["url"],
                    Name = _specie["name"],
                    Classification = _specie["classification"],
                    Designation =  _specie["designation"],
                    AverageHeight = _specie["average_height"],
                    SkinColors = _specie["skin_colors"],
                    HairColors =  _specie["hair_colors"],
                    EyeColors = _specie["hair_colors"],
                    AverageLifespan = _specie["average_lifespan"],
                    Homeworld =  _specie["homeworld"],
                    Language = _specie["language"],
                    Created = _specie["created"]
                });

                // object already done
            
            }
        }

    
    }
}