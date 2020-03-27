using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Text;
using WikiHero.Services;

namespace WikiHero.ViewModels.MarvelViewModels
{
    public class MarvelCompareCharacterPageViewModel: CompareCharactersPageViewModel
    {
        protected const string MarvelComics = "Marvel Comics";
        public MarvelCompareCharacterPageViewModel(INavigationService navigationService, IPageDialogService dialogService, ApiComicsVine apiComicsVine, ApiStatsCharacters apiStatsCharacters) : base(navigationService, dialogService, apiComicsVine, apiStatsCharacters, MarvelComics)
        {

        }
    }
}
