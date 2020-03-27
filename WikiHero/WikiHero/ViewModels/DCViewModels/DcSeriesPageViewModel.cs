using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Text;
using WikiHero.Services;

namespace WikiHero.ViewModels.DCViewModels
{
    public class DcSeriesPageViewModel : SeriePageViewModel
    {
        private const string DcUniverse = "DC";
        private const string WarnerBrothers = "Warner Brothers";
        private const int Offset = 0;
        public DcSeriesPageViewModel(INavigationService navigationService, IPageDialogService dialogService, ApiComicsVine apiComicsVine) : base(navigationService, dialogService, apiComicsVine, DcUniverse, WarnerBrothers, Offset)
        {
            LoadListCommand = new DelegateCommand(async () =>
            {
                await LoadSeries(Offset);
            });
            LoadListCommand.Execute();
           
        }
    }
}