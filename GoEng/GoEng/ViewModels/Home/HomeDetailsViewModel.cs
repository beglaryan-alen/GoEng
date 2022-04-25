using GoEng.Enums.Game;
using GoEng.Enums.Language;
using GoEng.Models.GameVariant;
using GoEng.Services.AccountService;
using GoEng.Services.DefaultRepository;
using GoEng.Services.Language;
using GoEng.Views.Home;
using MvvmHelpers.Commands;
using Prism.Navigation;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GoEng.ViewModels.Home
{
    public class HomeDetailsViewModel : BaseViewModel
    {
        private readonly IDefaultRepository _defaultRepository;
        private readonly IAccountService _accountService;
        private readonly ILanguage _language;
        private INavigationParameters _navigationParameters;

        public HomeDetailsViewModel(
            INavigationService navigationService,
            IDefaultRepository defaultRepository,
            IAccountService accountService,
            ILanguage language) 
            : base(navigationService)
        {
            _defaultRepository = defaultRepository;
            _accountService = accountService;
            _language = language;
        }

        #region Public Properties

        private ObservableCollection<GameVariantBindableModel> _collection;
        public ObservableCollection<GameVariantBindableModel> Collection
        {
            get => _collection;
            set => SetProperty(ref _collection, value);
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

        private string _title;
        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }

        public ICommand TapCommand => new AsyncCommand<GameVariantBindableModel>(OnTapCommand);

        #endregion

        #region Overrides

        public override async void Initialize(INavigationParameters parameters)
        {
            base.Initialize(parameters);

            EGame game = (EGame)parameters["game"];
            EGameVariant gameVariant = (EGameVariant)parameters["gameVariant"];
            _navigationParameters = parameters;
            CurrentGameVariant = (int)gameVariant;
            GameVariantsCount = _defaultRepository.GetGameVariantsCount(game);
            Title = _language.GetGameName(ELanguage.Eng, game);

            var res = _defaultRepository.GetGameVariants(gameVariant, game);
            Collection = new ObservableCollection<GameVariantBindableModel>(res);
        }

        #endregion

        #region Private Helpers

        private async Task OnTapCommand(GameVariantBindableModel gameVariant)
        {
            _navigationParameters.Add("gameVariantsCount", GameVariantsCount);
            _navigationParameters.Add("currentGameVariant", CurrentGameVariant);
            await NavigationService.NavigateAsync(nameof(GameVariantView));
        }

        #endregion
    }
}
