using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WikiHero.Models;
using WikiHero.Services;

namespace WikiHero.ViewModels.MarvelViewModels
{
    public class MarvelCharacterPageViewModel : CharacterPageViewModel
    {
        private const string Marvel = "Marvel";
        public MarvelCharacterPageViewModel(INavigationService navigationService, IPageDialogService dialogService, ApiComicsVine apiComicsVine, int offeset=100) :base(navigationService, dialogService, apiComicsVine,Marvel, offeset)
        {
            LoadListCommand = new DelegateCommand(async () =>
            {
                await LoadCharacters(offeset);
            });
            LoadListCommand.Execute();
           
        }
    }
}
