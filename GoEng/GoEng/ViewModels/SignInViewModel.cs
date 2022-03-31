using GoEng.ViewModels.SignInDetails;
using Prism.Navigation;
using System.Collections.ObjectModel;

namespace GoEng.ViewModels
{
    public class SignInViewModel : BaseViewModel
    {
        public SignInViewModel(
            INavigationService navigationService)
            : base(navigationService)
        {
        }

        private ObservableCollection<SignInDetailTabViewModel> _tabItems;
        public ObservableCollection<SignInDetailTabViewModel> TabItems
        {
            get => _tabItems;
            set => SetProperty(ref _tabItems, value);
        }

        private int _currentTabIndex;
        public int CurrentTabIndex
        {
            get => _currentTabIndex;
            set => SetProperty(ref _currentTabIndex, value);
        }

        private LoginTabViewModel _loginTabViewModel;
        public LoginTabViewModel LoginTabViewModel
        {
            get => _loginTabViewModel;
            set => SetProperty(ref _loginTabViewModel, value);
        }

        private RegisterTabViewModel _registerTabViewModel;
        public RegisterTabViewModel RegisterTabViewModel
        {
            get => _registerTabViewModel;
            set => SetProperty(ref _registerTabViewModel, value);
        }

        #region Overrides

        public override void Initialize(INavigationParameters parameters)
        {
            base.Initialize(parameters);

            RegisterTabViewModel = App.Resolve<RegisterTabViewModel>();
            LoginTabViewModel = App.Resolve<LoginTabViewModel>();


            TabItems = new ObservableCollection<SignInDetailTabViewModel>()
            {
                RegisterTabViewModel,
                LoginTabViewModel,
            };
            CurrentTabIndex = (int)parameters["pageIndex"];

            RegisterTabViewModel.Initialize(parameters);
            LoginTabViewModel.Initialize(parameters);
        }

        public override void OnAppearing()
        {
            base.OnAppearing();

            RegisterTabViewModel.OnAppearing();
            LoginTabViewModel.OnAppearing();
        }

        #endregion

    }
}