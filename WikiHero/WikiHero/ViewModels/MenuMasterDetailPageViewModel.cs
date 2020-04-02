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
            const string marvel = "Marvel";
            const string dc = "Dc";
            MarvelOrDc = (string)parameters[ConfigPageUri.MenuMasterDetailPage];
            switch (MarvelOrDc)
            {
                case marvel:
                    ItemPages = new List<ItemPage>() {
                    new ItemPage("Homemarvel","Home",ConfigPageUri.MarvelHomePage),
                    new ItemPage("ic_action_tv","Series",ConfigPageUri.MarvelSeriesPage),
                    new ItemPage("comic","Volumes",ConfigPageUri.MarvelVolumePage),
                    new ItemPage("DcCharacters","Characters",ConfigPageUri.MarvelCharactersPage),
                    new ItemPage("swordImage","Vs",ConfigPageUri.MarvelCompareCharacterPage),
            };
                    break;
                case dc:
                    ItemPages = new List<ItemPage>() {
                 new ItemPage("Homemarvel","Home",ConfigPageUri.DcHomePage),
                 new ItemPage("ic_action_tv","Series",ConfigPageUri.DcSeriesPage),
                 new ItemPage("comic","Volumes",ConfigPageUri.DcVolumePage),
                 new ItemPage("DcCharacters","Characters",ConfigPageUri.DcComicsCharactersPage),
                 new ItemPage("swordImage.png","Vs",ConfigPageUri.MarvelCompareCharacterPage),
              };
                    break;

                default:
                    break;
            }
        }
    }
}
