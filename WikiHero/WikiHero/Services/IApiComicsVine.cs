using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WikiHero.Models;

namespace WikiHero.Services
{
    public interface IApiComicsVine 
    {
        [Get("/api/characters?api_key={api_key}&format=json&limit=100&offset={offset}&filter=date_last_updated: 2018-12-18 10:49:41|2020-03-06 13:15:56")]
        Task<ResultCharacter> GetMoreCharacter(string api_key, int offset,string publisher);
        
        [Get("/api/series_list?api_key={api_key}&format=json&offset={offset}&filter=date_last_updated : 2018-09-02 17:47:38|2020-03-10 11:00:00&sort=date_last_updated : desc")]
        Task<ResultSeries> GetMoreSeries(string api_key, int offset, string publisher);

        [Get("/api/volumes?api_key={api_key}&format=json&offset={offset}&filter=date_last_updated : 2018-09-02 17:47:38|2020-03-10 11:00:00&sort=date_last_updated : desc")]
        Task<ResultVolume> GetMoreVolumes(string api_key, int offset, string publisher);
        [Get("/api/characters?api_key={api_key}&format=json&limit=100&offset=0&filter=date_last_updated: 2018-12-18 10:49:41|2020-03-06 13:15:56")]
        Task<ResultCharacter> GetCharacter(string api_key, string publisher);

        [Get("/api/series_list?api_key={api_key}&format=json&offset=0&filter=date_last_updated : 2018-09-02 17:47:38|2020-03-10 11:00:00&sort=date_last_updated : desc")]
        Task<ResultSeries> GetSeries(string api_key,string publisher);

        [Get("/api/volumes?api_key={api_key}&format=json&offset=0&filter=date_last_updated : 2018-09-02 17:47:38|2020-03-10 11:00:00&sort=date_last_updated : desc")]
        Task<ResultVolume> GetMVolumes(string api_key,string publisher);


        //volumes

        [Get("/api/volumes?format=json&filter=name:{name}&api_key={api_key}")]
        Task<ResultVolume> SearchVolume(string name, string api_key, int offset);

        //issues
        [Get("/api/issues?format=json&api_key={api_key}&limit=100&filter=volume:{id}")]
        Task<ResultComics> VolumeComics(string api_key, int id,string publisher);

        [Get("/api/locations?format=json&api_key={api_key}&limit=100&filter=id:{filter}")]
        Task<ResultLocation> FindLocation(string api_key, string filter, string publisher);

        //series

        [Get("/api/series_list?format=json&filter=name:{name}&api_key={api_key}")]
        Task<ResultSeries> SearchSeries(string name, string api_key, int offset, string publisher);
        
         [Get("/api/episodes?format=json&api_key={api_key}&filter=series:{id}")]
        Task<ResultEpisode> FindEpisode(string api_key, int id, string publisher);

        //publisher
        [Get("/api/publisher/4010-{id}?format=json&field_list=id,name,api_detail_url,publisher,image,characters,teams,volumes&api_key={api_key}")]
        Task<Publisher> FindPublisher(string api_key, int id, string publisher);

        //Home 
        [Get("/api/series_list?format=json&sort=date_added:desc&api_key={api_key}&offset={offset}")]
        Task<ResultSeries> GetRecentSeries(string api_key, int offset, string publisher);
        [Get("/api/volumes?format=json&sort=date_added:desc&offset={offset}&api_key={api_key}")]
        Task<ResultVolume> GetRecentVolumes(int offset,string api_key, string publisher);
        [Get("/api/characters?format=json&sort=date_added:desc&api_key={api_key}")]
        Task<ResultCharacter> GetRecentCharacters(string api_key, string publisher);

        [Get("/api/teams?format=json&api_key={api_key}&limit=100")]
        Task<ResultTeam> GetTeams(string api_key, string publisher);

        //Characters
        [Get("/api/characters?format=json&filter=name:{name}&api_key={api_key}")]
        Task<ResultCharacter> SearchCharacters(string name, string api_key, int offset, string publisher);
        [Get("/api/character/4005-{id}?format=json& api_key={api_key}")]
        Task<Character> FindCharacter(int id, string api_key, string publisher);
        [Get("/api/videos?format=json&filter=name:{name}&api_key={api_key}&limit=30")]
        Task<ResultVideo> GetVideo(string api_key,string name, string publisher);
        [Get("/api/teams?format=json&field_list=id,name,date_added&api_key={api_key}&filter=id:{filter}")]
        Task<ResultTeam> FindTeamsCharacter(string api_key, string filter, string publisher);
        [Get("/api/characters?format=json&api_key={api_key}&filter=id:{filter}")]
        Task <ResultCharacter> FindEnenmyCharacter(string api_key, string filter, string publisher);
        [Get("/api/issues?format=json&api_key={api_key}&limit=100&filter=id:{filter}")]
        Task<ResultComics> FindCharacterComics(string api_key, string filter, string publisher);
        [Get("/api/volumes?format=json&api_key={api_key}&limit=100&filter=id:{filter}")]
        Task<ResultVolume> FindCharactersVolumes(string api_key, string filter, string publisher);

        [Get("/api/movies?format=json&api_key={api_key}&limit=100&filter=id:{filter}")]
        Task<ResultMovies> FindCharactersMovies(string api_key, string filter, string publisher);



    }
}
