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
        public string UrlNavigate { get; set; }
        public DelegateCommand GoToMarvelOrDc { get; set; }

            public NextPageViewModel(INavigationService navigationService, IPageDialogService dialogService, ApiComicsVine apiComicsVine) : base(navigationService, dialogService, apiComicsVine)
            {
            

                GoToMarvelOrDc = new DelegateCommand(async () =>
                {
                    await navigationService.NavigateAsync(new Uri($"{UrlNavigate}", UriKind.Relative));
                });

            }

        public void OnNavigatedFrom(INavigationParameters parameters)
        {
        }

        public void OnNavigatedTo(INavigationParameters parameters)
        {
            ImagePublisher = (string)parameters[$"{nameof(ConfigPageUri)}"];
            UrlNavigate= ImagePublisher == "Marvel.jpg" ? ConfigPageUri.TappedMarvelPage : ConfigPageUri.TappedDcComicsPage ;
        }
    }
    
}
