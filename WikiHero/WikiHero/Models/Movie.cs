using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace WikiHero.Models
{
    public class Movie
    {
       
        [JsonProperty("date_added")]
        public string DateAdded { get; set; }


        [JsonProperty("deck")]
        public string Deck { get; set; }

        [JsonProperty("description")]
        private string description;

        public string Description
        {
            get { return description.Replace("</p>", ""); ; }
            set { description = value; }
        }

        [JsonProperty("distributor")]
        public object Distributor { get; set; }


        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("image")]
        public Image Image { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("rating")]
        public string Rating { get; set; }

        [JsonProperty("release_date")]
        public string ReleaseDate { get; set; }

        [JsonProperty("site_detail_url")]
        public string SiteDetailUrl { get; set; }

        [JsonProperty("studios")]
        public IList<Studio> Studios { get; set; }

        [JsonProperty("writers")]
        public IList<Writer> Writers { get; set; }
        
    }
    public class ResultMovies
    {
        [JsonProperty("results")]
        public IList<Movie> Results { get; set; }
    }
}
