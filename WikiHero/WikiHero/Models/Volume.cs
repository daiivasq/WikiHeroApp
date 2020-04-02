using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace WikiHero.Models
{
    public class Volume
    {

        [JsonProperty("aliases")]
        public string Aliases { get; set; }


        [JsonProperty("count_of_issues")]
        public int CountOfIssues { get; set; }

        [JsonProperty("date_added")]
        public string DateAdded { get; set; }

        [JsonProperty("date_last_updated")]
        public string DateLastUpdated { get; set; }

        [JsonProperty("deck")]
        public string Deck { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }


        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("image")]
        public Image Image { get; set; }


        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("publisher")]
        public Publisher Publisher { get; set; }

        [JsonProperty("start_year")]
        public string StartYear { get; set; }
    }

    public class ResultVolume
    {

        [JsonProperty("results")]
        public IList<Volume> Volumes { get; set; }
    }
}
