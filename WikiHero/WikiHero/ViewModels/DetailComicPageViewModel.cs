using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using WikiHero.Models;
using WikiHero.Services;
using Xamarin.Essentials;

namespace WikiHero.ViewModels
{
    public class DetailComicPageViewModelS : BaseViewModel, INavigationAware
    {
        public ObservableCollection<Comic> Comics { get; set; }
        public Comic Comic { get; set; }
        public DelegateCommand LoadCommand { get; set; }
        public DelegateCommand ShareCommand { get; set; }
        public DelegateCommand FavoriteCommand { get; set; }
        public DetailComicPageViewModelS(INavigationService navigationService, IPageDialogService dialogService, IApiComicsVine apiComicsVine) : base(navigationService, dialogService, apiComicsVine)
        {

            ShareCommand = new DelegateCommand(async () =>
            {
                await SharedOpcion();
            });

        }

        async Task LoadComics(int idcomics)
        {
            try
            {
                var comics = await apiComicsVine.VolumeComics(Config.Apikey,idcomics,null);
                Comics = new ObservableCollection<Comic>(comics.Results);
            }
            catch (Exception err)
            {

                await dialogService.DisplayAlertAsync("Error", $"{err}", "ok");
            }

        }
        async Task SharedOpcion()
        {
            await Share.RequestAsync(new ShareTextRequest
            {

                Text = $"{Comic.Name}\nRating: {Comic.Rating}",
                Title = $"{Comic.Name}",
                Uri = $"{Comic.SiteDetailUrl}"
            });
        }


        public void OnNavigatedFrom(INavigationParameters parameters)
        {
            
        }

        public void OnNavigatedTo(INavigationParameters parameters)
        {
            var param = (Comic)parameters[nameof(Comic)];
            Comic = param;
            LoadCommand = new DelegateCommand(async () => await LoadComics(Comic.Id));
            LoadCommand.Execute();
        }
    }
}
