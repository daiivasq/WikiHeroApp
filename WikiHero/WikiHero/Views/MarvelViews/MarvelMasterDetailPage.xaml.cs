using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WikiHero.Views.MarvelViews
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MarvelMasterDetailPage : MasterDetailPage
    {
        public MarvelMasterDetailPage()
        {
            InitializeComponent();
        }
    }
}