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
        private bool NetworkAvalible(string key)
        {
            if (Connectivity.NetworkAccess != NetworkAccess.Internet || !Barrel.Current.IsExpired(key: key))
            {
                return false;
            }
            return true;
        }
        public ApiComicsVine()
        {

            Barrel.ApplicationId = Config.CacheKey;
           

        }
        const string MkeyCharacter = "GetAllCharacter/Marvel";
        const string DkeyCharacter = "GetAllCharacter/Dc";
        public async Task<List<Character>> GetMoreCharacter(int offset, string publisher)
        {
            string Ckey = publisher.StartsWith("M") ? MkeyCharacter : DkeyCharacter;
            var getRequest = RestService.For<IApiComicsVine>(Config.UrlApiComicsVine);
            var characters = await getRequest.GetAllCharacter(Config.Apikey, offset);
            var notNull = from item in characters.Characters where item.Publisher != null select item;
            var marvelOrDc = notNull.Where(e => e.Publisher.Name.Contains(publisher));
            Barrel.Current.Add(key: Ckey, data: marvelOrDc.ToList(), expireIn: TimeSpan.FromDays(1));
            return marvelOrDc.ToList();
        }
        public async Task<List<Character>> GetAllCharacter(int offset,string publisher)
        {
            string Ckey = publisher.StartsWith("M") ? MkeyCharacter : DkeyCharacter;
            if (!NetworkAvalible(Ckey))
            {
                await Task.Yield();
                return Barrel.Current.Get<List<Character>>(key: Ckey);
            }
            var getRequest = RestService.For<IApiComicsVine>(Config.UrlApiComicsVine);
            var characters = await getRequest.GetAllCharacter(Config.Apikey,offset);
            var notNull = from item in characters.Characters where item.Publisher != null select item;
            var marvelOrDc = notNull.Where(e => e.Publisher.Name.Contains(publisher));
            Barrel.Current.Add(key: Ckey,data: marvelOrDc.ToList(),expireIn: TimeSpan.FromDays(1));
            return marvelOrDc.ToList();
        }

        public async Task<List<Volume>> GetMoreVolumes(int offset, string PublisherPrincipal, string PublisherSecond, string PublisherThird)
        {
            var getRequest = RestService.For<IApiComicsVine>(Config.UrlApiComicsVine);
            var volumes = await getRequest.GetAllVolumes(Config.Apikey, offset);
            var notNull = from item in volumes.Volumes where item.Publisher != null select item;
            var marvelOrDc = notNull.Where(e => e.Publisher.Name.Contains(PublisherPrincipal) || e.Publisher.Name.Contains(PublisherSecond) || e.Publisher.Name.Contains(PublisherThird));
            Barrel.Current.Add(key: $"{nameof(GetAllVolumes)}/{PublisherPrincipal}", marvelOrDc, expireIn: TimeSpan.FromDays(1));
            return marvelOrDc.ToList(); ;
        }
        public async Task<List<Volume>> GetAllVolumes(int offset,string publisherPrincipal,string publisherSecond,string publisherThird)
        {
            if (!NetworkAvalible($"{nameof(GetAllVolumes)}/{publisherPrincipal}"))
            {
                await Task.Yield();
                return Barrel.Current.Get<List<Volume>>(key: $"{nameof(GetAllVolumes)}/{publisherPrincipal}");
            }
            var getRequest = RestService.For<IApiComicsVine>(Config.UrlApiComicsVine);
            var volumes = await getRequest.GetAllVolumes(Config.Apikey,offset);
            var notNull = from item in volumes.Volumes where item.Publisher != null select item;
            var marvelOrDc = notNull.Where(e => e.Publisher.Name.Contains(publisherPrincipal) || e.Publisher.Name.Contains(publisherSecond) || e.Publisher.Name.Contains(publisherThird));
            Barrel.Current.Add(key:$"{nameof(GetAllVolumes)}/{publisherPrincipal}", marvelOrDc.ToList(), expireIn: TimeSpan.FromDays(1));
            return marvelOrDc.ToList();
        }
        public async Task<List<Serie>> GetMoreSeries(int offset, string studioName, string extraStudioName)
        {
            var getRequest = RestService.For<IApiComicsVine>(Config.UrlApiComicsVine);
            var series = await getRequest.GetAllSeries(Config.Apikey, offset);
            var notNull = from item in series.Series where item.Publisher != null select item;
            var marvelOrDc = notNull.Where(e => e.Publisher.Name.Contains(studioName) || e.Publisher.Name.Contains(extraStudioName));
            Barrel.Current.Add(key: $"{nameof(GetAllSeries)}/{studioName}", marvelOrDc, expireIn: TimeSpan.FromDays(1));
            return marvelOrDc.ToList();
        }
        public async Task<List<Serie>> GetAllSeries(int offset, string studioName, string extraStudioName)
        {
            if (!NetworkAvalible($"{nameof(GetAllSeries)}/{studioName}"))
            {
                await Task.Yield();
                return Barrel.Current.Get<List<Serie>>(key: $"{nameof(GetAllSeries)}/{studioName}");
            }
            var getRequest = RestService.For<IApiComicsVine>(Config.UrlApiComicsVine);
            var series = await getRequest.GetAllSeries(Config.Apikey,offset);
            var notNull = from item in series.Series where item.Publisher != null select item;
            var marvelOrDc = notNull.Where(e => e.Publisher.Name == studioName || e.Publisher.Name == extraStudioName);
            Barrel.Current.Add(key: $"{nameof(GetAllSeries)}/{studioName}", marvelOrDc.ToList(), expireIn: TimeSpan.FromDays(1));
            return notNull.ToList();
        }
        
        public async Task<List<Character>> FindCharacter(string name, int offset)
        {
           
            var getRequest = RestService.For<IApiComicsVine>(Config.UrlApiComicsVine);
            var character = await getRequest.FindCharacter(name, Config.Apikey,offset);
            var notNull = from item in character.Characters where item.Publisher != null select item;
            return notNull.ToList();
        }
        public async Task<List<Volume>>FindVolume(string name, int offset)
        {
           
            var getRequest = RestService.For<IApiComicsVine>(Config.UrlApiComicsVine);
            var volume = await getRequest.FindVolume(name, Config.Apikey,offset);
            var notNull = from item in volume.Volumes where item.Publisher != null select item;
            return notNull.ToList();
        }
        public async Task<List<Serie>> FindSeries(string name, int offset)
        {
           
            var getRequest = RestService.For<IApiComicsVine>(Config.UrlApiComicsVine);
            var series = await getRequest.FindSeries(name, Config.Apikey,offset);
            var notNull = from item in series.Series where item.Publisher != null select item;
            return notNull.ToList();
        }
        public async Task<List<Episode>> GetEpisode(int idseries)
        {

            var getRequest = RestService.For<IApiComicsVine>(Config.UrlApiComicsVine);
            var episode = await getRequest.FindEpisode(Config.Apikey, idseries);
            return episode.Results.ToList();
        }
        public async Task<List<Comic>> GetComics(int idcomics)
        {

            var getRequest = RestService.For<IApiComicsVine>(Config.UrlApiComicsVine);
            var comics = await getRequest.FindComics(Config.Apikey, idcomics);
            return comics.Results.ToList();
        }
        public async Task<List<Serie>> GetRecentSeries(string studioName,string extraStudioName)
        {
            var getRequest = RestService.For<IApiComicsVine>(Config.UrlApiComicsVine);
            var recentSeries = await getRequest.GetRecentSeries(Config.Apikey, 1);
            var notNull = from item in recentSeries.Series where item.Publisher != null select item;
            var marvelOrDc = notNull.Where(e => e.Publisher.Name == studioName || e.Publisher.Name == extraStudioName);
            Barrel.Current.Add(key: $"{nameof(GetRecentSeries)}/{studioName}", marvelOrDc.ToList(), expireIn: TimeSpan.FromDays(1));
            return marvelOrDc.ToList();
        }
        public async Task<List<Volume>> GetRecentVolumes(string publisherPrincipal, string publisherSecond, string publisherThird)
        {
            var getRequest = RestService.For<IApiComicsVine>(Config.UrlApiComicsVine);
            var recentVolumes = await getRequest.GetRecentVolumes(1,Config.Apikey);
            var notNull = from item in recentVolumes.Volumes where item.Publisher != null select item;
            var marvelOrDc = notNull.Where(e => e.Publisher.Name == publisherPrincipal || e.Publisher.Name == publisherSecond || e.Publisher.Name == publisherThird);
            Barrel.Current.Add(key: $"{nameof(GetRecentVolumes)}/{publisherPrincipal}", marvelOrDc.ToList(), expireIn: TimeSpan.FromDays(1));
            return marvelOrDc.ToList();
        }
        public async Task<List<Character>> GetRecentCharacters(string publisher)
        {

            var getRequest = RestService.For<IApiComicsVine>(Config.UrlApiComicsVine);
            var characters = await getRequest.GetRecentCharacters(Config.Apikey);
            var notNull = from item in characters.Characters where item.Publisher != null select item;
            var marvelOrDc = notNull.Where(e => e.Publisher.Name.Contains(publisher));
            Barrel.Current.Add(key: $"{nameof(GetRecentCharacters)}/{publisher}", data: marvelOrDc.ToList(), expireIn: TimeSpan.FromDays(1));
            return marvelOrDc.ToList();
        }
        public async Task<List<Team>> GetTeams(string publisher)
        {

            var getRequest = RestService.For<IApiComicsVine>(Config.UrlApiComicsVine);
            var team = await getRequest.GetTeams(Config.Apikey);
            var notNull = from item in team.Results where item.Publisher != null select item;
            var marvelOrDc = notNull.Where(e => e.Publisher.Name.Contains(publisher));
            Barrel.Current.Add(key: $"{nameof(GetRecentCharacters)}/{publisher}", data: marvelOrDc.ToList(), expireIn: TimeSpan.FromDays(1));
            return marvelOrDc.ToList();
        }

    }
}
