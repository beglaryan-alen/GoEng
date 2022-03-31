using Xamarin.Forms;

namespace GoEng.Controls
{
    public partial class SignInIndicatorView : StackLayout
    {
        public SignInIndicatorView()
        {
            InitializeComponent();
        }

        public static readonly BindableProperty SelectedIndexProperty = BindableProperty.Create(
            propertyName: nameof(SelectedIndex),
            returnType: typeof(int),
            declaringType: typeof(SignInIndicatorView),
            defaultBindingMode: BindingMode.TwoWay);

        public int SelectedIndex
        {
            get => (int)GetValue(SelectedIndexProperty);
            set => SetValue(SelectedIndexProperty, value);
        }

        private void TapGestureRecognizer_Tapped(object sender, System.EventArgs e)
        {
            SelectedIndex = 0;
        }

        private void TapGestureRecognizer_Tapped_1(object sender, System.EventArgs e)
        {
            SelectedIndex = 1;
        }
    }
}