using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using API.Entitys;
using Microsoft.EntityFrameworkCore;
using API.Data.DTOs;
using AutoMapper;
using API.Repo;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StarwarsController  : ControllerBase
    {
        
        private readonly IStarwars _repo;

        private readonly IMapper _mapper;
         // Constructor
          public StarwarsController(IStarwars repo, IMapper mapper)
        {
           _repo = repo;
          _mapper = mapper;
        }
        
        [HttpGet("films")]
         public async Task<ActionResult<IEnumerable<FilmDto>>> GetFilms(){
            
           var _filmList = await _repo.GetFilmsAysnc();
           var listToReturn = _mapper.Map<IEnumerable<FilmDto>>(_filmList);
           return Ok(listToReturn);
        }

         [HttpGet("film/{id}")]
         public async Task<ActionResult<Films>> GetFilm(int id){
            
         var film = await _repo.GetFilmAysnc(id);
         return film;
        }

    }
}