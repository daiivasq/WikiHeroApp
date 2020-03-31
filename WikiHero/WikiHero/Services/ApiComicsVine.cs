using MonkeyCache.FileStore;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WikiHero.Models;
using Xamarin.Essentials;

namespace WikiHero.Services
{
    public class ApiComicsVine
    {
        public ApiComicsVine()
        {
            Barrel.ApplicationId = Config.CacheKey;
            Barrel.Current.EmptyExpired();
        }
        public async Task<List<Character>> GetCharacter(string publisher)
        {
            if (!Config.IsCacheExpired($"{nameof(GetCharacter)}/{publisher}"))
            {
                return Barrel.Current.Get<List<Character>>(key: $"{nameof(GetCharacter)}/{publisher}");
            }
            var getRequest = RestService.For<IApiComicsVine>(Config.UrlApiComicsVine);
            var characters = await getRequest.GetCharacter(Config.Apikey);
            var notNull = from item in characters.Characters where item.Publisher != null select item;
            var marvelOrDc = notNull.Where(e => e.Publisher.Name.Contains(publisher));
            Barrel.Current.Add(key: $"{nameof(GetCharacter)}/{publisher}", data: marvelOrDc.ToList(), expireIn: TimeSpan.FromDays(1));
            return marvelOrDc.ToList();
        }
        public async Task<List<Character>> GetMoreCharacter(int offset, string publisher)
        {
            var getRequest = RestService.For<IApiComicsVine>(Config.UrlApiComicsVine);
            var characters = await getRequest.GetMoreCharacter(Config.Apikey, offset);
            var notNull = from item in characters.Characters where item.Publisher != null select item;
            var marvelOrDc = notNull.Where(e => e.Publisher.Name.Contains(publisher));
            Barrel.Current.Add(key: $"{nameof(GetCharacter)}/{publisher}/{offset}", data: marvelOrDc.ToList(), expireIn: TimeSpan.FromDays(1));
            return marvelOrDc.ToList();
        }
        public async Task<Character> FindCharacter(int id)
        {

            var getRequest = RestService.For<IApiComicsVine>(Config.UrlApiComicsVine);
            var character = await getRequest.FindCharacter(id, Config.Apikey);
            return character;
        }
        public async Task<List<Character>> SearchCharacters(string name, int offset)
        {

            var getRequest = RestService.For<IApiComicsVine>(Config.UrlApiComicsVine);
            var character = await getRequest.SearchCharacters(name, Config.Apikey, offset);
            var notNull = from item in character.Characters where item.Publisher != null select item;
            return notNull.ToList();
        }
        public async Task<List<Team>> FindTeamsCharacter(string idUrl)
        {

            var getRequest = RestService.For<IApiComicsVine>(Config.UrlApiComicsVine);
            var characterTeam = await getRequest.FindTeamsCharacter(idUrl, Config.Apikey);
            return characterTeam.Results.ToList();
        }
        public async Task<List<Character>> FindEnenmyCharacter(string idUrl)
        {

            var getRequest = RestService.For<IApiComicsVine>(Config.UrlApiComicsVine);
            var characterEnemy = await getRequest.FindEnenmyCharacter(idUrl, Config.Apikey);
            return characterEnemy.Characters.ToList();
        }
        public async Task<List<Comic>> FindCharacterComics(string idUrl)
        {

            var getRequest = RestService.For<IApiComicsVine>(Config.UrlApiComicsVine);
            var comics = await getRequest.FindCharacterComics(idUrl, Config.Apikey);
            return comics.Results.ToList();
        }
        public async Task<List<Volume>> FindCharactersVolumes(string idUrl)
        {

            var getRequest = RestService.For<IApiComicsVine>(Config.UrlApiComicsVine);
            var volumes = await getRequest.FindCharactersVolumes(idUrl, Config.Apikey);
            return volumes.Volumes.ToList();
        }
        public async Task<List<Movie>> FindCharactersMovies(string idUrl)
        {

            var getRequest = RestService.For<IApiComicsVine>(Config.UrlApiComicsVine);
            var movies = await getRequest.FindCharactersMovies(idUrl, Config.Apikey);
            return movies.Results.ToList();
        }
        public async Task<List<Video>> GetVideos(string api_key, string name)
        {
            var getRequest = RestService.For<IApiComicsVine>(Config.UrlApiComicsVine);
            var videos = await getRequest.GetVideo(Config.Apikey, name);
            return videos.Results.ToList(); ;
        }
        public async Task<Publisher> FindPublisher(int id)
        {
            var getRequest = RestService.For<IApiComicsVine>(Config.UrlApiComicsVine);
            var publisher = await getRequest.FindPublisher(Config.Apikey, id);
            Barrel.Current.Add(key: $"{nameof(FindPublisher)}/{id}",data: publisher,expireIn: TimeSpan.FromDays(1));
            return publisher;
        }

