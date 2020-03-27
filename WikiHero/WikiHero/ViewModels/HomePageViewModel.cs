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
        public ObservableCollection<Character> ListTeam { get; set; }
        public ObservableCollection<Serie> SeriesRecent { get; set; }
        public DelegateCommand  LoadListCommand { get; set; }
        public HomePageViewModel(INavigationService navigationService, IPageDialogService dialogService, ApiComicsVine apiComicsVine) : base(navigationService, dialogService, apiComicsVine)
        {
            LoadListCommand = new DelegateCommand(async () =>
            {
                await LoadCharacters(0);
                await LoadRecentSeries();
            });
            LoadListCommand.Execute();
            TabOptions = new List<TabOption>()
            {
                {new TabOption{  Name="All",
                ListCharacters = ListTeam} },
                {new TabOption{  Name="Favorites"} },

            };
        }
        protected async Task LoadCharacters(int offset)
        {
            if (Connectivity.NetworkAccess == NetworkAccess.Internet)
            {
                try
                {
                    var list = await apiComicsVine.GetAllCharacter(offset, "Marvel");
                    ListTeam = new ObservableCollection<Character>(list);
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
                    var list = await apiComicsVine.GetRecentSeries("Marvel", "Disney");
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
    }


}