using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using System.IO;
using API.Entitys;

namespace API.Data
{
    public static class Seed
    {
        static HttpClient httpClient = new HttpClient();

        public static async Task SeedDataBase(StarwarsContext context)
        {
            
           
           if(await context.Films.AnyAsync()) return;
                // var result = await GetDataModel<Films>("films");
                // if (result != null) 
                // {
                   
                // }
            
        }

        // public static async void GetDataMode (string path)
        // {
        //     string url = $"https://swapi.dev/api/{path}/";

            
        // }
        private static void SeedFilms(dynamic json,StarwarsContext _context ){
            
            dynamic _films = json["results"];

            // parse though the films and add to the context.
            foreach(var _film in _films){

                _context.Add(new Films
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
                 foreach(var ch in characters){
                     _context.Add(new FilmToPeople { FilmUrl = _film["url"], PeopleUrl = ch});
                 }
                var planets = _film["planets"];
                 foreach(var pl in planets){
                    _context.Add(new PlanetsToFilms { FilmsUrl = _film["url"], PlanetUrl = pl});
                 }
                var starships = _film["starships"];
                 foreach(var st in starships){
                    _context.Add(new FilmToCraft { FilmUrl = _film["url"], CraftUrl = st});
                 }
                var vehicles = _film["vehicles"];
                 foreach(var ch in vehicles){
                    _context.Add(new FilmToCraft { FilmUrl = _film["url"], CraftUrl = ch});
                 }
                var species = _film["species"];
               
                foreach(var sp in species){
                    _context.Add(new  FilmsToSpecies { FilmUrl = _film["url"], SpeciesUrl = sp});
                }
               _context.SaveChangesAsync();
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
                    _context.Add(new SpeciesToPeople { PeopleUrl = _people["url"], SpeciesUrl = ps });
                }
                var vehicles = _people["Vehicles"];
                foreach (var vh in vehicles)
                {
                    _context.Add(new PersonToCraft { PersonUrl = _people["url"], CraftUrl = vh });
                }

                 var starships = _people["starships"];
                foreach (var ss in starships)
                {
                    _context.Add(new PersonToCraft { PersonUrl = _people["url"], CraftUrl = ss });
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