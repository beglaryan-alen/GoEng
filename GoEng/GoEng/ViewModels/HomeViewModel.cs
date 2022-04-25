using GoEng.Enums.NavBar;
using GoEng.Models.Game;
using GoEng.Models.NavBar;
using GoEng.Models.User;
using GoEng.Services.AccountService;
using GoEng.Settings;
using GoEng.Views.Home;
using GoEng.Views.Popups.PagesPopup;
using GoEng.Views.Profile;
using MvvmHelpers.Commands;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GoEng.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {
        private readonly IAccountService _accountService;
        public HomeViewModel(
            INavigationService navigationService,
            IAccountService accountService)
            : base(navigationService)
        {
            _accountService = accountService;
        }

        #region Public Properties

        private ObservableCollection<GameBindableModel> _collection;
        public ObservableCollection<GameBindableModel> Collection
        {
            get => _collection;
            set => SetProperty(ref _collection, value);
        }

        private ObservableCollection<NavBarItemBindableModel> _navBarItems;
        public ObservableCollection<NavBarItemBindableModel> NavBarItems
        {
            get => _navBarItems;
            set => SetProperty(ref _navBarItems, value);
        }

        private bool _isEmailVerified;
        public bool IsEmailVerified
        {
            get => _isEmailVerified;
            set => SetProperty(ref _isEmailVerified, value);
        }

        private int _coins;
        public int Coins
        {
            get => _coins;
            set => SetProperty(ref _coins, value);
        }

        private int _activeDays;
        public int ActiveDays
        {
            get => _activeDays;
            set => SetProperty(ref _activeDays, value);
        }

        public ICommand TapCommand => new AsyncCommand<GameBindableModel>(OnTapCommand);
        public ICommand VerifyEmailCommand => new AsyncCommand<GameBindableModel>(OnVerifyEmailCommand);

        #endregion

        #region Overrides

        public async override void Initialize(INavigationParameters parameters)
        {
            base.Initialize(parameters);

            IsBusy = true;

            var res = await _accountService.GetUserGames();
            var collection = res.Content as List<GameBindableModel>;
            Collection = new ObservableCollection<GameBindableModel>(collection);

            IsEmailVerified = await _accountService.IsUserEmailVerified();

            var userRes = await _accountService.GetUserAsync();
            var user = userRes.Content as UserBindableModel;
            Coins = user.Coins;
            ActiveDays = user.ActiveDays;

            string icon = "";
            if (user.Gender == Enums.User.EGender.Male)
                icon = "boy";
            else
                icon = "girl";

            INavigationParameters ticketParams = new NavigationParameters();
            INavigationParameters activeDaysParams = new NavigationParameters();
            activeDaysParams.Add("activeDays", ActiveDays);
            INavigationParameters profileParams = new NavigationParameters();
            profileParams.Add("user", user);

            NavBarItems = new ObservableCollection<NavBarItemBindableModel>
            {
                new NavBarItemBindableModel()
                {
                    Content = user.Coins.ToString(),
                    Icon = "ticket",
                    IsContentVisible = true,
                    TapCommand = new AsyncCommand(() => OnNavBarTapCommand(ENavBar.Ticket, ticketParams)),
                },
                new NavBarItemBindableModel()
                {
                    Content = user.ActiveDays.ToString(),
                    Icon = "active_day",
                    IsContentVisible = true,
                    TapCommand = new AsyncCommand(() => OnNavBarTapCommand(ENavBar.ActiveDay, activeDaysParams))
                },
                new NavBarItemBindableModel()
                {
                    Icon = icon,
                    TapCommand = new AsyncCommand(() => OnNavBarTapCommand(ENavBar.Profile, profileParams))
                },
            };

            IsBusy = false;
        }

        #endregion

        #region Private Helpers

        private async Task OnTapCommand(GameBindableModel game)
        {
            INavigationParameters par = new NavigationParameters();
            par.Add("game", game.Game);
            par.Add("gameVariant", game.GameVariant);
            await NavigationService.NavigateAsync(nameof(HomeDetailsView), par);
        }

        private async Task OnVerifyEmailCommand(GameBindableModel arg)
        {

            IsEmailVerified = await _accountService.RecheckEmailVerify();
            if (IsEmailVerified)
                await App.Current.MainPage.DisplayAlert(AppSettings.AppName,
                    AppSettings.Email_Virificated, AppSettings.OK);
            else
                await App.Current.MainPage.DisplayAlert(AppSettings.AppName,
                    AppSettings.Email_EmailSend, AppSettings.OK);
        }

        private Task OnNavBarTapCommand(ENavBar nav, INavigationParameters navParams) =>
            nav switch
            {
                ENavBar.Ticket => NavigationService.NavigateAsync(nameof(TicketPopupView), navParams),
                ENavBar.ActiveDay => NavigationService.NavigateAsync(nameof(ActiveDaysPopupView), navParams),
                ENavBar.Profile => NavigationService.NavigateAsync(nameof(ProfileView), navParams),
                _ => throw new NotImplementedException(),
            };

        #endregion
    }
}
