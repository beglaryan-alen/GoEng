using Xamarin.Forms;

namespace GoEng.Controls
{
    public partial class CustomEntry : Frame
    {
        public CustomEntry()
        {
            InitializeComponent();
        }

        public static readonly BindableProperty IsPasswordProperty = BindableProperty.Create(
            propertyName: nameof(IsPassword),
            returnType: typeof(bool),
            declaringType: typeof(CustomEntry));
        public bool IsPassword
        {
            get => (bool)GetValue(IsPasswordProperty);
            set => SetValue(IsPasswordProperty, value);
        }

        public static readonly BindableProperty PlaceHolderProperty = BindableProperty.Create(
             propertyName: nameof(PlaceHolder),
             returnType: typeof(string),
             declaringType: typeof(CustomEntry));
        public string PlaceHolder
        {
            get => (string)GetValue(PlaceHolderProperty);
            set => SetValue(PlaceHolderProperty, value);
        }

        public static readonly BindableProperty IsRightIconVisibleProperty = BindableProperty.Create(
            propertyName: nameof(IsRightIconVisible),
            returnType: typeof(bool),
            declaringType: typeof(CustomEntry));
        public bool IsRightIconVisible
        {
            get => (bool)GetValue(IsRightIconVisibleProperty);
            set => SetValue(IsRightIconVisibleProperty, value);
        }

        public static readonly BindableProperty TextProperty = BindableProperty.Create(
                   propertyName: nameof(Text),
                   returnType: typeof(string),
                   declaringType: typeof(CustomEntry),
                   defaultBindingMode:BindingMode.TwoWay);
        public string Text
        {
            get => (string)GetValue(TextProperty);
            set => SetValue(TextProperty, value);
        }

        public static readonly BindableProperty IsNumericProperty = BindableProperty.Create(
                   propertyName: nameof(IsNumeric),
                   returnType: typeof(bool),
                   declaringType: typeof(CustomEntry));
        public bool IsNumeric
        {
            get => (bool)GetValue(IsNumericProperty);
            set => SetValue(IsNumericProperty, value);
        }

        public static readonly BindableProperty TextColorProperty = BindableProperty.Create(
                   propertyName: nameof(TextColor),
                   returnType: typeof(Color),
                   declaringType: typeof(CustomEntry));
        public Color TextColor
        {
            get => (Color)GetValue(TextColorProperty);
            set => SetValue(IsNumericProperty, value);
        }

        private void TapGestureRecognizer_Tapped(object sender, System.EventArgs e)
        {
            IsPassword = !IsPassword;
        }
    }
}