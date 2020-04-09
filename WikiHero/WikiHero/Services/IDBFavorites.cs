using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WikiHero.Models;

namespace WikiHero.Services
{
    public interface IDBFavorites
    {
        List<Serie> GetSeries(string publisher);
        List<Character> GetCharacter(string publisher);
        List<Comic> GetComic(string publisher);
        List<Volume> GetVolume(string publisher);

        void AddSeries(string publisher, Serie series);
        void AddCharacter(string publisher, Character characters);
        void AddComic(string publisher, Comic comics);
        void AddVolume(string publisher, Volume volumes);

    }


}
