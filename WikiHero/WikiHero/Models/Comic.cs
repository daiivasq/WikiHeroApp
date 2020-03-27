using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace WikiHero.Models
{
    public class Comic
    {

        [JsonProperty("api_detail_url")]
        public string ApiDetailUrl { get; set; }

        [JsonProperty("box_office_revenue")]
        public string BoxOfficeRevenue { get; set; }

        [JsonProperty("date_added")]
        public string DateAdded { get; set; }

        [JsonProperty("date_last_updated")]
        public string DateLastUpdated { get; set; }

        [JsonProperty("deck")]
        public string Deck { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("distributor")]
        public object Distributor { get; set; }

        [JsonProperty("has_staff_review")]
        public object HasStaffReview { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("image")]
        public Image Image { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("producers")]
        public object Producers { get; set; }

        [JsonProperty("rating")]
        public string Rating { get; set; }

        [JsonProperty("release_date")]
        public string ReleaseDate { get; set; }

        [JsonProperty("runtime")]
        public string Runtime { get; set; }

        [JsonProperty("site_detail_url")]
        public string SiteDetailUrl { get; set; }

        [JsonProperty("studios")]
        public IList<Studio> Studios { get; set; }

        [JsonProperty("total_revenue")]
        public string TotalRevenue { get; set; }

        [JsonProperty("writers")]
        public IList<Writer> Writers { get; set; }
    }
    public class ResultComics
    {

        [JsonProperty("results")]
        public IList<Comic> Results { get; set; }
        
    }
}
