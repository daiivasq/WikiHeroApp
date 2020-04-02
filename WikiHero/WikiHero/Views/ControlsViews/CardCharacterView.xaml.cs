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
    public partial class CardCharacterView : ContentView
    {
        // inteligence
        public static readonly BindableProperty InteligentProperty = BindableProperty.Create(
            nameof(Inteligent),
            typeof(string),
            typeof(CardCharacterView),
            propertyChanged: InteligentPropertyChanged);
        public string Inteligent
        {
            get => (string)GetValue(InteligentProperty);
            set => SetValue(InteligentProperty, value);
        }
        private static void InteligentPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (!(bindable is CardCharacterView control)) return;
            var items = (string)newValue;
            control.LabelInteligent.Text = items;
        }
        // Power
        public static readonly BindableProperty PowerProperty = BindableProperty.Create(
            nameof(Power),
            typeof(string),
            typeof(CardCharacterView),
            propertyChanged: PowerPropertyChanged);
        public string Power
        {
            get => (string)GetValue(PowerProperty);
            set => SetValue(PowerProperty, value);
        }
        private static void PowerPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (!(bindable is CardCharacterView control)) return;
            var items = (string)newValue;
            control.LabelPower.Text = items;
        }
        // Strength
        public static readonly BindableProperty StrengthProperty = BindableProperty.Create(
            nameof(Inteligent),
            typeof(string),
            typeof(CardCharacterView),
            propertyChanged: StrengthPropertyChanged);
        public string Strength
        {
            get => (string)GetValue(StrengthProperty);
            set => SetValue(StrengthProperty, value);
        }
        private static void StrengthPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (!(bindable is CardCharacterView control)) return;
            var items = (string)newValue;
            control.LabelStrength.Text = items;
        }
        
        // Durability
        public static readonly BindableProperty DurabilityProperty = BindableProperty.Create(
            nameof(Durability),
            typeof(string),
            typeof(CardCharacterView),
            propertyChanged: DurabilityPropertyChanged);
        public string Durability
        {
            get => (string)GetValue(DurabilityProperty);
            set => SetValue(DurabilityProperty, value);
        }
        private static void DurabilityPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (!(bindable is CardCharacterView control)) return;
            var items = (string)newValue;
            control.LabelDurability.Text = items;
        }
        
        // Speed
        public static readonly BindableProperty SpeedProperty = BindableProperty.Create(
            nameof(Speed),
            typeof(string),
            typeof(CardCharacterView),
            propertyChanged: SpeedPropertyChanged);
        public string Speed
        {
            get => (string)GetValue(SpeedProperty);
            set => SetValue(SpeedProperty, value);
        }
        private static void SpeedPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (!(bindable is CardCharacterView control)) return;
            var items = (string)newValue;
            control.LabelSpeed.Text = items;
        }
      
        // Combat
        public static readonly BindableProperty CombatProperty = BindableProperty.Create(
            nameof(Combat),
            typeof(string),
            typeof(CardCharacterView),
            propertyChanged: CombatPropertyChanged);
        public string Combat
        {
            get => (string)GetValue(CombatProperty);
            set => SetValue(CombatProperty, value);
        }
        private static void CombatPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (!(bindable is CardCharacterView control)) return;
            var items = (string)newValue;
            control.LabelCombat.Text = items;
        }
       
        public static readonly BindableProperty CharacterImageProperty = BindableProperty.Create(
         nameof(CharacterImage),
         typeof(ImageSource),
         typeof(CardCharacterView),
         propertyChanged: CharacterImagePropertyChanged);
        public ImageSource CharacterImage
        {
            get => (ImageSource)GetValue(CharacterImageProperty);
            set => SetValue(CharacterImageProperty, value);
        }
        private static void CharacterImagePropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (!(bindable is CardCharacterView control)) return;
            var items = (ImageSource)newValue;
            control.ImageCharacters.Source = items;
        }
            public static readonly BindableProperty AverageProperty = BindableProperty.Create(
            nameof(Average),
            typeof(string),
            typeof(CardCharacterView),
            propertyChanged: AveragePropertyChanged);
        public string Average
        {
            get => (string)GetValue(AverageProperty);
            set => SetValue(AverageProperty, value);
        }
        private static void AveragePropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (!(bindable is CardCharacterView control)) return;
            var items = (string)newValue;
            control.LabelAverage.Text = items;
        }
        public CardCharacterView()
        {
            InitializeComponent();
        }
    }
}