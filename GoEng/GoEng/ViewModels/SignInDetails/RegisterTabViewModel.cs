using GoEng.Settings;
using GoEng.Views.RegisterDetails;
using MvvmHelpers.Commands;
using Prism.Navigation;
using System;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GoEng.ViewModels.SignInDetails
{
    public class RegisterTabViewModel : SignInDetailTabViewModel
    {
        public RegisterTabViewModel(
            INavigationService navigationService)
            : base(navigationService)
        {
        }

        #region Public Properties

        private string _errorMessage;
        public string ErrorMessage
        {
            get => _errorMessage;
            set => SetProperty(ref _errorMessage, value);
        }

        private string _emailText;
        public string EmailText
        {
            get => _emailText;
            set => SetProperty(ref _emailText, value);
        }

        private string _password;
        public string Password
        {
            get => _password;
            set => SetProperty(ref _password, value);
        }

        private string _confirmPassword;
        public string ConfirmPassword
        {
            get => _confirmPassword;
            set => SetProperty(ref _confirmPassword, value);
        }

        private bool _canContinue;
        public bool CanContinue
        {
            get => _canContinue;
            set => SetProperty(ref _canContinue, value);
        }

        public ICommand RegisterCommand => new AsyncCommand(OnRegisterCommand);
        public ICommand GoogleCommand => new AsyncCommand(OnGoogleCommand);


        #endregion

        #region Overrides

        protected override void OnPropertyChanged(PropertyChangedEventArgs args)
        {
            base.OnPropertyChanged(args);

            if (!string.IsNullOrWhiteSpace(EmailText) &&
                EmailText.Contains("@") &&
                !string.IsNullOrWhiteSpace(Password) &&
                !string.IsNullOrWhiteSpace(ConfirmPassword) &&
                ConfirmPassword == Password)
            {
                if (Password.Length < 4)
                {
                    ErrorMessage = ErrorSettings.RegisterErrorMessage_LetterLength;
                }
                else if (!Password.Any(c => char.IsLetter(c)))
                {
                    ErrorMessage = ErrorSettings.RegisterErrorMessage_PasswordWithoutLetter;
                }
                else if (!Password.Any(c => char.IsSymbol(c)))
                {
                    ErrorMessage = ErrorSettings.RegisterErrorMessage_PasswordWithoutSymbol;
                }
                else if (!Password.Any(c => char.IsNumber(c)))
                {
                    ErrorMessage = ErrorSettings.RegisterErrorMessage_PasswordWithoutNumber;
                }
                else if (Password.Any(c => char.IsWhiteSpace(c)))
                {
                    ErrorMessage = ErrorSettings.RegisterErrorMessage_PasswordWithWhiteSpace;
                }
                else
                {
                    CanContinue = true;
                    ErrorMessage = "";
                    return;
                }
                CanContinue = false;
            }
            else
                CanContinue = false;
        }

        #endregion

        #region Private Helpers

        private async Task OnRegisterCommand()
        {
            INavigationParameters par = new NavigationParameters();
            par.Add("email", EmailText);
            par.Add("password", Password);
            await NavigationService.NavigateAsync(nameof(GenderNameAndBirthView), par);
        }


        private async Task OnGoogleCommand()
        {
        }

        #endregion
    }
}