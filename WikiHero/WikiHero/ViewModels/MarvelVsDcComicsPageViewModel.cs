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
        public DelegateCommand<string> GoToNextPage { get; set; }
        public string SelectId { get; set; }
        public MarvelVsDcComicsPageViewModel(INavigationService navigationService, IPageDialogService dialogService, IApiComicsVine apiComicsVine) :base(navigationService, dialogService, apiComicsVine)
        {
                GoToNextPage = new DelegateCommand<string>(async (url) =>
                {
                    SelectId = url;
                    var param = new NavigationParameters();
                    param.Add($"{nameof(ConfigPageUri)}", url);
                    await navigationService.NavigateAsync(new Uri($"{ConfigPageUri.NextPage}", UriKind.Relative),param);
                });
       
          
        }
    }
}
