using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Text;
using WikiHero.Helpers;
using WikiHero.Services;

namespace WikiHero.ViewModels
{
   
        public class NextPageViewModel : BaseViewModel,INavigationAware
        {
        public string ImagePublisher { get; set; }
        public DelegateCommand GoToMarvelOrDc { get; set; }

            public NextPageViewModel(INavigationService navigationService, IPageDialogService dialogService, IApiComicsVine apiComicsVine) : base(navigationService, dialogService, apiComicsVine)
            {
            

                GoToMarvelOrDc = new DelegateCommand(async () =>
                {
                    var param = new NavigationParameters
                    {
                        { $"{ConfigPageUri.MenuMasterDetailPage}", ImagePublisher }
                    };
                    await navigationService.NavigateAsync(new Uri($"{ConfigPageUri.MenuMasterDetailPage}{ConfigPageUri.SharedTransitionNavigationPage}{ConfigPageUri.MarvelHomePage}", UriKind.Absolute),param);
                });

            }

        public void OnNavigatedFrom(INavigationParameters parameters)
        {
        }

        public void OnNavigatedTo(INavigationParameters parameters)
        {
            ImagePublisher = (string)parameters[$"{nameof(ConfigPageUri.MenuMasterDetailPage)}"];
        }
    }
    
}
