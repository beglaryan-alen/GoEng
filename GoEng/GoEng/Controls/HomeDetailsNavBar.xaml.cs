using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GoEng.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomeDetailsNavBar : StackLayout
    {
        public HomeDetailsNavBar()
        {
            InitializeComponent();
        }

        public static readonly BindableProperty TitleProperty = BindableProperty.Create(
            nameof(Title),
            typeof(string),
            typeof(HomeDetailsNavBar),
            defaultBindingMode: BindingMode.TwoWay);
        public string Title
        {
            get => (string)GetValue(TitleProperty);
            set => SetValue(TitleProperty, value);
        }

        public static readonly BindableProperty CurrentGameVariantProperty = BindableProperty.Create(
            nameof(CurrentGameVariant),
            typeof(int),
            typeof(HomeDetailsNavBar),
            defaultBindingMode: BindingMode.TwoWay);
        public int CurrentGameVariant
        {
            get => (int)GetValue(CurrentGameVariantProperty);
            set => SetValue(CurrentGameVariantProperty, value);
        }

        public static readonly BindableProperty GameVariantsCountProperty = BindableProperty.Create(
           nameof(GameVariantsCount),
           typeof(int),
           typeof(HomeDetailsNavBar),
           defaultBindingMode: BindingMode.TwoWay);
        public int GameVariantsCount
        {
            get => (int)GetValue(GameVariantsCountProperty);
            set => SetValue(GameVariantsCountProperty, value);
        }

        public static readonly BindableProperty GoBackCommandProperty = BindableProperty.Create(
           nameof(GoBackCommand),
           typeof(ICommand),
           typeof(HomeDetailsNavBar));
        public ICommand GoBackCommand
        {
            get => (ICommand)GetValue(GoBackCommandProperty);
            set => SetValue(GoBackCommandProperty, value);
        }

        public static readonly BindableProperty CoinsProperty = BindableProperty.Create(
           nameof(Coins),
           typeof(int),
           typeof(HomeDetailsNavBar),
           defaultBindingMode: BindingMode.TwoWay);
        public int Coins
        {
            get => (int)GetValue(GameVariantsCountProperty);
            set => SetValue(GameVariantsCountProperty, value);
        }

        public static readonly BindableProperty IsRightIconVisibleProperty = BindableProperty.Create(
           nameof(IsRightIconVisible),
           typeof(bool),
           typeof(HomeDetailsNavBar));
        public bool IsRightIconVisible
        {
            get => (bool)GetValue(IsRightIconVisibleProperty);
            set => SetValue(IsRightIconVisibleProperty, value);
        }

        public static readonly BindableProperty HasLoadControlProperty = BindableProperty.Create(
           nameof(HasLoadControl),
           typeof(bool),
           typeof(HomeDetailsNavBar));
        public bool HasLoadControl
        {
            get => (bool)GetValue(IsRightIconVisibleProperty);
            set => SetValue(IsRightIconVisibleProperty, value);
        }
    }
}