using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Text;
using WikiHero.Services;

namespace WikiHero.ViewModels.DCViewModels
{
    public class DcCompareCharacterPageViewModel:CompareCharactersPageViewModel
    {
        protected const string MarvelComics = "DC Comics";
        public DcCompareCharacterPageViewModel(INavigationService navigationService, IPageDialogService dialogService, ApiComicsVine apiComicsVine, ApiStatsCharacters apiStatsCharacters) : base(navigationService, dialogService, apiComicsVine, apiStatsCharacters, MarvelComics)
        {

        }
    }
}
