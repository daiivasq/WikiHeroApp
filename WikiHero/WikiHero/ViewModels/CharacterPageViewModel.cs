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
using Xamarin.Forms.StateSquid;

namespace WikiHero.ViewModels
{
    public class CharacterPageViewModel:BaseViewModel, INavigationAware
    {
        public ObservableCollection<Character> Characters { get; set; }
        private Character selectCharacter;

        public Character SelectCharacter
        {
            get { return selectCharacter; }
            set
            {
                selectCharacter = value;
                if (selectCharacter != null)
                {
                    NavigationToDetail(SelectCharacter);
                }
            }
        }

        public CharacterPageViewModel(INavigationService navigationService, IPageDialogService dialogService, IApiComicsVine apiComicsVine) : base(navigationService, dialogService, apiComicsVine)
        {
        }
        async Task LoadCharacter()
        {
            CurrentState = State.Loading;
            var characters = await apiComicsVine.GetCharacter(Config.Apikey, Publisher);
            var notNull = from item in characters.Characters where item.Publisher != null select item;
            var marvelOrDc = notNull.Where(e => e.Publisher.Name.Contains(Publisher));
            Characters = new ObservableCollection<Character>(marvelOrDc);
            CurrentState = State.None;
        }
        async Task NavigationToDetail(Character character)
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
            }

        }
        public void OnNavigatedFrom(INavigationParameters parameters)
        { 
        }

        public  void OnNavigatedTo(INavigationParameters parameters)
        {
            var param =(ETypeApplication)parameters[$"{ConfigPageUri.NextPage}"];
            Publisher = param.ToString();
            LoadListCommand = new DelegateCommand(async () =>
            {
                await LoadCharacter();
            });
            LoadListCommand.Execute();
        }
    }
}
