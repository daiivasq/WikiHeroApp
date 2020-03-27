using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace WikiHero.Models
{
    public class Episode
    {
        [JsonProperty("aliases")]
        public object Aliases { get; set; }

        [JsonProperty("api_detail_url")]
        public string ApiDetailUrl { get; set; }

        [JsonProperty("air_date")]
        public string AirDate { get; set; }

        [JsonProperty("date_added")]
        public string DateAdded { get; set; }

        [JsonProperty("date_last_updated")]
        public string DateLastUpdated { get; set; }

        [JsonProperty("deck")]
        public object Deck { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("image")]
        public Image Image { get; set; }

        [JsonProperty("episode_number")]
        public string EpisodeNumber { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("site_detail_url")]
        public string SiteDetailUrl { get; set; }

        [JsonProperty("series")]
        public Serie Serie { get; set; }
    }

    public class ResultEpisode
    {

        [JsonProperty("results")]
        public IList<Episode> Results { get; set; }

    }
}
