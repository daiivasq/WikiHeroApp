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
    public class DetailComicPageViewModel : BaseViewModel, INavigationAware
    {
        public ObservableCollection<Comic> Comics { get; set; }
        public Comic Comic { get; set; }
        public DelegateCommand LoadCommand { get; set; }
        public DetailComicPageViewModel(INavigationService navigationService, IPageDialogService dialogService, ApiComicsVine apiComicsVine) : base(navigationService, dialogService, apiComicsVine)
        {



        }

        async Task LoadComics(int idcomics)
        {
            try
            {
                var comics = await apiComicsVine.GetComics(idcomics);
                Comics = new ObservableCollection<Comic>(comics);
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
            var param = (Comic)parameters[nameof(Comic)];
            Comic = param;
            LoadCommand = new DelegateCommand(async () => await LoadComics(Comic.Id));
            LoadCommand.Execute();
        }
    }
}
