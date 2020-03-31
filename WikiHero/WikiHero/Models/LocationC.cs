using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace WikiHero.Models
{
    public class LocationC
    {

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("image")]
        public Image Image { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }

    public class ResultLocation
    {

        [JsonProperty("results")]
        public IList<LocationC> Locations { get; set; }

    }

}
