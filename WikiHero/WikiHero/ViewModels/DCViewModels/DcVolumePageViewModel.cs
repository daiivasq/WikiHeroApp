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
        private const string DcUniverse = "DC";
        private const string WarnerBrothers = "Warner";
        private const string DynamiteEntertainment = "Dynamite";
        private const int Offset = 0;
        public DcVolumePageViewModel(INavigationService navigationService, IPageDialogService dialogService, ApiComicsVine apiComicsVine) : base(navigationService, dialogService, apiComicsVine, DcUniverse, WarnerBrothers, DynamiteEntertainment, Offset)
        {
            LoadListCommand = new DelegateCommand(async () =>
            {
                await LoadComics(Offset);
            });
            LoadListCommand.Execute();
           
        }
    }
}
