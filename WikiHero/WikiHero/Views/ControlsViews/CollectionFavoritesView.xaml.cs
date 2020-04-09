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
    public partial class CollectionFavoritesView : ContentView
    {
        public static readonly BindableProperty ItemsSourceProperty = BindableProperty.Create(
         nameof(ItemsSource),
         typeof(IList),
         typeof(CollectionFavoritesView),
         propertyChanged: ColletionViewChanged);
       

        

        public static readonly BindableProperty SelectItemProperty = BindableProperty.Create(
        nameof(SelectItem),
        typeof(object),
        typeof(CollectionFavoritesView),
        propertyChanged: SelectItemChanged);
      
        public object SelectItem
        {
            get => GetValue(SelectItemProperty);
            set => SetValue(SelectItemProperty, value);
        }

        private static void SelectItemChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (!(bindable is CollectionFavoritesView control)) return;
            var items = newValue;
            control.publisherList.SelectedItem = (object)items;
        }
     
        public IList ItemsSource
        {
            get => (IList)GetValue(ItemsSourceProperty);
            set => SetValue(ItemsSourceProperty, value);
        }
        private static void ColletionViewChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (!(bindable is CollectionFavoritesView control)) return;
            var items = (IList)newValue;
            control.publisherList.ItemsSource = items;
        }
      
        public CollectionFavoritesView()
        {
            InitializeComponent();
            
        }
    }
}