using GoEng.Enums.Game;
using GoEng.Models.GameVariant;
using GoEng.Models.User;
using GoEng.Services.AccountService;
using GoEng.ViewModels.Home.GameVariantDetails;
using Prism.Navigation;
using System.Collections.ObjectModel;

namespace GoEng.ViewModels.Home
{
    public class GameVariantViewModel : BaseViewModel
    {
        private readonly IAccountService _accountService;
        private EGame _game;
        private EGameVariant _gameVariant;
        public GameVariantViewModel(
            INavigationService navigationService,
            IAccountService accountService) 
            : base(navigationService)
        {
            _accountService = accountService;
        }

        #region Public Properties

        private int _coins;
        public int Coins
        {
            get => _coins;
            set => SetProperty(ref _coins, value);
        }

        private int _currentGameVariant;
        public int CurrentGameVariant
        {
            get => _currentGameVariant;
            set => SetProperty(ref _currentGameVariant, value);
        }

        private int _gameVariantsCount;
        public int GameVariantsCount
        {
            get => _gameVariantsCount;
            set => SetProperty(ref _gameVariantsCount, value);
        }

        private ObservableCollection<GameVariantTabViewModel> _tabItems;
        public ObservableCollection<GameVariantTabViewModel> TabItems
        {
            get => _tabItems;
            set => SetProperty(ref _tabItems, value);
        }

        #endregion

        #region Overrides

        public override async void Initialize(INavigationParameters parameters)
        {
            base.Initialize(parameters);

            IsBusy = true;

            var res =  await _accountService.GetUserAsync();
            var user = res.Content as UserBindableModel;
            Coins = user.Coins;

            CurrentGameVariant = (int)parameters["currentGameVariant"];
            GameVariantsCount = (int)parameters["gameVariantsCount"];
            _game = (EGame)parameters["game"];
            _gameVariant = (EGameVariant)parameters["game"];

            IsBusy = false;
        }

        #endregion
    }
}
