using GoEng.Enums.User;
using GoEng.Models.NavBar;
using System.Collections;
using Xamarin.Forms;

namespace GoEng.Controls
{
    public partial class CustomNavBar : StackLayout
    {
        public CustomNavBar()
        {
            InitializeComponent();
        }

        public static readonly BindableProperty SelectedItemProperty = BindableProperty.Create(
           propertyName: nameof(SelectedItem),
           returnType: typeof(NavBarItemBindableModel),
           declaringType: typeof(CustomNavBar),
           defaultValue: null,
           defaultBindingMode: BindingMode.TwoWay);

        public NavBarItemBindableModel SelectedItem
        {
            get => (NavBarItemBindableModel)GetValue(SelectedItemProperty);
            set => SetValue(SelectedItemProperty, value);
        }

        public static readonly BindableProperty ItemsSourceProperty = BindableProperty.Create(
           propertyName: nameof(ItemsSource),
           returnType: typeof(IList),
           declaringType: typeof(CustomNavBar));

        public IList ItemsSource
        {
            get => (IList)GetValue(ItemsSourceProperty);
            set => SetValue(ItemsSourceProperty, value);
        }

        public static readonly BindableProperty RightIconsVisibleProperty = BindableProperty.Create(
            nameof(RightIconsVisible),
            typeof(bool),
            typeof(CustomNavBar));

        public bool RightIconsVisible
        {
            get => (bool)GetValue(RightIconsVisibleProperty);
            set => SetValue(RightIconsVisibleProperty, value);
        }
    }
}