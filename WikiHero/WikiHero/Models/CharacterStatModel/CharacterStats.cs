using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace WikiHero.Models.CharacterStatModel
{
    public class Biography
    {

        [JsonProperty("fullName")]
        public string FullName { get; set; }

        [JsonProperty("publisher")]
        public string Publisher { get; set; }

        [JsonProperty("alignment")]
        public string Alignment { get; set; }
    }

    public class Images
    {

        [JsonProperty("xs")]
        public string Xs { get; set; }

        [JsonProperty("sm")]
        public string Sm { get; set; }

        [JsonProperty("md")]
        public string Md { get; set; }

        [JsonProperty("lg")]
        public string Lg { get; set; }
    }

    public class CharacterStats
    {

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("slug")]
        public string Slug { get; set; }

        [JsonProperty("powerstats")]
        public Powerstats Powerstats { get; set; }

        [JsonProperty("biography")]
        public Biography Biography { get; set; }

        [JsonProperty("images")]
        public Images Images { get; set; }
    }
}
