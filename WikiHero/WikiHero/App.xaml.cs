using Plugin.AppShortcuts;
using Plugin.AppShortcuts.Icons;
using Plugin.SharedTransitions;
using Prism;
using Prism.Ioc;
using Prism.Unity;
using System;
using System.Linq;
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
        public const string AppShortcutUriBase = "asfs://appshortcutsformssample/";
        public const string ShortcutOption1 = "Marvel";
        public const string ShortcutOption2 = "Dc Comics";
        protected override void OnInitialized()
        {
            AddShortcuts();
            InitializeComponent();
            NavigationService.NavigateAsync(new Uri($"{ConfigPageUri.SharedTransitionNavigationPage}{ConfigPageUri.MarvelVsDcComicsPage}", UriKind.Absolute));

        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterInstance<IApiComicsVine>(new ApiComicsVine());
            containerRegistry.RegisterInstance<IApiCharacterStats>(new ApiStatsCharacters());
            containerRegistry.RegisterForNavigation<MarvelVsDcComicsPage, MarvelVsDcComicsPageViewModel>();
            containerRegistry.RegisterForNavigation<DetailSeriesPage, DetailSeriesPageViewModel>();
            containerRegistry.RegisterForNavigation<DetailCharactersPage, DetailCharactersPageViewModel>();
            containerRegistry.RegisterForNavigation<NavigationPage>(); 
            containerRegistry.RegisterForNavigation<SharedTransitionNavigationPage>();
            containerRegistry.RegisterForNavigation<NextPage, NextPageViewModel>();
            containerRegistry.RegisterForNavigation<VideoPage, VideoPageViewModel>();
            containerRegistry.RegisterForNavigation<DetailVolumePage>();
            containerRegistry.RegisterForNavigation<DetailComicPage>();

            containerRegistry.RegisterForNavigation<MarvelCharactersPage, MarvelCharacterPageViewModel>();
            containerRegistry.RegisterForNavigation<MarvelVolumePage, MarvelVolumePageViewModel>();
            containerRegistry.RegisterForNavigation<MarvelHomePage, MarvelHomePageViewModel>();
            containerRegistry.RegisterForNavigation<MarvelSeriesPage, MarvelSeriesPageViewModel>();
            containerRegistry.RegisterForNavigation<MarvelMasterDetailPage, MarvelMasterDetailPageViewModel>();
            containerRegistry.RegisterForNavigation<MarvelFavoritesPage>();
            containerRegistry.RegisterForNavigation<MarvelCompareCharacterPage, MarvelCompareCharacterPageViewModel>();
            
            

            containerRegistry.RegisterForNavigation<DcCharactersPage, DCCharactersPageViewModel>();
            containerRegistry.RegisterForNavigation<DcVolumePage, DcVolumePageViewModel>();
            containerRegistry.RegisterForNavigation<DcHomePage, DcHomePageViewModel>();
            containerRegistry.RegisterForNavigation<DcMasterDetailPage, DcMasterDetailPageViewModel>();
            containerRegistry.RegisterForNavigation<DcSeriesPage, DcSeriesPageViewModel>();
            containerRegistry.RegisterForNavigation<DcFavoritesPage>();
            containerRegistry.RegisterForNavigation<DcCompareCharacterPage, DcCompareCharacterPageViewModel>();
        }

        async void AddShortcuts()
        {
            if (CrossAppShortcuts.IsSupported)
            {

                var shortCurts = await CrossAppShortcuts.Current.GetShortcuts();
                if (shortCurts.FirstOrDefault(prop => prop.Label == "Marvel") == null)
                {
                    var shortcut = new Shortcut()
                    {
                        Label = "Marvel",
                        Description = "Go to Marvel",
                        Icon = new ContactIcon(),
                        Uri = $"{ConfigPageUri.SharedTransitionNavigationPage}{ConfigPageUri.MarvelHomePage}"
                    };
                    await CrossAppShortcuts.Current.AddShortcut(shortcut);
                }

                if (shortCurts.FirstOrDefault(prop => prop.Label == "DC Comics") == null)
                {
                    var shortcut = new Shortcut()
                    {
                        Label = "DC Comics",
                        Description = "Go to Dc Comics",
                        Icon = new UpdateIcon(),
                        Uri = $"{ConfigPageUri.SharedTransitionNavigationPage}{ConfigPageUri.DcHomePage}"
                    };
                    await CrossAppShortcuts.Current.AddShortcut(shortcut);
                }
            }
        }

        protected override void OnAppLinkRequestReceived(Uri uri)
        {
            var option = uri.ToString().Replace(AppShortcutUriBase, "");
            OnInitialized();
            if (!string.IsNullOrEmpty(option))
            {
                switch (option)
                {
                    case ShortcutOption1:
                        NavigationService.NavigateAsync(new Uri($"{ConfigPageUri.SharedTransitionNavigationPage}{ConfigPageUri.MarvelHomePage}", UriKind.Absolute));
                        break;
                    case ShortcutOption2:

                        NavigationService.NavigateAsync(new Uri($"{ConfigPageUri.SharedTransitionNavigationPage}{ConfigPageUri.DcHomePage}", UriKind.Absolute));
                        break;
                }
            }
            else
                base.OnAppLinkRequestReceived(uri);
        }
    }
}
