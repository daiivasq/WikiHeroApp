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
           
        }

    

        public void AddCharacter(string publisher, Character characters)
        {
            Barrel.ApplicationId = Config.CacheKey;
            Barrel.Current.Add(key:$"{nameof(AddCharacter)}/{publisher}", data: characters, expireIn:TimeSpan.FromDays(30));
        }

        public void AddComic(string publisher, Comic comics)
        {
            Barrel.Current.Add(key: $"{nameof(AddComic)}/{publisher}", data: comics, expireIn: TimeSpan.FromDays(60));
        }
        public void AddSeries(string publisher, Serie series)
        {
            Barrel.ApplicationId = Config.CacheKey;
            List<Serie> serie = new List<Serie>();
            serie.Add(series);
            Barrel.Current.Add(key: $"{nameof(AddSeries)}/{publisher}", data: serie, expireIn: TimeSpan.FromDays(60));
        }

        public void AddVolume(string publisher, Volume volumes)
        {
            Barrel.ApplicationId = Config.CacheKey;
            List<Volume> volume = new List<Volume>();
            volume.Add(volumes);
            Barrel.Current.Add(key: $"{nameof(AddVolume)}/{publisher}", data: volume, expireIn: TimeSpan.FromDays(60));
        }

        public List<Character> GetCharacter(string publisher)
        {
            Barrel.ApplicationId = Config.CacheKey;
            return Barrel.Current.Get<List<Character>>(key: $"{nameof(AddCharacter)}/{publisher}");
        }

        public List<Comic> GetComic(string publisher)
        {
            Barrel.ApplicationId = Config.CacheKey;
            return Barrel.Current.Get<List<Comic>>(key: $"{nameof(AddComic)}/{publisher}");

        }

        public List<Serie> GetSeries(string publisher)
        {
            Barrel.ApplicationId = Config.CacheKey;
            return Barrel.Current.Get<List<Serie>>(key: $"{nameof(AddSeries)}/{publisher}");
        }

        public List<Volume> GetVolume(string publisher)
        {
            Barrel.ApplicationId = Config.CacheKey;
            return Barrel.Current.Get<List<Volume>>(key: $"{nameof(AddVolume)}/{publisher}");
        }
    }
}
