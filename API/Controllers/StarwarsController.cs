using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using API.Data;
using API.Entitys;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StarwarsController  : ControllerBase
    {
        
        private readonly StarwarsContext _context;

         // Constructor
          public StarwarsController(StarwarsContext context)
        {
           _context = context;
          
        }

        [HttpGet("SeedData")]
         public async  Task<ActionResult> LoadData(){
           
         await Seed.SeedDataBase(_context);
           return Ok("Completed") ;
        }
        
        [HttpGet("films")]
         public async Task<ActionResult<IEnumerable<Films>>> GetFilms(){
            
           return Ok(await  _context.Films.ToArrayAsync<Films>());
        }

        //  [HttpGet("film/{id}")]
        //  public async Task<ActionResult<Films>> GetFilm(int id){
            
        //  var film = await _context.films.FindAsync(id);
        //  return film;
        // }

        //  [HttpGet("peoples")]
        //  public async Task<ActionResult<IEnumerable<Peoples>>> GetPeoples(){
            
        //     var peoples = await _context.peoples.ToListAsync();
        //     return peoples;
        // }

        //  [HttpGet("person/{id}")]
        //  public async Task<ActionResult<Peoples>> GetPerson(int id){
            
        //  var person = await _context.peoples.FindAsync(id);
        //  return person;
        // }

        //  [HttpGet("planets")]
        //  public async Task<ActionResult<IEnumerable<Planets>>> GetPlanets(){
            
        //     var planets = await _context.planets.ToListAsync();
        //     return planets;
        // }

        //  [HttpGet("planet/{id}")]
        //  public async Task<ActionResult<Planets>> GetPlanet(int id){
            
        //  var planet = await _context.planets.FindAsync(id);
        //  return planet;
        // }

    }
}