using Prism;
using Prism.Ioc;
using Prism.Unity;
using System;
using WikiHeroApp.Helpers;
using WikiHeroApp.Services;
using WikiHeroApp.ViewModels;
using WikiHeroApp.ViewModels.DCViewModels;
using WikiHeroApp.ViewModels.MarvelViewModels;
using WikiHeroApp.Views;
using WikiHeroApp.Views.DcComicsViews;
using WikiHeroApp.Views.MarvelViews;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
namespace WikiHeroApp
{
    public partial class App : PrismApplication
    {
        public App(IPlatformInitializer initializer = null) : base(initializer) { }

        protected override void OnInitialized()
        {
            InitializeComponent();
            NavigationService.NavigateAsync(new Uri($"{ConfigPageUri.MarvelVsDcComicsPage}", UriKind.Absolute));

        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {

            containerRegistry.RegisterInstance<ApiComicsVine>(new ApiComicsVine());
            containerRegistry.RegisterInstance<ApiStatsCharacters>(new ApiStatsCharacters());
            containerRegistry.RegisterForNavigation<MarvelVsDcComicsPage, MarvelVsDcComicsPageViewModel>();
            containerRegistry.RegisterForNavigation<NavigationPage>();

            containerRegistry.RegisterForNavigation<MarvelCharactersPage, MarvelCharacterPageViewModel>();
            containerRegistry.RegisterForNavigation<MarvelVolumePage, MarvelVolumePageViewModel>();
            containerRegistry.RegisterForNavigation<MarvelHomePage, MarvelHomePageViewModel>();
            containerRegistry.RegisterForNavigation<MarvelSeriesPage, MarvelSeriesPageViewModel>();
            containerRegistry.RegisterForNavigation<TappedMarvelPage, TappedMarvelPageViewModel>();
            containerRegistry.RegisterForNavigation<MarvelCompareCharacterPage, MarvelCompareCharacterPageViewModel>();

            containerRegistry.RegisterForNavigation<DcCharactersPage, DCCharactersPageViewModel>();
            containerRegistry.RegisterForNavigation<MarvelVolumePage, DcVolumePageViewModel>();
            containerRegistry.RegisterForNavigation<DcHomePage, DcHomePageViewModel>();
            containerRegistry.RegisterForNavigation<DcSeriesPage, DcSeriesPageViewModel>();
            containerRegistry.RegisterForNavigation<TappedDcComicsPage, TappedDcComicsPageViewModel>();
            containerRegistry.RegisterForNavigation<DcCompareCharacterPage, DcCompareCharacterPageViewModel>();
        }
    }
}
