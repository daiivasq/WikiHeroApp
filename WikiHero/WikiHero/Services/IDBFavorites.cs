using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace WikiHero.Services
{
    public interface IDBFavorites
    {
        Task GetSeries();
        Task GetCharacter();
        Task  GetComic();
        Task GetMovies();
        Task GetVolume();

    }
}
