using GoEng.Models.Game;
using GoEng.Services.AccountService;
using GoEng.Services.Auth;
using MvvmHelpers.Commands;
using Prism.Navigation;
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

        public ICommand TapCommand => new AsyncCommand<GameBindableModel>(OnTappCommand);

        #endregion

        #region Overrides

        public async override void Initialize(INavigationParameters parameters)
        {
            base.Initialize(parameters);
            IsBusy = true;

            var res = await _accountService.GetUserGames();
            Collection = new ObservableCollection<GameBindableModel>(res);

            IsBusy = false;
        }

        #endregion

        #region Private Helpers

        private async Task OnTappCommand(GameBindableModel arg)
        {
        }

        #endregion

    }
}
