using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace WikiHero.Models
{
    public class Video
    {

        [JsonProperty("api_detail_url")]
        public string ApiDetailUrl { get; set; }

        [JsonProperty("deck")]
        public string Deck { get; set; }

        [JsonProperty("embed_player")]
        public string EmbedPlayer { get; set; }

        [JsonProperty("guid")]
        public string Guid { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("length_seconds")]
        public int LengthSeconds { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("premium")]
        public bool Premium { get; set; }

        [JsonProperty("publish_date")]
        public string PublishDate { get; set; }

        [JsonProperty("site_detail_url")]
        public string SiteDetailUrl { get; set; }

        [JsonProperty("image")]
        public Image Image { get; set; }

        [JsonProperty("user")]
        public string User { get; set; }

        [JsonProperty("hosts")]
        public string Hosts { get; set; }

        [JsonProperty("crew")]
        public string Crew { get; set; }

        [JsonProperty("video_type")]
        public string VideoType { get; set; }

        [JsonProperty("video_show")]
        public object VideoShow { get; set; }


        [JsonProperty("saved_time")]
        public object SavedTime { get; set; }

        [JsonProperty("youtube_id")]
        public string YoutubeId { get; set; }

        [JsonProperty("low_url")]
        public string LowUrl { get; set; }

        [JsonProperty("high_url")]
        public string HighUrl { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }
    }

    public class ResultVideo
    {

        [JsonProperty("results")]
        public IList<Video> Results { get; set; }

    }
}
