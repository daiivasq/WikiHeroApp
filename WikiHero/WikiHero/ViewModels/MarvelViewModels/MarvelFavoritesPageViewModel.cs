using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Text;
using WikiHero.Services;

namespace WikiHero.ViewModels.MarvelViewModels
{
    public class MarvelFavoritesPageViewModel:FavoritePageViewModel
    {
        protected const string MarvelComics = "Marvel";
        public MarvelFavoritesPageViewModel(INavigationService navigationService, IPageDialogService dialogService, IApiComicsVine apiComicsVine,IDBFavorites dBFavorites) : base(dBFavorites,navigationService, dialogService, apiComicsVine, MarvelComics)
        {

        }
    }
}
