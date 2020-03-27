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

namespace WikiHero.ViewModels
{
    public class DetailSeriesPageViewModel:BaseViewModel,INavigationAware
    {
        public ObservableCollection<Episode> Episodes { get; set; } 
        public DelegateCommand LoadCommand { get; set; }
        public Serie Serie { get; set; } = new Serie();

        public DetailSeriesPageViewModel(INavigationService navigationService, IPageDialogService dialogService, ApiComicsVine apiComicsVine) : base(navigationService, dialogService, apiComicsVine)
        {

           

        }
        async Task LoadEpisode(int idSeries)
        {
            try
            {
                var episodes = await apiComicsVine.GetEpisode(idSeries);
                Episodes = new ObservableCollection<Episode>(episodes);
            }
            catch (Exception err)
            {

               await dialogService.DisplayAlertAsync("Error", $"{err}", "ok");
            }

        }
        public void OnNavigatedFrom(INavigationParameters parameters)
        {

        }

        public void OnNavigatedTo(INavigationParameters parameters)
        {
            var param = (Serie)parameters[nameof(Serie)];
            Serie = param;
            LoadCommand = new DelegateCommand(async () => await LoadEpisode(Serie.Id));
            LoadCommand.Execute();
        }
    }
}
