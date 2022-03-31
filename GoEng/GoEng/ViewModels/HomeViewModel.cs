using GoEng.Enums;
using GoEng.Models.Home;
using GoEng.Services.Home;
using MvvmHelpers.Commands;
using Prism.Navigation;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GoEng.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {
        private readonly IHomeService _homeService;
        public HomeViewModel(
            INavigationService navigationService,
            IHomeService homeService)
            : base(navigationService)
        {
            _homeService = homeService;
        }

        #region Public Properties

        private ObservableCollection<HomeBindableModel> _collection;
        public ObservableCollection<HomeBindableModel> Collection
        {
            get => _collection;
            set => SetProperty(ref _collection, value);
        }

        public ICommand TapCommand => new AsyncCommand<HomeBindableModel>(OnTapCommand);

        #endregion

        #region Overrides

        public async override void Initialize(INavigationParameters parameters)
        {
            base.Initialize(parameters);

            IsBusy = true;
            var res = await _homeService.GetHomeModels();
            Collection = new ObservableCollection<HomeBindableModel>(res);
            IsBusy = false;
        }

        #endregion

        private async Task OnTapCommand(HomeBindableModel model)
        {
            if (!model.IsBlocked)
            {

            }
        }
    }
}
