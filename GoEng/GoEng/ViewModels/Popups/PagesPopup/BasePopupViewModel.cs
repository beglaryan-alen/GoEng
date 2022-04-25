using MvvmHelpers.Commands;
using Prism.Navigation;
using System.Windows.Input;

namespace GoEng.ViewModels.Popups.PagesPopup
{
    public class BasePopupViewModel : BaseViewModel
    {
        public BasePopupViewModel(
            INavigationService navigationService) 
            : base(navigationService)
        {
        }

        public ICommand ClearPopupCommand => new AsyncCommand(async () => await NavigationService.ClearPopupStackAsync());

        private string _title;
        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }
    }
}
