using System.Windows.Input;
using Xamarin.Forms;

namespace GoEng.Cells
{
    public partial class HomeDetailsCell : Grid
    {
        public HomeDetailsCell()
        {
            InitializeComponent();
        }

        public static readonly BindableProperty TapCommandProperty = BindableProperty.Create(
            propertyName: nameof(TapCommand),
            returnType: typeof(ICommand),
            declaringType: typeof(HomeCell));
        public ICommand TapCommand
        {
            get => (ICommand)GetValue(TapCommandProperty);
            set => SetValue(TapCommandProperty, value);
        }
    }
}