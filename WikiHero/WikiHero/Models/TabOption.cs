using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;

namespace WikiHero.Models
{
    
    public class TabOption : INotifyPropertyChanged
    {
        public string Name { get; set; }
        public bool IsSelected { get; set; }

        public string TitleSeries { get; set; }
        public string TitleCharacter { get; set; }
        public string TitleVolume { get; set; }


        public event PropertyChangedEventHandler PropertyChanged;
    }
}
