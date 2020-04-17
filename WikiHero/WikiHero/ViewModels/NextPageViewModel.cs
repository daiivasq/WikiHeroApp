using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WikiHero.Helpers;
using WikiHero.Models;
using WikiHero.Services;

namespace WikiHero.ViewModels
{
   
        public class NextPageViewModel : BaseViewModel,INavigationAware
        {
        public string ImagePublisher { get; set; }
        public DelegateCommand GoToMarvelOrDc { get; set; }
        const string marvel = "ironman.gif";
        public NextPageViewModel(INavigationService navigationService, IPageDialogService dialogService, IApiComicsVine apiComicsVine) : base(navigationService, dialogService, apiComicsVine)
            {
            

                GoToMarvelOrDc = new DelegateCommand(async () =>
                {
                    ETypeApplication editor = ImagePublisher == marvel ? ETypeApplication.Marvel : ETypeApplication.DC;
                    var param = new NavigationParameters
                    {
                        { $"{ConfigPageUri.NextPage}", editor }
                    };
                    await Task.Delay(3000);
                    await navigationService.NavigateAsync(new Uri($"/MenuPage/{ConfigPageUri.SharedTransitionNavigationPage}/HomePage", UriKind.Absolute), param);
                });
          

            }

        public void OnNavigatedFrom(INavigationParameters parameters)
        {
        }

        public void OnNavigatedTo(INavigationParameters parameters)
        {
            ImagePublisher = parameters[$"{ConfigPageUri.NextPage}"] as string;
            GoToMarvelOrDc.Execute();
        }
    }
    
}
