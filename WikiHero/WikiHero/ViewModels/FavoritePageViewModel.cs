using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using WikiHero.Models;

namespace WikiHero.ViewModels
{
    public class FavoritePageViewModel
    {
        public ObservableCollection<Serie> Series { get; set; } = new ObservableCollection<Serie>();
        public ObservableCollection<Character> Characters { get; set; } = new ObservableCollection<Character>();
        public ObservableCollection<Volume> Volumes { get; set; } = new ObservableCollection<Volume>();
        public ObservableCollection<Comic> Comics { get; set; } = new ObservableCollection<Comic>();
        public ObservableCollection<Movie> Movies { get; set; } = new ObservableCollection<Movie>();


    }
}
