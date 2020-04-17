using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WikiHero.Helpers;
using WikiHero.Models;
using WikiHero.Services;

namespace WikiHero.ViewModels
{
    public class MenuPageViewModel:BaseViewModel,INavigationAware
    {
        public List<ItemPage> ItemPages { get; set; }
        private ETypeApplication marvelOrDc;
        public DelegateCommand GoToPage { get; set; }
        private ItemPage selectPage;
        public DelegateCommand ChangePageCommand { get; set; }

        public ItemPage SelectPage
        {
            get { return selectPage; }
            set
            {
                selectPage = value;
                if (selectPage != null)
                {
                    GoToPage = new DelegateCommand(async () => await GoToNavigation(SelectPage.Url));
                    GoToPage.Execute();

                }
            }
        }

        public MenuPageViewModel(INavigationService navigationService, IPageDialogService dialogService, IApiComicsVine apiComicsVine) : base(navigationService, dialogService, apiComicsVine)
        {
            ChangePageCommand = new DelegateCommand(async () =>
            {
                marvelOrDc = marvelOrDc == ETypeApplication.Marvel? ETypeApplication.DC : ETypeApplication.Marvel;
                var param = new NavigationParameters();
                param.Add($"{ConfigPageUri.NextPage}", marvelOrDc);
                await navigationService.NavigateAsync($"{ConfigPageUri.MenuPage}{ConfigPageUri.SharedTransitionNavigationPage}{ConfigPageUri.HomePage}",param);
            });
             ItemPages = new List<ItemPage>() {
                     new ItemPage("marvelhome","Home",$"/HomePage"),
                    new ItemPage("ic_action_live_tv.png","Series",ConfigPageUri.SeriePage),
                    new ItemPage("comic","Volumes",ConfigPageUri.VolumePage),
                    new ItemPage("MarvelCharacter","Characters",ConfigPageUri.CharacterPage),
                    new ItemPage("sword","Vs",ConfigPageUri.VsPage)
             };
        }
        async Task GoToNavigation(string page)
        {
            var param = new NavigationParameters();
            param.Add($"{ConfigPageUri.NextPage}", marvelOrDc);
            await navigationService.NavigateAsync(new Uri($"{ConfigPageUri.SharedTransitionNavigationPage}{page}", UriKind.Relative), param);
        }

        public void OnNavigatedFrom(INavigationParameters parameters)
        {
        }

        public void OnNavigatedTo(INavigationParameters parameters)
        {
            var param = (ETypeApplication)parameters[$"{ConfigPageUri.NextPage}"];
            marvelOrDc = param;
            Publisher = marvelOrDc.ToString();
        }
    }
}
