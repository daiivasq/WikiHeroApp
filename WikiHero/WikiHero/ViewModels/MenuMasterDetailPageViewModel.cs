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
    public abstract class MenuMasterDetailPageViewModel : BaseViewModel
    {
        public List<ItemPage> ItemPages { get; set; }
        public string MarvelOrDc { get; set; }
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
        public MenuMasterDetailPageViewModel(INavigationService navigationService, IPageDialogService dialogService, IApiComicsVine apiComicsVine, string pubisher) : base(navigationService, dialogService, apiComicsVine)
        {
            this.MarvelOrDc = pubisher;
            SelectMasterDetail();
        }
        void SelectMasterDetail()
        {
            switch (MarvelOrDc)
            {
                case Marvel:
                    ItemPages = new List<ItemPage>() {
                    new ItemPage("marvelhome","Home",ConfigPageUri.MarvelHomePage),
                    new ItemPage("ic_action_live_tv.png","Series",ConfigPageUri.MarvelSeriesPage),
                    new ItemPage("comic","Volumes",ConfigPageUri.MarvelVolumePage),
                    new ItemPage("MarvelCharacter","Characters",ConfigPageUri.MarvelCharactersPage),
                    new ItemPage("sword","Vs",ConfigPageUri.MarvelCompareCharacterPage)
                    };
                    break;
                case Dc:
                    ItemPages = new List<ItemPage>() {
                 new ItemPage("dchome","Home",ConfigPageUri.DcHomePage),
                 new ItemPage("ic_action_live_tv","Series",ConfigPageUri.DcSeriesPage),
                 new ItemPage("comic","Volumes",ConfigPageUri.DcVolumePage),
                 new ItemPage("superhero_batman_hero_comic.png","Characters",ConfigPageUri.DcComicsCharactersPage),
                 new ItemPage("sword","Vs",ConfigPageUri.MarvelCompareCharacterPage)
                     };
                    break;

                default:
                    break;
            }
        }
        async Task GoToNavigation(string page)
        {
            await navigationService.NavigateAsync(new Uri($"{ConfigPageUri.SharedTransitionNavigationPage}{page}", UriKind.Relative));
        }

        protected const string Marvel = "Marvel";
        protected const string Dc = "Dc";

    }

}
