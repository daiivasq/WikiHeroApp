using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Text;
using WikiHero.Services;

namespace WikiHero.ViewModels.MarvelViewModels
{
    public class MarvelVolumePageViewModel : VolumePageViewModel
    {
    
        private const string MarvelUniverse = "Marvel";
        private const string FawcettPublications = "Fawcett Publications";
        private const string Atlas = "Atlas";
        private const int Offset = 0;
        public MarvelVolumePageViewModel(INavigationService navigationService, IPageDialogService dialogService, ApiComicsVine apiComicsVine) : base(navigationService, dialogService, apiComicsVine, MarvelUniverse, FawcettPublications, Atlas, Offset)
        {
            LoadListCommand = new DelegateCommand(async () =>
            {
                await LoadComics(Offset);
            });
            LoadListCommand.Execute();
           
        }
    }
}
