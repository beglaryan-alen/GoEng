using Prism.Mvvm;
using System.Windows.Input;

namespace GoEng.Models.NavBar
{
    public class NavBarItemBindableModel : BindableBase
    {
        private string _icon;
        public string Icon
        {
            get => _icon;
            set => SetProperty(ref _icon, value);
        }

        private string _content;
        public string Content
        {
            get => _content;
            set => SetProperty(ref _content, value);
        }

        private bool _isContentVisible;
        public bool IsContentVisible
        {
            get => _isContentVisible;
            set => SetProperty(ref _isContentVisible, value);
        }

        public ICommand TapCommand { get; set; }
    }
}
