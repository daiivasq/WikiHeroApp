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
        

        protected void GetSeries ()
        {
            var series = dBFavorite.GetSeries(Publisher);
            if (Series != null)
            {
                Series = new ObservableCollection<Serie>(series);

            }
        
        }
        protected void GetCharacter() 
        {

            var character = dBFavorite.GetCharacter(Publisher);
            if (character != null)
            {
                Characters = new ObservableCollection<Character>(character);
            }

        }
       protected void GetComic() 
        {
            var comics = dBFavorite.GetComic(Publisher);
            if (comics != null)
            {
                Comics = new ObservableCollection<Comic>(comics);
            }

        }
        
       protected void GetVolume() 
        {
            var volumes = dBFavorite.GetVolume(Publisher);
            if (volumes != null)
            {
                Volumes = new ObservableCollection<Volume>(volumes);
            }

        }
    }
}
