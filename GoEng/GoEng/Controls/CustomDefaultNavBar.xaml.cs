using System.Windows.Input;
using Xamarin.Forms;

namespace GoEng.Controls
{
    public partial class CustomDefaultNavBar : StackLayout
    {
        public CustomDefaultNavBar()
        {
            InitializeComponent();
        }

        public static readonly BindableProperty IconProperty = BindableProperty.Create(
             propertyName: nameof(Icon),
             returnType: typeof(string),
             declaringType: typeof(CustomDefaultNavBar));
        public string Icon
        {
            get => (string)GetValue(IconProperty);
            set => SetValue(IconProperty, value);
        }

        public static readonly BindableProperty CloseCommandProperty = BindableProperty.Create(
             propertyName: nameof(CloseCommand),
             returnType: typeof(ICommand),
             declaringType: typeof(CustomDefaultNavBar));
        public ICommand CloseCommand
        {
            get => (ICommand)GetValue(CloseCommandProperty);
            set => SetValue(CloseCommandProperty, value);
        }

        public static readonly BindableProperty TitleProperty = BindableProperty.Create(
             propertyName: nameof(Title),
             returnType: typeof(string),
             declaringType: typeof(CustomDefaultNavBar));
        public string Title
        {
            get => (string)GetValue(TitleProperty);
            set => SetValue(TitleProperty, value);
        }
    }
}