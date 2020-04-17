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
using Xamarin.Forms.StateSquid;

namespace WikiHero.ViewModels
{
    public class SeriePageViewModel : BaseViewModel, INavigationAware
    {
        public ObservableCollection<Serie> Series { get; set; } = new ObservableCollection<Serie>();
        public int ItemTreshold { get; set; }
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

        public DelegateCommand NavigateDetailCommand { get; set; }


        public SeriePageViewModel(INavigationService navigationService, IPageDialogService dialogService, IApiComicsVine apiComicsVine) : base(navigationService, dialogService, apiComicsVine)
        {
            int offeset = 0;
            RefreshCommand = new DelegateCommand(async()=> 
            {
                IsBusy = true;
                Text  =string.Empty;
                await  LoadSeries();
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
            LoadListCommand = new DelegateCommand(async () =>
            {
                await LoadSeries();
            });
        }

        protected async Task ScrollLoadSeries(int offset)
        {
            if (IsBusy)
                return;

            IsBusy = true;
                try
                {

                 var series = await apiComicsVine.GetMoreSeries(Config.Apikey,offset, PublisherSecond);
                var notNull = from item in series.Series where item.Publisher != null select item;
                var marvelOrDc = notNull.Where(e => e.Publisher.Name.Contains(Publisher) || e.Publisher.Name.Contains(PublisherSecond));
                foreach (var item in marvelOrDc)
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
            var param = new NavigationParameters
            {
                { nameof(Serie), serie }
            };
            await navigationService.NavigateAsync(new Uri($"{ConfigPageUri.DetailSeriesPage}",UriKind.Relative), param, false);
        }
        protected async Task LoadSeries()
        {

                try 
                {
                    CurrentState = State.Loading;
                    var series = await apiComicsVine.GetSeries(Publisher, PublisherSecond);
                    var notNull = from item in series.Series where item.Publisher != null select item;
                    var marvelOrDc = notNull.Where(e => e.Publisher.Name.Contains(Publisher) || e.Publisher.Name.Contains(PublisherSecond));
                    Series = new ObservableCollection<Serie>(marvelOrDc);
                    CurrentState = State.None;
                }
                catch (Exception ex)
                {
                    CurrentState = State.Error;
                    await dialogService.DisplayAlertAsync("Serie", $"{ex.Message}", "Ok");

                }
            finally
            {
                CurrentState = State.None;
            }



        }

        protected async Task FindSeries(string name, int offset)
        {

            var series = await apiComicsVine.SearchSeries(name, Config.Apikey, offset, Publisher);
            var notNull = from item in series.Series where item.Publisher != null select item;
            var marvelOrDc = notNull.Where(e => e.Publisher.Name.Contains(Publisher) || e.Publisher.Name.Contains(PublisherSecond));
            if (string.IsNullOrEmpty(name))
            {
                await LoadSeries();
            }
            else
            {
                Series = new ObservableCollection<Serie>(marvelOrDc);
            }
            
            
        }

        public void OnNavigatedFrom(INavigationParameters parameters)
        {
          
        }

        public void OnNavigatedTo(INavigationParameters parameters)
        {
            var param = (ETypeApplication)parameters[$"{ConfigPageUri.NextPage}"];
            Publisher = param.ToString();
            switch (Publisher)
            {
                case "DC":
                    {
                        PublisherSecond = "Warner Brothers";
                        PublisherThird = "Dynamite Entertainment";
                        break;
                    }
                case "Marvel":
                    {
                        PublisherSecond = "Disney";
                        PublisherThird = "Atlas";
                        PublisherFourth = "Fawcett Publications";
                        break;
                    }
                default:
                    break;
            }
            LoadListCommand.Execute();
        }
    }
}
