using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Text;
using WikiHero.Helpers;
using WikiHero.Models;
using WikiHero.Services;

namespace WikiHero.ViewModels.DCViewModels
{
    public class DcMasterDetailPageViewModel:MenuMasterDetailPageViewModel
    {
        public DcMasterDetailPageViewModel(INavigationService navigationService, IPageDialogService dialogService, IApiComicsVine apiComicsVine) : base(navigationService, dialogService, apiComicsVine, Dc)
        {
            ItemPages = new List<ItemPage>() {
                 new ItemPage("dchome","Home",ConfigPageUri.DcHomePage),
                 new ItemPage("monitor","Series",ConfigPageUri.DcSeriesPage),
                 new ItemPage("comic","Volumes",ConfigPageUri.DcVolumePage),
                 new ItemPage("DcCharacter","Characters",ConfigPageUri.DcComicsCharactersPage),
                 new ItemPage("sword","Vs",ConfigPageUri.MarvelCompareCharacterPage),
                 new ItemPage("star","favorites",ConfigPageUri.DcFavoritesPage),
            };
            ChangePageCommand = new DelegateCommand(async () =>
            {
                await navigationService.NavigateAsync(new Uri($"{ConfigPageUri.MarvelMasterDetailPage}{ConfigPageUri.SharedTransitionNavigationPage}{ConfigPageUri.MarvelHomePage}"));
            });
        }

    }
}
