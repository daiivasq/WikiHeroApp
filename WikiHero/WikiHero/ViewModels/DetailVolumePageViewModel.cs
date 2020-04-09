using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using WikiHero.Helpers;
using WikiHero.Models;
using WikiHero.Services;
using Xamarin.Essentials;

namespace WikiHero.ViewModels
{
    public class DetailVolumePageViewModel : BaseViewModel,INavigatedAware
    {
        public ObservableCollection<Comic> Comics { get; set; }
        private Comic selectComic;
        public DelegateCommand GoToNavigation { get; set; }
        public DelegateCommand ShareCommand { get; set; }
        public Comic SelectComic
        {
            get { return selectComic; }
            set { 
                selectComic = value;
                if (selectComic!=null)
                {
                    GoToNavigation = new DelegateCommand(async()=> {
                        await NavigationGoDetail(SelectComic); ;
                    });
                    GoToNavigation.Execute();
                   
                }
            }
        }

        public Volume Volume { get; set; }

     

        public DetailVolumePageViewModel(INavigationService navigationService, IPageDialogService dialogService, IApiComicsVine apiComicsVine,IDBFavorites dBFavorites) : base(navigationService, dialogService, apiComicsVine)
        {
            ShareCommand = new DelegateCommand(async () =>
            {
                await SharedOpcion();
            });
            FavoriteCommand = new DelegateCommand(async () =>
            {
                const string Marvel = "Marvel";
                const string Dc = "DC";
                dBFavorites.AddVolume(Marvel, Volume);
            });
        }
        async Task SharedOpcion()
        {
            await Share.RequestAsync(new ShareTextRequest
            {

                Text = $"{Volume.Name}\nCantidad de volumes:{Volume.CountOfIssues}",
                Title = $"{Volume.Publisher.Name}",
                Uri = $"{Volume.SiteDetailUrl}"
            });
        }
        async Task GetComics()
        {
             var comics = await apiComicsVine.VolumeComics(Config.Apikey, Volume.Id, null);
            Comics = new ObservableCollection<Comic>(comics.Results);
        }
        async Task NavigationGoDetail(Comic comic)
        {
            var param = new NavigationParameters();
            param.Add($"{nameof(Comic)}", comic);
            await navigationService.NavigateAsync(new Uri(ConfigPageUri.DetailComicPage, UriKind.Relative), param);
        }

        public void OnNavigatedFrom(INavigationParameters parameters)
        {
            
        }

        public async void OnNavigatedTo(INavigationParameters parameters)
        {
            var param = parameters[$"{nameof(Volume)}"] as Volume;
           
            if (param!=null)
            {
                Volume = param;
               await GetComics();
            }
        }
    }
}
