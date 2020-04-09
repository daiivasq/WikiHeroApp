using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WikiHero.Models;

namespace WikiHero.Services
{
    public class DBFavorites : IDBFavorites
    {
        public Task<List<Character>> GetCharacter()
        {
            throw new NotImplementedException();
        }

        public Task<List<Comic>> GetComic()
        {
            throw new NotImplementedException();
        }

        public Task<List<Movie>> GetMovies()
        {
            throw new NotImplementedException();
        }

        public Task<List<Serie>> GetSeries()
        {
            throw new NotImplementedException();
        }

        public Task<List<Volume>> GetVolume()
        {
            throw new NotImplementedException();
        }
    }
}
