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

namespace WikiHero.ViewModels.DCViewModels
{
    public class DCCharactersPageViewModel : CharacterPageViewModel
    {
        private const string DC_Comics = "DC Comics";
        const int offeset = 0;
        public DCCharactersPageViewModel(INavigationService navigationService, IPageDialogService dialogService, IApiComicsVine apiComicsVine) : base(navigationService, dialogService, apiComicsVine, DC_Comics, offeset)
        {

        }
    }
}

