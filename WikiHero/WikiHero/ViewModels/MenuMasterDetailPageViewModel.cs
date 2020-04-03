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
    public class MenuMasterDetailPageViewModel : BaseViewModel,INavigatedAware
    {
        public List<ItemPage> ItemPages { get; set; }
        public string MarvelOrDc { get; set; }
        public DelegateCommand GoToPage{ get; set; }
        private ItemPage selectPage;

        public ItemPage SelectPage
        {
            get { return selectPage; }
            set { 
                selectPage = value;
                if (selectPage!= null) {
                    GoToPage = new DelegateCommand(async()=>await GoToNavigation(SelectPage.Url));
                    GoToPage.Execute();

                }
            }
        }

        public MenuMasterDetailPageViewModel(INavigationService navigationService, IPageDialogService dialogService, IApiComicsVine apiComicsVine) : base(navigationService, dialogService, apiComicsVine)
        {


           
        }
        async Task GoToNavigation(string page)
        {
            await navigationService.NavigateAsync(new Uri($"{ConfigPageUri.SharedTransitionNavigationPage}{page}",UriKind.Relative));
        }

        public void OnNavigatedFrom(INavigationParameters parameters)
        {
           
        }

        public void OnNavigatedTo(INavigationParameters parameters)
        {
            const string marvel = "ironman.gif";
            const string dc = "batman.gif";
            MarvelOrDc = (string)parameters[ConfigPageUri.MenuMasterDetailPage];
            switch (MarvelOrDc)
            {
                case marvel:
                    ItemPages = new List<ItemPage>() {
                    new ItemPage("marvelhome","Home",ConfigPageUri.MarvelHomePage),
                    new ItemPage("monitor","Series",ConfigPageUri.MarvelSeriesPage),
                    new ItemPage("comic","Volumes",ConfigPageUri.MarvelVolumePage),
                    new ItemPage("MarvelCharacter","Characters",ConfigPageUri.MarvelCharactersPage),
                    new ItemPage("sword","Vs",ConfigPageUri.MarvelCompareCharacterPage),
                     new ItemPage("star","favorites",ConfigPageUri.MarvelFavoritesPage),
            };
                    break;
                case dc:
                    ItemPages = new List<ItemPage>() {
                 new ItemPage("dchome","Home",ConfigPageUri.DcHomePage),
                 new ItemPage("monitor","Series",ConfigPageUri.DcSeriesPage),
                 new ItemPage("comic","Volumes",ConfigPageUri.DcVolumePage),
                 new ItemPage("DcCharacter","Characters",ConfigPageUri.DcComicsCharactersPage),
                 new ItemPage("sword","Vs",ConfigPageUri.MarvelCompareCharacterPage),
                 new ItemPage("star","favorites",ConfigPageUri.DcFavoritesPage),
              };
                    break;

                default:
                    break;
            }
        }
    }
}
