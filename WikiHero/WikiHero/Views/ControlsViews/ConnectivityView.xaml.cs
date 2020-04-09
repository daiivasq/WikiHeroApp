using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WikiHero.Views.ControlsViews
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ConnectivityView : ContentView
    {
        public static readonly BindableProperty ImageViewProperty = BindableProperty.Create(nameof(ImageView), typeof(ImageSource), typeof(ConnectivityView));
        public ImageSource ImageView
        { 
            get=>(ImageSource)GetValue(ImageViewProperty);
            set => SetValue(ImageViewProperty, value);
        }
        public static readonly BindableProperty TextViewProperty = BindableProperty.Create(nameof(TextView), typeof(string), typeof(ConnectivityView));
        public string TextView
        {
            get => (string)GetValue(TextViewProperty);
            set => SetValue(TextViewProperty, value);
        }
       
        public ConnectivityView()
        {
            InitializeComponent();
        }
    }
}