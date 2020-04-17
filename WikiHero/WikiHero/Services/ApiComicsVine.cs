﻿using MonkeyCache.FileStore;
using Newtonsoft.Json;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WikiHero.Models;
using Xamarin.Essentials;

namespace WikiHero.Services
{
    public class ApiComicsVine : IApiComicsVine
    {
        public ApiComicsVine()
        {
            Barrel.ApplicationId = Config.CacheKey;
        }


        public async Task<ResultCharacters> GetMoreCharacter(string api_key, int offset,string publisher)
        {
            
            var getRequest = RestService.For<IApiComicsVine>(Config.UrlApiComicsVine);
            var characters = await getRequest.GetMoreCharacter(Config.Apikey, offset, publisher);
            return characters;
        }

        public async Task<ResultSeries> GetMoreSeries(string api_key, int offset, string publiser)
        {

            var getRequest = RestService.For<IApiComicsVine>(Config.UrlApiComicsVine);
            var series = await getRequest.GetMoreSeries(Config.Apikey, offset, publiser);
            return series;
        }

        public async Task<ResultVolume> GetMoreVolumes(string api_key, int offset, string publisher)
        {
            var getRequest = RestService.For<IApiComicsVine>(Config.UrlApiComicsVine);
            var volumes = await getRequest.GetMoreVolumes(Config.Apikey, offset, publisher);
            return volumes; ;
        }

        public async Task<ResultCharacters> GetCharacter(string api_key, string publisher)
        {
            if (Connectivity.NetworkAccess != NetworkAccess.Internet && !Barrel.Current.IsExpired($"{nameof(GetCharacter)}/{publisher}"))
            {
                return Barrel.Current.Get<ResultCharacters>(key: $"{nameof(GetCharacter)}/{publisher}");
            }
            var getRequest = RestService.For<IApiComicsVine>(Config.UrlApiComicsVine);
            var characters = await getRequest.GetCharacter(Config.Apikey, publisher);
            Barrel.Current.Add(key: $"{nameof(GetCharacter)}/{publisher}", characters, expireIn: TimeSpan.FromDays(1));
            return characters;
        }

        public async Task<ResultSeries> GetSeries(string api_key, string publisher)
        {
            if (Connectivity.NetworkAccess != NetworkAccess.Internet && !Barrel.Current.IsExpired($"{nameof(GetSeries)}/{publisher}"))
            {
                return Barrel.Current.Get<ResultSeries>(key: $"{nameof(GetSeries)}/{publisher}");
            }

            var getRequest = RestService.For<IApiComicsVine>(Config.UrlApiComicsVine);
            var series = await getRequest.GetSeries(Config.Apikey, publisher);
            Barrel.Current.Add(key: $"{nameof(GetSeries)}/{publisher}", series, expireIn: TimeSpan.FromDays(1));
            return series;
        }

        public async Task<ResultVolume> GetMVolumes(string api_key, string publisher)
        {
            if (Connectivity.NetworkAccess != NetworkAccess.Internet && !Barrel.Current.IsExpired($"{nameof(GetMVolumes)}/{publisher}"))
            {
                return Barrel.Current.Get<ResultVolume>(key: $"{nameof(GetMVolumes)}/{publisher}");
            }
            var getRequest = RestService.For<IApiComicsVine>(Config.UrlApiComicsVine);
            var volumes = await getRequest.GetMVolumes(Config.Apikey, publisher);
            Barrel.Current.Add(key: $"{nameof(GetMVolumes)}/{publisher}", volumes, expireIn: TimeSpan.FromDays(1));
            return volumes; 
        }

        public async Task<ResultVolume> SearchVolume(string name, string api_key, int offset)
        {

            var getRequest = RestService.For<IApiComicsVine>(Config.UrlApiComicsVine);
            var volume = await getRequest.SearchVolume(name, Config.Apikey, offset);
            return volume;
        }

        public async Task<ResultComics> VolumeComics(string api_key, int id, string publisher)
        {
            var getRequest = RestService.For<IApiComicsVine>(Config.UrlApiComicsVine);
            var comics = await getRequest.VolumeComics(Config.Apikey, id, publisher);
            return comics;
        }

        public async Task<ResultLocation> FindLocation(string api_key, string filter)
        {

            var getRequest = RestService.For<IApiComicsVine>(Config.UrlApiComicsVine);
            var location = await getRequest.FindLocation(filter, Config.Apikey);
            return location;
        }

        public async Task<ResultSeries> SearchSeries(string name, string api_key, int offset, string publisher)
        {
            var getRequest = RestService.For<IApiComicsVine>(Config.UrlApiComicsVine);
            var series = await getRequest.SearchSeries(name, Config.Apikey, offset, publisher);
            return series;
        }

        public async Task<ResultEpisode> FindEpisode(string api_key, int id, string publisher)
        {

            var getRequest = RestService.For<IApiComicsVine>(Config.UrlApiComicsVine);
            var episode = await getRequest.FindEpisode(Config.Apikey, id, publisher);
            return episode;
        }

        public async Task<Publisher> FindPublisher(string api_key, int id, string publisher)
        {
            var getRequest = RestService.For<IApiComicsVine>(Config.UrlApiComicsVine);
            var publish = await getRequest.FindPublisher(Config.Apikey, id, publisher);
            return publish;
        }