        public async Task<List<Volume>> GetMVolumes(string PublisherPrincipal, string PublisherSecond, string PublisherThird)
        {
            if (!Config.IsCacheExpired($"{nameof(GetMVolumes)}/{PublisherPrincipal}"))
            {
                return Barrel.Current.Get<List<Volume>>(key: $"{nameof(GetMVolumes)}/{PublisherPrincipal}");
            }
            var getRequest = RestService.For<IApiComicsVine>(Config.UrlApiComicsVine);
            var volumes = await getRequest.GetMVolumes(Config.Apikey);
            var notNull = from item in volumes.Volumes where item.Publisher != null select item;
            var marvelOrDc = notNull.Where(e => e.Publisher.Name.Contains(PublisherPrincipal) || e.Publisher.Name.Contains(PublisherSecond) || e.Publisher.Name.Contains(PublisherThird));
            Barrel.Current.Add(key: $"{nameof(GetMVolumes)}/{PublisherPrincipal}", marvelOrDc, expireIn: TimeSpan.FromDays(1));
            return marvelOrDc.ToList(); ;
        }
        public async Task<List<Volume>> GetMoreVolumes(int offset, string PublisherPrincipal, string PublisherSecond, string PublisherThird)
        {
            var getRequest = RestService.For<IApiComicsVine>(Config.UrlApiComicsVine);
            var volumes = await getRequest.GetMoreVolumes(Config.Apikey, offset);
            var notNull = from item in volumes.Volumes where item.Publisher != null select item;
            var marvelOrDc = notNull.Where(e => e.Publisher.Name.Contains(PublisherPrincipal) || e.Publisher.Name.Contains(PublisherSecond) || e.Publisher.Name.Contains(PublisherThird));
            return marvelOrDc.ToList(); ;
        }
        public async Task<List<Volume>> SearchVolume(string name, int offset)
        {

            var getRequest = RestService.For<IApiComicsVine>(Config.UrlApiComicsVine);
            var volume = await getRequest.SearchVolume(name, Config.Apikey, offset);
            var notNull = from item in volume.Volumes where item.Publisher != null select item;
            return notNull.ToList();
        }
        public async Task<List<Comic>> GetComics(int idcomics)
        {

            var getRequest = RestService.For<IApiComicsVine>(Config.UrlApiComicsVine);
            var comics = await getRequest.VolumeComics(Config.Apikey, idcomics);
            return comics.Results.ToList();
        }
        public async Task<List<LocationC>> FindLocation(string idUrl)
        {

            var getRequest = RestService.For<IApiComicsVine>(Config.UrlApiComicsVine);
            var location = await getRequest.FindLocation(idUrl, Config.Apikey);
            return location.Locations.ToList();
        }
        public async Task<List<Serie>> GetSeries(string studioName, string extraStudioName)
        {
            if (!Config.IsCacheExpired($"{nameof(GetMoreSeries)}/{studioName}"))
            {
                return Barrel.Current.Get<List<Serie>>(key: $"{nameof(GetMoreSeries)}/{studioName}");
            }
            var getRequest = RestService.For<IApiComicsVine>(Config.UrlApiComicsVine);
            var series = await getRequest.GetSeries(Config.Apikey);
            var notNull = from item in series.Series where item.Publisher != null select item;
            var marvelOrDc = notNull.Where(e => e.Publisher.Name.Contains(studioName) || e.Publisher.Name.Contains(extraStudioName));
            Barrel.Current.Add(key: $"{nameof(GetMoreSeries)}/{studioName}", marvelOrDc.ToList(), expireIn: TimeSpan.FromDays(1));
            return marvelOrDc.ToList();
        }
        public async Task<List<Serie>> GetMoreSeries(int offset, string studioName, string extraStudioName)
        {
            var getRequest = RestService.For<IApiComicsVine>(Config.UrlApiComicsVine);
            var series = await getRequest.GetMoreSeries(Config.Apikey, offset);
            var notNull = from item in series.Series where item.Publisher != null select item;
            var marvelOrDc = notNull.Where(e => e.Publisher.Name.Contains(studioName) || e.Publisher.Name.Contains(extraStudioName));
            return marvelOrDc.ToList();
        }
        public async Task<List<Serie>> FindSeries(string name, int offset)
        {
           
            var getRequest = RestService.For<IApiComicsVine>(Config.UrlApiComicsVine);
            var series = await getRequest.SearchSeries(name, Config.Apikey,offset);
            var notNull = from item in series.Series where item.Publisher != null select item;
            return notNull.ToList();
        }
        public async Task<List<Episode>> GetEpisode(int idseries)
        {

            var getRequest = RestService.For<IApiComicsVine>(Config.UrlApiComicsVine);
            var episode = await getRequest.FindEpisode(Config.Apikey, idseries);
            return episode.Results.ToList();
        }
        
