using MonkeyCache.FileStore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WikiHero.Models;

namespace WikiHero.Services
{
    public class DBFavorites : IDBFavorites
    {
        public DBFavorites()
        {
            Barrel.ApplicationId = Config.CacheKey;
        }

    

        public void AddCharacter(string publisher, Character characters)
        {
            List<Character> character = new List<Character>();
            character.Add(characters);
            Barrel.Current.Add(key:$"{nameof(AddCharacter)}/{publisher}", data: character, TimeSpan.FromDays(60));
        }

        public void AddComic(string publisher, Comic comics)
        {
            List<Comic> comic = new List<Comic>();
            comic.Add(comics);
            Barrel.Current.Add(key: $"{nameof(AddComic)}/{publisher}", data: comic, TimeSpan.FromDays(60));
        }
        public void AddSeries(string publisher, Serie series)
        {
            List<Serie> serie = new List<Serie>();
            serie.Add(series);
            Barrel.Current.Add(key: $"{nameof(AddSeries)}/{publisher}", data: serie, TimeSpan.FromDays(60));
        }

        public void AddVolume(string publisher, Volume volumes)
        {
            List<Volume> volume = new List<Volume>();
            volume.Add(volumes);
            Barrel.Current.Add(key: $"{nameof(AddVolume)}/{publisher}", data: volume, TimeSpan.FromDays(60));
        }

        public List<Character> GetCharacter(string publisher)
        {
            
            return Barrel.Current.Get<List<Character>>(key: $"{nameof(AddCharacter)}");
        }

        public List<Comic> GetComic(string publisher)
        {
            return Barrel.Current.Get<List<Comic>>(key: $"{nameof(AddComic)}");

        }

        public List<Serie> GetSeries(string publisher)
        {
            return Barrel.Current.Get<List<Serie>>(key: $"{nameof(AddSeries)}");
        }

        public List<Volume> GetVolume(string publisher)
        {
            return Barrel.Current.Get<List<Volume>>(key: $"{nameof(AddVolume)}");
        }
    }
}
