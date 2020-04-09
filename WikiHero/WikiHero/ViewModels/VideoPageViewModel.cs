using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Text;
using WikiHero.Models;
using WikiHero.Services;

namespace WikiHero.ViewModels
{
    public class VideoPageViewModel:BaseViewModel,INavigatedAware
    {
        public Video Video { get; set; }
        public VideoPageViewModel(INavigationService navigationService, IPageDialogService dialogService, IApiComicsVine apiComicsVine) : base(navigationService, dialogService, apiComicsVine)
        {

        }

        public void OnNavigatedFrom(INavigationParameters parameters)
        {
            throw new NotImplementedException();
        }

        public void OnNavigatedTo(INavigationParameters parameters)
        {
            var param = parameters[$"{nameof(Video)}"] as Video;
            if (param !=null)
            {
                Video = param;
            }
        }
    }
}
