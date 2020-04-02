using System;
using System.Collections.Generic;
using System.Text;

namespace WikiHero.Models
{
    public class ItemPage
    {
        public string Image { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
        public ItemPage(string image,string title,string url)
        {
            this.Image = image;
            Title = title;
            Url = url;
        }
    }
}
