using Plugin.SharedTransitions;
using Prism;
using Prism.Ioc;
using Prism.Unity;
using System;
using WikiHero.Helpers;
using WikiHero.Services;
using WikiHero.ViewModels;
using WikiHero.ViewModels.DCViewModels;
using WikiHero.ViewModels.MarvelViewModels;
using WikiHero.Views;
using WikiHero.Views.DcComicsViews;
using WikiHero.Views.MarvelViews;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
namespace WikiHero
{
    public partial class App : PrismApplication
    {
        public App(IPlatformInitializer initializer = null) : base(initializer) { }

        protected override void OnInitialized()
        {
            InitializeComponent();
            NavigationService.NavigateAsync(new Uri($"{ConfigPageUri.SharedTransitionNavigationPage}{ConfigPageUri.MarvelVsDcComicsPage}", UriKind.Absolute));

        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterInstance<ApiComicsVine>(new ApiComicsVine());
            containerRegistry.RegisterInstance<ApiStatsCharacters>(new ApiStatsCharacters());
            containerRegistry.RegisterForNavigation<MarvelVsDcComicsPage, MarvelVsDcComicsPageViewModel>();
            containerRegistry.RegisterForNavigation<DetailSeriesPage, DetailSeriesPageViewModel>();
            containerRegistry.RegisterForNavigation<NavigationPage>(); 
            containerRegistry.RegisterForNavigation<SharedTransitionNavigationPage>();
            containerRegistry.RegisterForNavigation<MarvelCharactersPage, MarvelCharacterPageViewModel>();
            containerRegistry.RegisterForNavigation<MarvelComicsPage, MarvelVolumePageViewModel>();
            containerRegistry.RegisterForNavigation<MarvelHomePage, MarvelHomePageViewModel>();
            containerRegistry.RegisterForNavigation<MarvelSeriesPage, MarvelSeriesPageViewModel>();
            containerRegistry.RegisterForNavigation<TappedMarvelPage, TappedMarvelPageViewModel>();
            containerRegistry.RegisterForNavigation<MarvelCompareCharacterPage, MarvelCompareCharacterPageViewModel>();

            containerRegistry.RegisterForNavigation<DcCharactersPage, DCCharactersPageViewModel>();
            containerRegistry.RegisterForNavigation<DcComicsPage, DcVolumePageViewModel>();
            containerRegistry.RegisterForNavigation<DcHomePage, DcHomePageViewModel>();
            containerRegistry.RegisterForNavigation<DcSeriesPage, DcSeriesPageViewModel>();
            containerRegistry.RegisterForNavigation<TappedDcComicsPage, TappedDcComicsPageViewModel>();
            containerRegistry.RegisterForNavigation<DcCompareCharacterPage, DcCompareCharacterPageViewModel>();

            


        }
    }
}
