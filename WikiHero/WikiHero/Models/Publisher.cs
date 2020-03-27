using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace WikiHero.Models
{
   public  class Publisher
    {
        [JsonProperty("api_detail_url")]
        public string ApiDetailUrl { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
