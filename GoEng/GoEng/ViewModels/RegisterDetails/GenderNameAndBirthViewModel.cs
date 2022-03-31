using GoEng.Enums;
using GoEng.Services.Auth;
using GoEng.Settings;
using GoEng.Views.RegisterDetails;
using MvvmHelpers.Commands;
using Prism.Navigation;
using System;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GoEng.ViewModels.RegisterDetails
{
    public class GenderNameAndBirthViewModel : BaseViewModel
    {
        private readonly IAuth _auth;
        private string email;
        private string password;
        public GenderNameAndBirthViewModel(
            INavigationService navigationService,
            IAuth auth)
            : base(navigationService)
        {
            _auth = auth;
        }

        #region Public Properties

        private EGender _gender;
        public EGender Gender
        {
            get => _gender;
            set => SetProperty(ref _gender, value);
        }

        private string _name;
        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }

        private DateTime _birthDate;
        public DateTime BirthDate
        {
            get => _birthDate;
            set => SetProperty(ref _birthDate, value);
        }

        private bool _canContinue;
        public bool CanContinue
        {
            get => _canContinue;
            set => SetProperty(ref _canContinue, value);
        }

        public ICommand GirlCommand => new Command(() => Gender = EGender.Female);
        public ICommand BoyCommand => new Command(() => Gender = EGender.Male);
        public ICommand NextCommand => new AsyncCommand(OnNextCommand);

        #endregion

        #region Overrides

        public override void Initialize(INavigationParameters parameters)
        {
            base.Initialize(parameters);
            Gender = EGender.None;
            email = parameters.GetValue<string>("email");
            password = parameters.GetValue<string>("password");
            BirthDate = DateTime.Parse("01/01/2018");
        }

        protected override void OnPropertyChanged(PropertyChangedEventArgs args)
        {
            base.OnPropertyChanged(args);

            if (Gender != EGender.None &&
                BirthDate != default &&
                DateTime.Now.Year - BirthDate.Year < 90 &&
                DateTime.Now.Year - BirthDate.Year > 3 &&
                !string.IsNullOrWhiteSpace(Name))
            {
                CanContinue = true;
            }
            else
            {
                CanContinue = false;
            }
        }

        #endregion

        #region Implemented Commands

        private async Task OnNextCommand()
        {
            IsBusy = true;
                var res = await _auth.SignUp(email:email,
                        password: password,
                        birtDate: BirthDate,
                        name: Name,
                        gender: Gender);
                if (res.IsSuccess)
                {
                    await NavigationService.NavigateAsync(nameof(SellectDifficultView));
                }
                else
                {
                    switch (res.AuthErrorReason)
                    {
                        case Firebase.Auth.AuthErrorReason.InvalidEmailAddress:
                            await App.Current.MainPage.DisplayAlert(AppSettings.AppName, 
                                ErrorSettings.RegisterErrorMessage_InvalidEmailAddress, AppSettings.OK);
                            break;
                        case Firebase.Auth.AuthErrorReason.WeakPassword:
                            await App.Current.MainPage.DisplayAlert(AppSettings.AppName,
                                ErrorSettings.RegisterErrorMessage_WeakPassword, AppSettings.OK);
                            break;
                        case Firebase.Auth.AuthErrorReason.EmailExists:
                            await App.Current.MainPage.DisplayAlert(AppSettings.AppName,
                                ErrorSettings.RegisterErrorMessage_EmailExist, AppSettings.OK);
                            break;
                        case Firebase.Auth.AuthErrorReason.TooManyAttemptsTryLater:
                            await App.Current.MainPage.DisplayAlert(AppSettings.AppName,
                                ErrorSettings.RegisterErrorMessage_TooManyAttempts, AppSettings.OK);
                            break;
                        default:
                            await App.Current.MainPage.DisplayAlert(AppSettings.AppName, 
                                ErrorSettings.RegisterErrorMessage, AppSettings.OK);
                            break;
                    }
                }
            IsBusy = false;
        }

        #endregion

    }
}
