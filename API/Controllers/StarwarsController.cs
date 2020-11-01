using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using API.Data;
using API.Entitys;
using Microsoft.EntityFrameworkCore;
using API.Data.DTOs;
using AutoMapper;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StarwarsController  : ControllerBase
    {
        
        private readonly StarwarsContext _context;

        private readonly IMapper _mapper;
         // Constructor
          public StarwarsController(StarwarsContext context, IMapper mapper)
        {
           _context = context;
          _mapper = mapper;
        }
        
        [HttpGet("films")]
         public async Task<ActionResult<IEnumerable<FilmDto>>> GetFilms(){
            
           var _filmList = await _context.Films.ToArrayAsync<Films>();
           var listToReturn = _mapper.Map<IEnumerable<FilmDto>>(_filmList);
           return Ok(listToReturn);
        }

         [HttpGet("film/{id}")]
         public async Task<ActionResult<Films>> GetFilm(int id){
            
         var film = await _context.Films.FindAsync(id);
         return film;
        }

    }
}