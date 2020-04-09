using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Text;
using WikiHero.Helpers;
using WikiHero.Models;
using WikiHero.Services;

namespace WikiHero.ViewModels.MarvelViewModels
{
    public class MarvelMasterDetailPageViewModel : MenuMasterDetailPageViewModel
    {
        public MarvelMasterDetailPageViewModel(INavigationService navigationService, IPageDialogService dialogService, IApiComicsVine apiComicsVine) : base(navigationService, dialogService, apiComicsVine, Marvel)
        {
            ChangePageCommand = new DelegateCommand(async () =>
            {
                await navigationService.NavigateAsync(new Uri($"{ConfigPageUri.DcMasterDetailPage}{ConfigPageUri.SharedTransitionNavigationPage}{ConfigPageUri.DcHomePage}"));
            });
        }
    }
}
