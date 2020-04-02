using MonkeyCache.FileStore;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;

namespace WikiHero.Services
{
    public static class Config
    {
        public const string Apikey = "25ad183b2735436b99524296c511af292c8a011f";
        public const string UrlApiComicsVine = "https://comicvine.gamespot.com";
        public const string UrlApiCharactersStats = "https://cdn.rawgit.com/akabab/superhero-api/0.2.0/api";
        public const string CacheKey = "WikiHeroCache";
        public static bool IsNetworkAvalible()
        {
            if (Connectivity.NetworkAccess == NetworkAccess.Internet)
            {
                return true;
            }
            return false;
        }
        public static bool IsCacheExpired(string key)
        {
            if (!Barrel.Current.IsExpired(key: key))
            {
                return false;
            }
            return true;
        }
    }
}
