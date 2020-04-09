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
    public class ApiStatsCharacters : IApiCharacterStats
    {
        public ApiStatsCharacters()
        {
            Barrel.ApplicationId = Config.CacheKey;
        }
        private bool NetworkAvalible(string key)
        {
            if (Connectivity.NetworkAccess != NetworkAccess.Internet || !Barrel.Current.IsExpired(key: key))
            {
                return false;
            }
            return true;
        }
        

        public async Task<List<CharacterStats>> CharacterStats(string publisher)
        {
            if (!NetworkAvalible($"{nameof(CharacterStats)}/{publisher}"))
            {
                return Barrel.Current.Get<List<CharacterStats>>(key: $"{nameof(CharacterStats)}/{publisher}");
            }

            var getRequest = RestService.For<IApiCharacterStats>(Config.UrlApiCharactersStats);
            var stats = await getRequest.CharacterStats(publisher);
            var characters = stats.Where(e => e.Biography.Publisher != null).ToList();
            Barrel.Current.Add(key: $"{nameof(CharacterStats)}/{publisher}", characters, expireIn: TimeSpan.FromDays(3));
            return characters;
        }
    }
}
