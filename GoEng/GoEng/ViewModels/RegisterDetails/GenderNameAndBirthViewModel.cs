using GoEng.Enums.User;
using GoEng.Services.AccountService;
using GoEng.Services.Auth;
using GoEng.Settings;
using GoEng.Views.RegisterDetails;
using MvvmHelpers.Commands;
using Prism.Navigation;
using System;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace GoEng.ViewModels.RegisterDetails
{
    public class GenderNameAndBirthViewModel : BaseViewModel
    {
        private readonly IAccountService _accountService;
        private string email;
        private string password;
        public GenderNameAndBirthViewModel(
            INavigationService navigationService,
            IAccountService accountService)
            : base(navigationService)
        {
            _accountService = accountService;
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

        public ICommand GirlCommand => new Xamarin.Forms.Command(() => Gender = EGender.Female);
        public ICommand BoyCommand => new Xamarin.Forms.Command(() => Gender = EGender.Male);
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

            var res = await _accountService.CreateUserAsync(Name, email, BirthDate, Gender, password);

            if (res.IsSuccessful)
            {
                await NavigationService.NavigateAsync($"/{nameof(NavigationPage)}/{nameof(SellectDifficultView)}");
                await App.Current.MainPage.DisplayAlert(AppSettings.AppName,
                    AppSettings.Register_Congratulations, AppSettings.OK);
            }
            else if(res.ErrorType == Enums.Firebase.EFirebaseExcType.InvalidEmail)
                await App.Current.MainPage.DisplayAlert(AppSettings.AppName, 
                    ErrorSettings.RegisterErrorMessage_InvalidEmailAddress, AppSettings.OK);
            else if (res.ErrorType == Enums.Firebase.EFirebaseExcType.InvalidPassword)
                await App.Current.MainPage.DisplayAlert(AppSettings.AppName,
                    ErrorSettings.RegisterErrorMessage_InvalidPassword, AppSettings.OK);
            else
                await App.Current.MainPage.DisplayAlert(AppSettings.AppName,
                        ErrorSettings.RegisterErrorMessage, AppSettings.OK);

            IsBusy = false;
        }

        #endregion

    }
}
