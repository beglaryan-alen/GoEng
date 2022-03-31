using GoEng.Settings;
using Prism.Navigation;

namespace GoEng.ViewModels.Popups
{
    public class LoadingPopupViewModel : BaseViewModel
    {

        public LoadingPopupViewModel(
            INavigationService navigationService)
            : base(navigationService)
        {
        }

        #region Public Proeprties

        private string _loadingText;
        public string LoadingText
        {
            get => _loadingText;
            set => SetProperty(ref _loadingText, value);
        }

        #endregion

        #region Overrides

        public override void Initialize(INavigationParameters parameters)
        {
            base.Initialize(parameters);

            LoadingText = AppSettings.LoadingText;
        }

        #endregion
    }
}
