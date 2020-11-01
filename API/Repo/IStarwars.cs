using System.Collections.Generic;
using System.Threading.Tasks;
using API.Entitys;

namespace API.Repo
{
    public interface IStarwars
    {
        // This creates our contracts
         Task<IEnumerable<Films>> GetFilmsAysnc();

         Task<Films> GetFilmAysnc(string url);
    }
}