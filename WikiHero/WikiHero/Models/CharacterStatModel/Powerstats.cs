using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace WikiHero.Models.CharacterStatModel
{
    public class Powerstats
    {

        [JsonProperty("intelligence")]
        public int Intelligence { get; set; }

        [JsonProperty("strength")]
        public int Strength { get; set; }

        [JsonProperty("speed")]
        public int Speed { get; set; }

        [JsonProperty("durability")]
        public int Durability { get; set; }

        [JsonProperty("power")]
        public int Power { get; set; }

        [JsonProperty("combat")]
        public int Combat { get; set; }
        public int Average { get=> (Speed+Intelligence+Strength+Durability+Power+Combat)/6; }
    }
}
