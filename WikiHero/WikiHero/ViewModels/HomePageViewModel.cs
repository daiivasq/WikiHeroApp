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
    public class HomePageViewModel : BaseViewModel
    {
        public List<TabOption> TabOptions { get; set; }
        public ObservableCollection<Team> Teams { get; set; }
        public ObservableCollection<Character> RecentCharacters { get; set; }
        public ObservableCollection<Serie> SeriesRecent { get; set; }
        public ObservableCollection<Volume> VolumesRecent { get; set; }
        public DelegateCommand  LoadListCommand { get; set; }
        public string PublisherPrincipal { get; set; }
        public string PublisherSecond { get; set; }
        public string PublisherThird { get; set; }
        public string PublisherFourth { get; set; }
        public HomePageViewModel(INavigationService navigationService, IPageDialogService dialogService, ApiComicsVine apiComicsVine,string publisherPrincipal,string publisherSecond,string publisherThird,string publisherFourth) : base(navigationService, dialogService, apiComicsVine)
        {
            this.PublisherPrincipal = publisherPrincipal;
            this.PublisherSecond = publisherSecond;
            this.PublisherThird = publisherThird;
            this.PublisherFourth = publisherFourth;
            LoadListCommand = new DelegateCommand(async () =>
            {
                await LoadTeams();
                await LoadCharacters();
                await LoadRecentSeries();
                await LoadRecentVolumes();
               
            });
            LoadListCommand.Execute();
            TabOptions = new List<TabOption>()
            {
                {new TabOption{  Name="All",
                ListCharacters = RecentCharacters} },
                {new TabOption{  Name="Favorites"} },

            };
        }
        protected async Task LoadCharacters()
        {
            if (Connectivity.NetworkAccess == NetworkAccess.Internet)
            {
                try
                {
                    var list = await apiComicsVine.GetRecentCharacters(PublisherPrincipal);
                    RecentCharacters = new ObservableCollection<Character>(list);
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
                    SeriesRecent = new ObservableCollection<Serie>(list);
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
                    VolumesRecent = new ObservableCollection<Volume>(list);
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
                    Teams = new ObservableCollection<Team>(list);
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