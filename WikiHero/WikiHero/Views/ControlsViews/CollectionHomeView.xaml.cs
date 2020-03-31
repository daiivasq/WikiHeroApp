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
    public partial class CollectionHomeView : ContentView
    {
        public static readonly BindableProperty ItemsSourceProperty = BindableProperty.Create(
     nameof(ItemsSource),
     typeof(IList),
     typeof(CollectionHomeView),
     propertyChanged: ColletionViewChanged);


        public static readonly BindableProperty ColorProperty = BindableProperty.Create(nameof(ColorFrame), typeof(Color), typeof(CollectionHomeView));

        public static readonly BindableProperty SelectItemProperty = BindableProperty.Create(
         nameof(SelectItem),
         typeof(object),
         typeof(CollectionStats),
         propertyChanged: SelectItemChanged);


        public Color ColorFrame
        {
            get => (Color)GetValue(ColorProperty);
            set => SetValue(ColorProperty, value);
        }
        public IList ItemsSource
        {
            get => (IList)GetValue(ItemsSourceProperty);
            set => SetValue(ItemsSourceProperty, value);
        }
        public object SelectItem
        {
            get => GetValue(SelectItemProperty);
            set => SetValue(SelectItemProperty, value);
        }
        private static void ColletionViewChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (!(bindable is CollectionHomeView control)) return;
            var items = (IList)newValue;
            control.CharactersList.ItemsSource = items;
        }
        private static void SelectItemChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (!(bindable is CollectionHomeView control)) return;
            var items = newValue;
            control.CharactersList.SelectedItem = (CollectionHomeView)items;
        }
        public CollectionHomeView()
        {
            InitializeComponent();
        }
    }
}