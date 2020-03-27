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
using WikiHero.Models.CharacterStatModel;
using WikiHero.Services;

namespace WikiHero.ViewModels
{
    public class CompareCharactersPageViewModel:BaseViewModel
    {
        protected ApiStatsCharacters apiStatsCharacters;
        public ObservableCollection<CharacterStats> HeroesCharacters { get; set; }
        public ObservableCollection<CharacterStats> VillainCharacters { get; set; }
        private CharacterStats selectHeroes;

        public bool IsBusy { get; set; }
        public bool IsHeroesEnabled { get; set; } = false;
        public bool IsVillainEnabled { get; set; } = false;
        public CharacterStats SelectHeroes
        {
            get { return selectHeroes; }
            set 
            {
                selectHeroes = value;
                if (selectHeroes!=null)
                {
                    IsHeroesEnabled = true;
                }
            }
        }
        private CharacterStats selectVillain;

        public CharacterStats SelectVillain
        {
            get { return selectVillain; }
            set { 
                selectVillain = value;
                if (selectVillain != null)
                {
                    IsVillainEnabled = true;
                }
            }
        }

        public DelegateCommand CompareCharacter { get; set; }
        public CompareCharactersPageViewModel(INavigationService navigationService, IPageDialogService dialogService, ApiComicsVine apiComicsVine, ApiStatsCharacters apiStatsCharacters,string publisher) : base(navigationService, dialogService, apiComicsVine)
        {
            this.apiStatsCharacters = apiStatsCharacters;
            LoadListCommand = new DelegateCommand(async () =>
            {
                await LoadCharacters(publisher);
            });
            LoadListCommand.Execute();
        }
        async Task LoadCharacters(string publisher)
        {
            IsBusy = true;
            const string bad = "bad";
            const string good = "good";
            var stats = await apiStatsCharacters.GetCharacterStats(publisher);
            var publishers = stats.Where(e=> e.Biography.Publisher.Contains(publisher));
            HeroesCharacters = new ObservableCollection<CharacterStats>(publishers.Where(e=>e.Biography.Alignment!= bad));
            VillainCharacters = new ObservableCollection<CharacterStats>(publishers.Where(e => e.Biography.Alignment != good));
            IsBusy = false;
        }
    }
}
