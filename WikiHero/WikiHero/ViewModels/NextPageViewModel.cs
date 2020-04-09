using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WikiHero.Helpers;
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
                    await Task.Delay(3000);
                    var page = ImagePublisher == marvel ? $"{ConfigPageUri.MarvelMasterDetailPage}{ConfigPageUri.SharedTransitionNavigationPage}{ConfigPageUri.MarvelHomePage}": $"{ConfigPageUri.DcMasterDetailPage}{ConfigPageUri.SharedTransitionNavigationPage}{ConfigPageUri.DcHomePage}";
                    await navigationService.NavigateAsync(new Uri($"{page}", UriKind.Absolute));
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
