using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using WikiHero.Models;
using WikiHero.Services;

namespace WikiHero.ViewModels
{
    public abstract class FavoritePageViewModel : BaseViewModel
    {
        IDBFavorites dBFavorite;
        public string Publisher { get; set; }
        public FavoritePageViewModel(IDBFavorites dBFavorites,INavigationService navigationService, IPageDialogService dialogService, IApiComicsVine apiComicsVine, string publisherPrincipal) : base(navigationService, dialogService, apiComicsVine)
        {
            this.dBFavorite = dBFavorites;
            Publisher = publisherPrincipal;
            GetCharacter();
            GetComic();
            
            GetSeries();
            GetVolume();

        }

        public ObservableCollection<Serie> Series { get; set; } = new ObservableCollection<Serie>();
        public ObservableCollection<Character> Characters { get; set; } = new ObservableCollection<Character>();
        public ObservableCollection<Volume> Volumes { get; set; } = new ObservableCollection<Volume>();
        public ObservableCollection<Comic> Comics { get; set; } = new ObservableCollection<Comic>();
        

        void GetSeries ()
        {
            var series = dBFavorite.GetSeries(Publisher);
            Series  = new ObservableCollection<Serie>(series); 
        }
        void GetCharacter() 
        {
            var character = dBFavorite.GetCharacter(Publisher);
            Characters = new ObservableCollection<Character>(character);
        }
        void GetComic() 
        {
            var comics = dBFavorite.GetComic(Publisher);
            Comics = new ObservableCollection<Comic>(comics);
        }
        
        void GetVolume() 
        {
            var volumes = dBFavorite.GetVolume(Publisher);
            Volumes = new ObservableCollection<Volume>(volumes);
        }
    }
}
