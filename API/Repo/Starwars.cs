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
          
          return await _context.Films.Where(x => x.Url == url).FirstAsync();
        }

        public async Task<IEnumerable<Films>> GetFilmsAysnc()
        {
          return await _context.Films.ToArrayAsync<Films>();
        }
    }
}