        public async Task<ResultSeries> GetRecentSeries(string api_key, int offset, string publisher)
        {
            if (Connectivity.NetworkAccess != NetworkAccess.Internet && !Barrel.Current.IsExpired($"{nameof(GetRecentSeries)}/{publisher}"))
            {
                return Barrel.Current.Get<ResultSeries>(key: $"{nameof(GetRecentSeries)}/{publisher}");
            }
            var getRequest = RestService.For<IApiComicsVine>(Config.UrlApiComicsVine);
            var recentSeries = await getRequest.GetRecentSeries(Config.Apikey, 1, publisher);
            Barrel.Current.Add(key: $"{nameof(GetRecentSeries)}/{publisher}", recentSeries, expireIn: TimeSpan.FromDays(1));
            return recentSeries;
        }

        public async Task<ResultVolume> GetRecentVolumes(int offset, string api_key, string publisher)
        {
            if (Connectivity.NetworkAccess != NetworkAccess.Internet && !Barrel.Current.IsExpired($"{nameof(GetRecentVolumes)}/{publisher}"))
            {
                return Barrel.Current.Get<ResultVolume>(key: $"{nameof(GetRecentVolumes)}/{publisher}");
            }
            var getRequest = RestService.For<IApiComicsVine>(Config.UrlApiComicsVine);
            var recentVolumes = await getRequest.GetRecentVolumes(1, Config.Apikey, publisher);
            Barrel.Current.Add(key: $"{nameof(GetRecentVolumes)}/{publisher}", recentVolumes, expireIn: TimeSpan.FromDays(1));
            return recentVolumes;
        }

        public async Task<ResultCharacters> GetRecentCharacters(string api_key, string publisher)
        {
            if (Connectivity.NetworkAccess != NetworkAccess.Internet && !Barrel.Current.IsExpired($"{nameof(GetRecentCharacters)}/{publisher}"))
            {
                return Barrel.Current.Get<ResultCharacters>(key: $"{nameof(GetRecentCharacters)}/{publisher}");
            }
            var getRequest = RestService.For<IApiComicsVine>(Config.UrlApiComicsVine);
            var characters = await getRequest.GetRecentCharacters(Config.Apikey, publisher);
            Barrel.Current.Add(key: $"{nameof(GetRecentCharacters)}/{publisher}", characters, expireIn: TimeSpan.FromDays(1));
            return characters;
        }

        public async Task<ResultTeam> GetTeams(string api_key, string publisher)
        {
            if (Connectivity.NetworkAccess != NetworkAccess.Internet && !Barrel.Current.IsExpired($"{nameof(GetTeams)}/{publisher}"))
            {
                return Barrel.Current.Get<ResultTeam>(key: $"{nameof(GetTeams)}/{publisher}");
            }
            var getRequest = RestService.For<IApiComicsVine>(Config.UrlApiComicsVine);
            var team = await getRequest.GetTeams(Config.Apikey, publisher);
            Barrel.Current.Add(key: $"{nameof(GetTeams)}/{publisher}", team, expireIn: TimeSpan.FromDays(1));
            return team;
        }   

        public async Task<ResultCharacters> SearchCharacters(string name, string api_key, int offset, string publisher)
        {
            
            var getRequest = RestService.For<IApiComicsVine>(Config.UrlApiComicsVine);
            var character = await getRequest.SearchCharacters(name, Config.Apikey, offset, publisher);
            return character;
        }

        public async Task<ResultCharacter> FindCharacter(int id, string api_key, string publisher)
        {
            var getRequest = RestService.For<IApiComicsVine>(Config.UrlApiComicsVine);
            var character = await getRequest.FindCharacter(id, Config.Apikey,publisher);
            return character;
        }

        public async Task<ResultVideo> GetVideo(string api_key, string name, string publisher)
        {
            var getRequest = RestService.For<IApiComicsVine>(Config.UrlApiComicsVine);
            var videos = await getRequest.GetVideo(Config.Apikey, name, publisher);
            return videos; ;
        }

        public async Task<ResultTeam> FindTeamsCharacter(string api_key, string filter)
        {

            var getRequest = RestService.For<IApiComicsVine>(Config.UrlApiComicsVine);
            var characterTeam = await getRequest.FindTeamsCharacter(Config.Apikey, filter);
            return characterTeam;
        }

        public async Task<ResultCharacters> FindEnenmyCharacter(string api_key, string filter)
        {

            var getRequest = RestService.For<IApiComicsVine>(Config.UrlApiComicsVine);
            var characterEnemy = await getRequest.FindEnenmyCharacter(Config.Apikey, filter);
            return characterEnemy;
        }
        public async Task<ResultVolume> FindCharactersVolumes(string api_key, string filter)
        {

            var getRequest = RestService.For<IApiComicsVine>(Config.UrlApiComicsVine);
            var volumes = await getRequest.FindCharactersVolumes(Config.Apikey,filter);
            return volumes;
        }

        public async Task<ResultMovies> FindCharactersMovies(string api_key, string filter)
        {
            var getRequest = RestService.For<IApiComicsVine>(Config.UrlApiComicsVine);
            var movies = await getRequest.FindCharactersMovies(Config.Apikey, filter);
            return movies;
        }

        public async Task<ResultComics> FindCharacterComics(string api_key, string filter)
        {

            var getRequest = RestService.For<IApiComicsVine>(Config.UrlApiComicsVine);
            var comics = await getRequest.FindCharacterComics(Config.Apikey, filter);
            return comics;
        }

        public async Task<ResultComic> FindComic(int id, string api_key)
        {
            var getRequest = RestService.For<IApiComicsVine>(Config.UrlApiComicsVine);
            var comics = await getRequest.FindComic(id,Config.Apikey);
            return comics;
        }
    }
}
