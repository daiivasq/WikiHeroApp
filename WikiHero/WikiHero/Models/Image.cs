using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace WikiHero.Models
{
    public class Image
    {

        [JsonProperty("icon_url")]
        public string IconUrl { get; set; }

        [JsonProperty("medium_url")]
        public string MediumUrl { get; set; }

        [JsonProperty("screen_url")]
        public string ScreenUrl { get; set; }

        [JsonProperty("screen_large_url")]
        public string ScreenLargeUrl { get; set; }

        [JsonProperty("small_url")]
        public string SmallUrl { get; set; }

        [JsonProperty("super_url")]
        public string SuperUrl { get; set; }

        [JsonProperty("thumb_url")]
        public string ThumbUrl { get; set; }

        [JsonProperty("tiny_url")]
        public string TinyUrl { get; set; }

        [JsonProperty("original_url")]
        public string OriginalUrl { get; set; }

        [JsonProperty("image_tags")]
        public string ImageTags { get; set; }
    }
}
