using MonkeyCache.FileStore;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WikiHero.Models.CharacterStatModel;
using Xamarin.Essentials;

namespace WikiHero.Services
{
    public class ApiStatsCharacters
    {
        public ApiStatsCharacters()
        {
            Barrel.ApplicationId = Config.CacheKey;
            Barrel.Current.EmptyAll();
        }
        private bool NetworkAvalible(string key)
        {
            if (Connectivity.NetworkAccess != NetworkAccess.Internet || !Barrel.Current.IsExpired(key: key))
            {
                return false;
            }
            return true;
        }
        public async Task<List<CharacterStats>> GetCharacterStats(string publisher)
        {
            if (!NetworkAvalible($"{nameof(GetCharacterStats)}/{publisher}"))
            {
                await Task.Yield();
                return Barrel.Current.Get<List<CharacterStats>>(key: $"{nameof(GetCharacterStats)}/{publisher}");
            }

            var getRequest = RestService.For<IApiCharacterStats>(Config.UrlApiCharactersStats);
            var stats = await getRequest.CharacterStats();
            var characters = stats.Where(e => e.Biography.Publisher != null).ToList(); 
            Barrel.Current.Add(key: $"{nameof(GetCharacterStats)}/{publisher}", characters, expireIn: TimeSpan.FromDays(1));
            return characters;

        }
    }
}
