using System.Collections.Generic;
using System.Threading.Tasks;
using API.Entitys;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace API.Repo
{
    // this would be my repository pattern.
    public class Starwars : IStarwars
    {
        private readonly StarwarsContext _context;
        public Starwars(StarwarsContext context){
            _context = context; 
        }
        public async Task<Films> GetFilmAysnc(string url)
        {
          var result = await _context.Films
          .Where(x => x.Url == url)
          .Include(films => films.FilmToPeople)
          .FirstAsync();
          return result;
        }

        public async Task<IEnumerable<Films>> GetFilmsAysnc()
        {
          var filmList =   await _context.Films
          .Include(films => films.FilmToPeople)
          .ToArrayAsync<Films>();
          return filmList;                             
        }
    }
}