        public async Task<List<Serie>> GetRecentSeries(string studioName,string extraStudioName)
        {
            if (!Config.IsCacheExpired($"{nameof(GetMoreSeries)}/{studioName}"))
            {
                return Barrel.Current.Get<List<Serie>>(key: $"{nameof(GetRecentSeries)}/{studioName}");
            }
            var getRequest = RestService.For<IApiComicsVine>(Config.UrlApiComicsVine);
            var recentSeries = await getRequest.GetRecentSeries(Config.Apikey, 1);
            var notNull = from item in recentSeries.Series where item.Publisher != null select item;
            var marvelOrDc = notNull.Where(e => e.Publisher.Name == studioName || e.Publisher.Name == extraStudioName);
            Barrel.Current.Add(key: $"{nameof(GetRecentSeries)}/{studioName}", marvelOrDc.ToList(), expireIn: TimeSpan.FromDays(1));
            return marvelOrDc.ToList();
        }
        public async Task<List<Volume>> GetRecentVolumes(string publisherPrincipal, string publisherSecond, string publisherThird)
        {
            if (!Config.IsCacheExpired($"{nameof(GetRecentVolumes)}/{publisherPrincipal}"))
            {
                return Barrel.Current.Get<List<Volume>>(key: $"{nameof(GetRecentVolumes)}/{publisherPrincipal}");
            }
            var getRequest = RestService.For<IApiComicsVine>(Config.UrlApiComicsVine);
            var recentVolumes = await getRequest.GetRecentVolumes(1,Config.Apikey);
            var notNull = from item in recentVolumes.Volumes where item.Publisher != null select item;
            var marvelOrDc = notNull.Where(e => e.Publisher.Name == publisherPrincipal || e.Publisher.Name == publisherSecond || e.Publisher.Name == publisherThird);
            Barrel.Current.Add(key: $"{nameof(GetRecentVolumes)}/{publisherPrincipal}", marvelOrDc.ToList(), expireIn: TimeSpan.FromDays(1));
            return marvelOrDc.ToList();
        }
        public async Task<List<Character>> GetRecentCharacters(string publisher)
        {
            if (!Config.IsCacheExpired($"{nameof(GetRecentCharacters)}/{publisher}"))
            {
                return Barrel.Current.Get<List<Character>>(key: $"{nameof(GetRecentCharacters)}/{publisher}");
            }
            var getRequest = RestService.For<IApiComicsVine>(Config.UrlApiComicsVine);
            var characters = await getRequest.GetRecentCharacters(Config.Apikey);
            var notNull = from item in characters.Characters where item.Publisher != null select item;
            var marvelOrDc = notNull.Where(e => e.Publisher.Name.Contains(publisher));
            Barrel.Current.Add(key: $"{nameof(GetRecentCharacters)}/{publisher}", data: marvelOrDc.ToList(), expireIn: TimeSpan.FromDays(1));
            return marvelOrDc.ToList();
        }
        public async Task<List<Team>> GetTeams(string publisher)
        {
            if (!Config.IsCacheExpired($"{nameof(GetTeams)}/{publisher}"))
            {
                return Barrel.Current.Get<List<Team>>(key: $"{nameof(GetTeams)}/{publisher}");
            }
            var getRequest = RestService.For<IApiComicsVine>(Config.UrlApiComicsVine);
            var team = await getRequest.GetTeams(Config.Apikey);
            var notNull = from item in team.Results where item.Publisher != null select item;
            var marvelOrDc = notNull.Where(e => e.Publisher.Name.Contains(publisher));
            Barrel.Current.Add(key: $"{nameof(GetTeams)}/{publisher}", data: marvelOrDc.ToList(), expireIn: TimeSpan.FromDays(1));
            return marvelOrDc.ToList();
        }

    }
}
