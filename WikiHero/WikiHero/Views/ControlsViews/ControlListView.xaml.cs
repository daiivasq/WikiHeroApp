using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WikiHero.Views.ControlsViews
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ControlListView : ContentView
    {
        public static readonly BindableProperty ItemsSourceProperty = BindableProperty.Create(
            nameof(ItemsSource),
            typeof(IList),
            typeof(ControlListView),
            propertyChanged: ColletionViewChanged);
        public IList ItemsSource
        {
            get => (IList)GetValue(ItemsSourceProperty);
            set => SetValue(ItemsSourceProperty, value);
        }
        public static readonly BindableProperty ColorProperty = BindableProperty.Create(nameof(ColorFrame), typeof(Color), typeof(CardView));
        public Color ColorFrame
        {
            get => (Color)GetValue(ColorProperty);
            set => SetValue(ColorProperty, value);
        }
        private static void ColletionViewChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (!(bindable is ControlListView control)) return;
            var items = (IList)newValue;
            control.publisherList.ItemsSource = items;
        }
        public ControlListView()
        {
            InitializeComponent();
        }
    }
}