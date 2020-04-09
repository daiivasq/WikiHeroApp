using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WikiHero.Models;

namespace WikiHero.Services
{
    public interface IDBFavorites
    {
        Task<List<Serie>> GetSeries();
        Task<List<Character>> GetCharacter();
        Task<List<Comic>>  GetComic();
        Task<List<Movie>> GetMovies();
        Task<List<Volume>> GetVolume();

    }
}
