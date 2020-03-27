using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Text;
using WikiHero.Helpers;
using WikiHero.Services;
using WikiHero.Views.DcComicsViews;

namespace WikiHero.ViewModels
{
   public class MarvelVsDcComicsPageViewModel:BaseViewModel
    {
        public DelegateCommand DcUniverseCommand { get; set; }
        public DelegateCommand MarvelCommand { get; set; }
        public MarvelVsDcComicsPageViewModel(INavigationService navigationService, IPageDialogService dialogService, ApiComicsVine apiComicsVine) :base(navigationService, dialogService, apiComicsVine)
        {

                DcUniverseCommand = new DelegateCommand(async () =>
                {
                    await navigationService.NavigateAsync(new Uri($"{ConfigPageUri.SharedTransitionNavigationPage}{ConfigPageUri.TappedDcComicsPage}", UriKind.Absolute));
                });
                MarvelCommand = new DelegateCommand(async () =>
                {
                    await navigationService.NavigateAsync(new Uri($"{ConfigPageUri.SharedTransitionNavigationPage}{ConfigPageUri.TappedMarvelPage}", UriKind.Relative));
                });
       
          
        }
    }
}
