using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Text;
using WikiHero.Services;

namespace WikiHero.ViewModels.DCViewModels
{
   public class DcFavoritesPageViewModel:FavoritePageViewModel
    {
        protected const string DC = "DC";
        public DcFavoritesPageViewModel(INavigationService navigationService, IPageDialogService dialogService, IApiComicsVine apiComicsVine, IDBFavorites dBFavorites) : base(dBFavorites, navigationService, dialogService, apiComicsVine, DC)
        {

        }
    }
}
