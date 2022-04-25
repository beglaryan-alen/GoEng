using GoEng.Services.AccountService;
using GoEng.Settings;
using GoEng.Views;
using MvvmHelpers.Commands;
using Prism.Navigation;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace GoEng.ViewModels.SignInDetails
{
    public class LoginTabViewModel : SignInDetailTabViewModel
    {
        private readonly IAccountService _accountService;
        public LoginTabViewModel(
            INavigationService navigationService,
            IAccountService accountService)
            : base(navigationService)
        {
            _accountService = accountService;
        }

        #region Public Properties

        public ICommand LoginCommand => new AsyncCommand(OnLoginCommand);

        private string _email;
        public string Email
        {
            get => _email;
            set => SetProperty(ref _email, value);
        }

        private string _password;
        public string Password
        {
            get => _password;
            set => SetProperty(ref _password, value);
        }

        private bool _remember;
        public bool Remember
        {
            get => _remember;
            set => SetProperty(ref _remember, value);
        }
        
        #endregion

        #region Private Helpers

        private async Task OnLoginCommand()
        {
            IsBusy = true;

            var res = await _accountService.LoginAsync(Email, Password, Remember);
            if (res)
            {
                await NavigationService.NavigateAsync($"/{nameof(NavigationPage)}/{nameof(HomeView)}");
            }
            else
            {
                IsBusy = false;
                await App.Current.MainPage.DisplayAlert(AppSettings.AppName, ErrorSettings.IncorrectLoginOrPass, AppSettings.OK);
            }
        }

        #endregion
    }
}
