using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Text;
using WikiHero.Services;

namespace WikiHero.ViewModels.DCViewModels
{
    public class DcVolumePageViewModel : VolumePageViewModel
    {
        private const string DcUniverse = "DC Comics";
        private const string WarnerBrothers = "Warner Brothers";
        private const string DynamiteEntertainment = "Dynamite Entertainment";
        private const int Offset = 0;
        public DcVolumePageViewModel(INavigationService navigationService, IPageDialogService dialogService, IApiComicsVine apiComicsVine) : base(navigationService, dialogService, apiComicsVine, DcUniverse, WarnerBrothers, DynamiteEntertainment, Offset)
        {
           
        }
    }
}
