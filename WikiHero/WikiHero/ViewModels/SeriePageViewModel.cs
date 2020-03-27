using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WikiHero.Helpers;
using WikiHero.Models;
using WikiHero.Services;
using Xamarin.Essentials;

namespace WikiHero.ViewModels
{
    public class SeriePageViewModel : BaseViewModel
    {
        public ObservableCollection<Serie> Series { get; set; } = new ObservableCollection<Serie>();
        public int ItemTreshold { get; set; }
        public DelegateCommand RefreshCommand { get; set; }
        public bool IsBusy { get; set; }
        protected string ExtraStudioName { get; set; }
        protected string StudioName { get; set; }
        public DelegateCommand ItemTresholdReachedCommand { get; set; }
        public string Text { get; set; }
        public DelegateCommand SearchCommand { get; set; }
        private Serie selectSerie;

        public Serie SelectSerie
        {
            get { return selectSerie; }
            set { 
                selectSerie = value;
                if (selectSerie!=null)
                {
                    SelectionSeries(SelectSerie);
                }
            }
        }



        public SeriePageViewModel(INavigationService navigationService, IPageDialogService dialogService, ApiComicsVine apiComicsVine, string studioName, string ExtrastudioName, int offeset) : base(navigationService, dialogService, apiComicsVine)
        {
            this.ExtraStudioName = ExtrastudioName;
            this.StudioName = studioName;
            RefreshCommand = new DelegateCommand(async()=> 
            {
                IsBusy = true;
                Text = null;
                await  LoadSeries(0);
                IsBusy = false;
                
            });

            ItemTresholdReachedCommand = new DelegateCommand(async () =>
            {
                offeset += 100;
                await ScrollLoadSeries(offeset);
            });

            SearchCommand = new DelegateCommand(async () =>
            {
                await FindSeries(Text, 0);
            });
        }

        protected async Task ScrollLoadSeries(int offset)
        {
            if (IsBusy)
                return;

            IsBusy = true;
                try
                {

                    var items = await apiComicsVine.GetMoreSeries(offset, StudioName, ExtraStudioName);

                    foreach (var item in items)
                    {
                        Series.Add(item);
                    }
                    if (offset == 1000)
                    {
                        ItemTreshold = -1;
                        return;
                    }
                }

            catch (Exception ex)
            {
                await dialogService.DisplayAlertAsync("Error", $"{ex.Message}", "Ok");
            }
            finally
            {
                IsBusy = false;
            }
        }
        protected async void SelectionSeries(Serie serie)
        {
            var navigateTo = StudioName == "Marvel" ? ConfigPageUri.MarvelSeriesPage : ConfigPageUri.DcSeriesPage;
            var param = new NavigationParameters
            {
                { nameof(Serie), serie }
            };
            await navigationService.NavigateAsync(new Uri($"{ConfigPageUri.DetailSeriesPage}",UriKind.Relative), param, false);
        }
        protected async Task LoadSeries(int offset)
        {
            if (Connectivity.NetworkAccess == NetworkAccess.Internet)
            {
                try
                {
                    var series = await apiComicsVine.GetAllSeries(offset,StudioName,ExtraStudioName);
                    Series = new ObservableCollection<Serie>(series);
                }
                catch (Exception ex)
                {

                    await dialogService.DisplayAlertAsync("Serie", $"{ex.Message}", "Ok");

                }
            }
            else
                await dialogService.DisplayAlertAsync("Connection error ", Connectivity.NetworkAccess.ToString(), "Ok");
            

        }

        protected async Task FindSeries(string name, int offset)
        {
            var list = await apiComicsVine.FindSeries(name, offset);
            if (string.IsNullOrEmpty(name))
            {
                await LoadSeries(offset);
            }
            else
            {
                Series = new ObservableCollection<Serie>(list);
            }
            
            
        }

    }
}
