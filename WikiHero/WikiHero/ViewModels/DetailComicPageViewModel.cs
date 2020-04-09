using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WikiHero.Models;
using WikiHero.Services;
using Xamarin.Essentials;

namespace WikiHero.ViewModels
{
    public class DetailComicPageViewModel : BaseViewModel, INavigationAware
    {
        public ObservableCollection<Comic> Comics { get; set; }
        public Comic Comic { get; set; }
        public DelegateCommand LoadCommand { get; set; }
        public DelegateCommand ShareCommand { get; set; }
        public ObservableCollection<Character> Characters { get; set; }
        public ObservableCollection<LocationC> LocationCs { get; set; }
       private List<Task> loadTask;

        public DetailComicPageViewModel(INavigationService navigationService, IPageDialogService dialogService, IApiComicsVine apiComicsVine) : base(navigationService, dialogService, apiComicsVine)
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
                var comics = await apiComicsVine.FindComic(idcomics, Config.Apikey);
                Comic = comics.Comic;
            }
            catch (Exception err)
            {

                await dialogService.DisplayAlertAsync("Error", $"{err}", "ok");
            }

        }
        async Task LoadCharacterComics()
        {
            try
            {
                string comic=null;
                foreach (var item in Comic.CharacterCredits.Take(20))
                {
                    comic += $"{item.Id}|";
                }
                var characters = await apiComicsVine.FindEnenmyCharacter(Config.Apikey,comic);
                Characters = new ObservableCollection<Character>(characters.Characters);
            }
            catch (Exception err)
            {

                await dialogService.DisplayAlertAsync("Error", $"{err}", "ok");
            }

        }
        async Task LoadLocationComic()
        {
            try
            {
                string locations = null;
                if (Comic.LocationCredits.Count>0) {
                    foreach (var item in Comic.LocationCredits.Take(20))
                    {
                        locations += $"{item.Id}|";
                    }
                    var location = await apiComicsVine.FindLocation(Config.Apikey, locations);
                    LocationCs = new ObservableCollection<LocationC>(location.Locations);
                }

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

        public async void OnNavigatedTo(INavigationParameters parameters)
        {
            var param = parameters[$"{nameof(Comic)}"] as Comic;
            if (param != null)
            {
                await LoadComics(param.Id);
                LoadCommand = new DelegateCommand(async () => {
                    loadTask = new List<Task> {
                    LoadCharacterComics(), LoadLocationComic()
                };
                    Task.WhenAll(loadTask);
                });
                LoadCommand.Execute();

            }
            
          
        }
    }
}
