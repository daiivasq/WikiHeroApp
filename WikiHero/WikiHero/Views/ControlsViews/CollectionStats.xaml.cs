using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WikiHero.Models.CharacterStatModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WikiHero.Views.ControlsViews
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CollectionStats : ContentView
    {
        public static readonly BindableProperty ItemsSourceProperty = BindableProperty.Create(
          nameof(ItemsSource),
          typeof(IList),
          typeof(CollectionStats),
          propertyChanged: ColletionViewChanged);

        
        public static readonly BindableProperty ColorProperty = BindableProperty.Create(nameof(ColorFrame), typeof(Color), typeof(CollectionStats));
        
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
            if (!(bindable is CollectionStats control)) return;
            var items = (IList)newValue;
            control.CharactersList.ItemsSource = items;
        }
        private static void SelectItemChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (!(bindable is CollectionStats control)) return;
            var items = newValue;
            control.CharactersList.SelectedItem = (CharacterStats)items;
        }
        public CollectionStats()
        {
            InitializeComponent();
            
        }
    }
}