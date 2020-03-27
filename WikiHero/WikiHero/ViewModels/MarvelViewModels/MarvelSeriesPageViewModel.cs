using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Text;
using WikiHero.Models;
using WikiHero.Services;

namespace WikiHero.ViewModels.MarvelViewModels
{
    public class MarvelSeriesPageViewModel : SeriePageViewModel
    {

        private const string MarvelUniverse = "Marvel";
        private const string Disney = "Disney";
        private const int Offset = 0;
        public MarvelSeriesPageViewModel(INavigationService navigationService, IPageDialogService dialogService, ApiComicsVine apiComicsVine) : base(navigationService, dialogService, apiComicsVine, MarvelUniverse, Disney, Offset)
        {
            LoadListCommand = new DelegateCommand(async () =>
            {
                await LoadSeries(Offset);
            });
            LoadListCommand.Execute();
          
        }


    }
}
