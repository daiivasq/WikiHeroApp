using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Text;
using WikiHero.Services;

namespace WikiHero.ViewModels.MarvelViewModels
{
    public class MarvelHomePageViewModel : HomePageViewModel
    {
        private const string MarvelUniverse = "Marvel";
        private const string FawcettPublications = "Fawcett Publications";
        private const string Atlas = "Atlas";
        private const string Disney = "Disney";
        public MarvelHomePageViewModel(INavigationService navigationService, IPageDialogService dialogService, IApiComicsVine apiComicsVine) : base(navigationService, dialogService, apiComicsVine, MarvelUniverse, FawcettPublications, Atlas,Disney)
          
        {

        }
    }
}
