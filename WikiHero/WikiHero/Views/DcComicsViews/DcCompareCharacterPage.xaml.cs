using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WikiHero.Views.ControlsViews;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WikiHero.Views.DcComicsViews
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DcCompareCharacterPage : ContentPage
    {
        public DcCompareCharacterPage()
        {
            InitializeComponent();
        }
        private async void CompareButton_Clicked(object sender, EventArgs e)
        {
            int aAverage = Convert.ToInt32(HeroesView.Average);
            int bAverage = Convert.ToInt32(VillainView.Average);
            if (aAverage > bAverage)
            {
                await AnimationWin(HeroesView, VillainView, 120);
            }
            else
            {
                await AnimationWin(VillainView, HeroesView, -120);

            }
        }
        async Task AnimationWin(CardCharacterView wincard, CardCharacterView losecard, int x)
        {
            losecard.IsVisible = false;
            CompareButton.IsVisible = false;
            await wincard.TranslateTo(x, 0, 500, Easing.SpringIn);
            wincard.BackgroundColor = Color.Gold;
            await wincard.ScaleTo(1.5, 200);
            await wincard.ScaleTo(1, 200, Easing.SpringOut);
            await wincard.TranslateTo(0, 0);
            wincard.BackgroundColor = Color.White;
            losecard.IsVisible = true;
            CompareButton.IsVisible = true;
        }
    }
}