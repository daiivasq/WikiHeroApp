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
using Xamarin.Forms.StateSquid;

namespace WikiHero.ViewModels
{
    public class HomePageViewModel : BaseViewModel
    {
        public List<TabOption> TabOptions { get; set; }
        public List<Task> ListTask { get; set; }
        public string PublisherPrincipal { get; set; }
        public string PublisherSecond { get; set; }
        public string PublisherThird { get; set; }
        public string PublisherFourth { get; set; }
        public HomePageViewModel(INavigationService navigationService, IPageDialogService dialogService, IApiComicsVine apiComicsVine,string publisherPrincipal,string publisherSecond,string publisherThird,string publisherFourth) : base(navigationService, dialogService, apiComicsVine)
        {
            TabOptions = new List<TabOption>()
                        {
                {new TabOption(){  Name="All", TitleCharacter="Recent Characters",TitleSeries = "Recent Series", TitleVolume = "Recent Volumes"} },
                {new TabOption{  Name="Favorites"}},

                    };
            this.PublisherPrincipal = publisherPrincipal;
            this.PublisherSecond = publisherSecond;
            this.PublisherThird = publisherThird;
            this.PublisherFourth = publisherFourth;

            LoadListCommand = new DelegateCommand(async () =>
            {
             ListTask = new List<Task>() { LoadTeams(), LoadCharacters(), LoadRecentSeries(), LoadRecentVolumes()};
                CurrentState = State.Loading;
               await Task.WhenAll(ListTask);
                CurrentState = State.None;
            });
            LoadListCommand.Execute();


        }
        protected async Task LoadCharacters()
        {
            if (Connectivity.NetworkAccess == NetworkAccess.Internet)
            {
                try
                {
                    var characters = await apiComicsVine.GetRecentCharacters(Config.Apikey,PublisherPrincipal);
                    var notNull = from item in characters.Characters where item.Publisher != null select item;
                    var marvelOrDc = notNull.Where(e => e.Publisher.Name.Contains(PublisherPrincipal));
                    TabOptions[0].ListCharacters = new ObservableCollection<Character>(marvelOrDc);
                }
                catch (Exception ex)
                {

                    await dialogService.DisplayAlertAsync("Error", $"{ex.Message}", "Ok");

                }
            }
            else
                await dialogService.DisplayAlertAsync("Connection error ", Connectivity.NetworkAccess.ToString(), "Ok");

        }
        protected async Task LoadRecentSeries()
        {
            if (Connectivity.NetworkAccess == NetworkAccess.Internet)
            {
                try
                {
                    var recentSeries = await apiComicsVine.GetRecentSeries(Config.Apikey,0, PublisherPrincipal);
                    var notNull = from item in recentSeries.Series where item.Publisher != null select item;
                    var marvelOrDc = notNull.Where(e => e.Publisher.Name == PublisherPrincipal || e.Publisher.Name == PublisherSecond);
                    TabOptions[0].ListSeries = new ObservableCollection<Serie>(marvelOrDc);
                }
                catch (Exception ex)
                {

                    await dialogService.DisplayAlertAsync("Error", $"{ex.Message}", "Ok");

                }
            }
            else
                await dialogService.DisplayAlertAsync("Connection error ", Connectivity.NetworkAccess.ToString(), "Ok");
        }
        protected async Task LoadRecentVolumes()
        {
            if (Connectivity.NetworkAccess == NetworkAccess.Internet)
            {
                try
                {
                    var recentVolumes = await apiComicsVine.GetRecentVolumes(1, Config.Apikey, PublisherPrincipal);
                    var notNull = from item in recentVolumes.Volumes where item.Publisher != null select item;
                    var marvelOrDc = notNull.Where(e => e.Publisher.Name == PublisherPrincipal || e.Publisher.Name == PublisherSecond || e.Publisher.Name == PublisherThird);
                    TabOptions[0].ListVolumes = new ObservableCollection<Volume>(marvelOrDc);
                }
                catch (Exception ex)
                {

                    await dialogService.DisplayAlertAsync("Error", $"{ex.Message}", "Ok");

                }
            }
            else
                await dialogService.DisplayAlertAsync("Connection error ", Connectivity.NetworkAccess.ToString(), "Ok");
        }
        protected async Task LoadTeams()
        {
            if (Connectivity.NetworkAccess == NetworkAccess.Internet)
            {
                try
                {
                    var team = await apiComicsVine.GetTeams(Config.Apikey, PublisherPrincipal);
                    var notNull = from item in team.Results where item.Publisher != null select item;
                    var marvelOrDc = notNull.Where(e => e.Publisher.Name.Contains(PublisherPrincipal));
                    TabOptions[0].Teams = new ObservableCollection<Team>(marvelOrDc);
                }
                catch (Exception ex)
                {

                    await dialogService.DisplayAlertAsync("Error", $"{ex.Message}", "Ok");

                }
            }
            else
                await dialogService.DisplayAlertAsync("Connection error ", Connectivity.NetworkAccess.ToString(), "Ok");
        }
    }


}