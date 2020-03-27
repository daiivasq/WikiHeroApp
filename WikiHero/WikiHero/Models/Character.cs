using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace WikiHero.Models
{
   public class Character
    {
        [JsonProperty("aliases")]
        public string Aliases { get; set; }

        [JsonProperty("api_detail_url")]
        public string ApiDetailUrl { get; set; }

        [JsonProperty("birth")]
        public object Birth { get; set; }

        [JsonProperty("count_of_issue_appearances")]
        public int CountOfIssueAppearances { get; set; }

        [JsonProperty("date_added")]
        public string DateAdded { get; set; }

        [JsonProperty("date_last_updated")]
        public string DateLastUpdated { get; set; }

        [JsonProperty("deck")]
        public string Deck { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("gender")]
        public int Gender { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("image")]
        public Image Image { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("origin")]
        public Origin Origin { get; set; }

        [JsonProperty("publisher")]
        public Publisher Publisher { get; set; }

        [JsonProperty("real_name")]
        public string RealName { get; set; }
    }
    public class ResultCharacter
    {

        [JsonProperty("results")]
        public IList<Character> Characters { get; set; }

        [JsonProperty("version")]
        public string Version { get; set; }
    }
}
