using Plugin.AppShortcuts;
using Plugin.AppShortcuts.Icons;
using Plugin.SharedTransitions;
using Prism;
using Prism.Ioc;
using Prism.Unity;
using System;
using System.Linq;
using WikiHero.Helpers;
using WikiHero.Models;
using WikiHero.Services;
using WikiHero.ViewModels;
using WikiHero.Views;
using WikiHero.Views.PrincipalPages;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
namespace WikiHero
{
    public partial class App : PrismApplication
    {
        public App(IPlatformInitializer initializer = null) : base(initializer) { }
        public const string AppShortcutUriBase = "Kh://WihiHeroShortcuts/";
        public const string ShortcutOption1 = "Marvel";
            public const string ShortcutOption2 = "DC";


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
            containerRegistry.RegisterForNavigation<DetailVolumePage,DetailVolumePageViewModel>();
            containerRegistry.RegisterForNavigation<DetailComicPage,DetailComicPageViewModel>();
            containerRegistry.RegisterForNavigation<CharacterPage, CharacterPageViewModel>();
            containerRegistry.RegisterForNavigation<MenuPage, MenuPageViewModel>();
            containerRegistry.RegisterForNavigation<HomePage,HomePageViewModel>();
            containerRegistry.RegisterForNavigation<SeriePage, SeriePageViewModel>();
            containerRegistry.RegisterForNavigation<VolumePage, VolumePageViewModel>();
            containerRegistry.RegisterForNavigation<VsPage, VsPageViewModel>(); 
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
                        Uri = $"{AppShortcutUriBase}{ShortcutOption1}"
                    };
                    await CrossAppShortcuts.Current.AddShortcut(shortcut);
                }

                if (shortCurts.FirstOrDefault(prop => prop.Label == "DC") == null)
                {
                    var shortcut = new Shortcut()
                    {
                        Label = "DC",
                        Description = "Go to Dc Comics",
                        Icon = new UpdateIcon(),
                        Uri = $"{AppShortcutUriBase}{ShortcutOption2}"
                    };
                    await CrossAppShortcuts.Current.AddShortcut(shortcut);
                }
            }


        }

        protected override void OnAppLinkRequestReceived(Uri uri)
        {
            var option = uri.ToString().Replace(AppShortcutUriBase, "");
            if (!string.IsNullOrEmpty(option))
            {
             
                switch (option)
                {
                    case ShortcutOption1:
                        NavigationService.NavigateAsync(new Uri($"{ConfigPageUri.SharedTransitionNavigationPage}{ConfigPageUri.HomePage}", UriKind.Absolute));
                        break;
                  
                }
            }
            else
                base.OnAppLinkRequestReceived(uri);
        }
    }
}

