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

        public HomePageViewModel(INavigationService navigationService, IPageDialogService dialogService, ApiComicsVine apiComicsVine,string publisherPrincipal,string publisherSecond,string publisherThird,string publisherFourth) : base(navigationService, dialogService, apiComicsVine)
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
            ListTask = new List<Task>() { LoadTeams(), LoadCharacters(), LoadRecentSeries(), LoadRecentVolumes()
            };
            LoadListCommand = new DelegateCommand(async () =>
            {
                CurrentState = State.Loading;
                await Task.Delay(100000);
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
                    var list = await apiComicsVine.GetRecentCharacters(PublisherPrincipal);
                    TabOptions[0].ListCharacters = new ObservableCollection<Character>(list);
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
                    var list = await apiComicsVine.GetRecentSeries(PublisherPrincipal, PublisherSecond);
                    TabOptions[0].ListSeries = new ObservableCollection<Serie>(list);
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
                    var list = await apiComicsVine.GetRecentVolumes(PublisherPrincipal, PublisherSecond, PublisherThird);
                    TabOptions[0].ListVolumes = new ObservableCollection<Volume>(list);
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
                    var list = await apiComicsVine.GetTeams(PublisherPrincipal);
                    TabOptions[0].Teams = new ObservableCollection<Team>(list);
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