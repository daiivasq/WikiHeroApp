using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
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
    public class HomePageViewModel : BaseViewModel
    {
        public List<TabOption> TabOptions { get; set; }
        public List<Task> ListTask { get; set; }
        public string PublisherPrincipal { get; set; }
        public string PublisherSecond { get; set; }
        public string PublisherThird { get; set; }
        public string PublisherFourth { get; set; }
        public DelegateCommand NavigateDetailCommand { get; set; }
        private Character selectCharacter;

        public Character SelectCharacter
        {
            get { return selectCharacter; }
            set
            {
                selectCharacter = value;
                if (selectCharacter != null)
                {
                    NavigateDetailCommand = new DelegateCommand(async () =>
                    {
                       await NavigationToDetailCharacter(SelectCharacter);
                    });
                    NavigateDetailCommand.Execute();

                }
            }
        }
        private Serie selectSerie;

        public Serie SelectSerie
        {
            get { return selectSerie; }
            set
            {
                selectSerie = value;
                if (SelectSerie != null)
                {
                    NavigateDetailCommand = new DelegateCommand(async () =>
                    {
                       await NavigationToDetailSerie(SelectSerie);
                    });
                    NavigateDetailCommand.Execute();


                }
            }
        }
        public ObservableCollection<Team> Teams { get; set; }
        public ObservableCollection<Character> ListCharacters { get; set; }
        public ObservableCollection<Serie> ListSeries { get; set; }
        public ObservableCollection<Volume> ListVolumes { get; set; }
        private Serie selectComics;
        public Serie SelectComics
        {
            get { return selectComics; }
            set
            {
                selectComics = value;
                if (selectComics != null)
                {
                    NavigateDetailCommand = new DelegateCommand(async () =>
                    {
                        await NavigationToDetailSerie(SelectComics);
                    });
                    NavigateDetailCommand.Execute();

                }
            }
        }
        public HomePageViewModel(INavigationService navigationService, IPageDialogService dialogService, IApiComicsVine apiComicsVine,string publisherPrincipal,string publisherSecond,string publisherThird,string publisherFourth) : base(navigationService, dialogService, apiComicsVine)
        {
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
        async Task NavigationToDetailCharacter(Character character)
        {
            try
            {
                var param = new NavigationParameters
            {
                { nameof(Character), character.Id }
            };
                await navigationService.NavigateAsync(new Uri($"{ConfigPageUri.DetailCharactersPage}", UriKind.Relative), param, true);
            }
            catch (Exception err)
            {

                await dialogService.DisplayAlertAsync("", $"{err}", "ok");
            }
        }
        async Task NavigationToDetailSerie(Serie serie)
        {
            try
            {
                var param = new NavigationParameters
            {
                { nameof(Serie), serie }
            };
                await navigationService.NavigateAsync(new Uri($"{ConfigPageUri.DetailSeriesPage}", UriKind.Relative), param, true);
            }
            catch (Exception err)
            {

                await dialogService.DisplayAlertAsync("", $"{err}", "ok");
            }
        }

        async Task NavigationToDetailComics(Volume volume)
        {
            try
            {
                var param = new NavigationParameters
            {
                { nameof(Volume), volume }
            };
                await navigationService.NavigateAsync(new Uri($"{ConfigPageUri.DetailSeriesPage}", UriKind.Relative), param, true);
            }
            catch (Exception err)
            {

                await dialogService.DisplayAlertAsync("", $"{err}", "ok");
            }
        }
        protected async Task LoadCharacters()
            {
                try
                {
                    var characters = await apiComicsVine.GetRecentCharacters(Config.Apikey,PublisherPrincipal);
                    var notNull = from item in characters.Characters where item.Publisher != null select item;
                    var marvelOrDc = notNull.Where(e => e.Publisher.Name.Contains(PublisherPrincipal));
                     ListCharacters = new ObservableCollection<Character>(marvelOrDc);
                }
                catch (Exception ex)
                {

                CurrentState = State.None;

                 }
                finally
                {
                CurrentState = State.None;
                 }

            }
        protected async Task LoadRecentSeries()
        {
                try
                {
                    var recentSeries = await apiComicsVine.GetRecentSeries(Config.Apikey,0, PublisherPrincipal);
                    var notNull = from item in recentSeries.Series where item.Publisher != null select item;
                    var marvelOrDc = notNull.Where(e => e.Publisher.Name == PublisherPrincipal || e.Publisher.Name == PublisherSecond);
                    ListSeries = new ObservableCollection<Serie>(marvelOrDc);
            }
                catch (Exception ex)
                {

                    await dialogService.DisplayAlertAsync("Error", $"{ex.Message}", "Ok");

                }
                finally
                {
                    CurrentState = State.None;
                }
            }
        protected async Task LoadRecentVolumes()
        {
                try
                {
                    var recentVolumes = await apiComicsVine.GetRecentVolumes(1, Config.Apikey, PublisherPrincipal);
                    var notNull = from item in recentVolumes.Volumes where item.Publisher != null select item;
                    var marvelOrDc = notNull.Where(e => e.Publisher.Name == PublisherPrincipal || e.Publisher.Name == PublisherSecond || e.Publisher.Name == PublisherThird);
                ListVolumes = new ObservableCollection<Volume>(marvelOrDc);
            }
                catch (Exception ex)
                {

                    await dialogService.DisplayAlertAsync("Error", $"{ex.Message}", "Ok");

                }
                finally
                {
                    CurrentState = State.None;
                }
            }
        protected async Task LoadTeams()
        {
                try
                {
                    var team = await apiComicsVine.GetTeams(Config.Apikey, PublisherPrincipal);
                    var notNull = from item in team.Results where item.Publisher != null select item;
                    var marvelOrDc = notNull.Where(e => e.Publisher.Name.Contains(PublisherPrincipal));
                    Teams = new ObservableCollection<Team>(marvelOrDc);
                }
                catch (Exception ex)
                {
                CurrentState = State.None;

                }
                finally
                {
                    CurrentState = State.None;
                }
            }
    }


}