using GoEng.Settings;
using Prism.Navigation;

namespace GoEng.ViewModels.Popups.PagesPopup
{
    public class TicketPopupViewModel : BasePopupViewModel
    {
        public TicketPopupViewModel(
            INavigationService navigationService)
            : base(navigationService)
        {
        }

        #region Public Properties

        private string _copyText;
        public string CopyText
        {
            get => _copyText;
            set => SetProperty(ref _copyText, value);
        }

        private string _shareText;
        public string ShareText
        {
            get => _shareText;
            set => SetProperty(ref _shareText, value);
        }

        #endregion

        #region Overrides

        public override void Initialize(INavigationParameters parameters)
        {
            base.Initialize(parameters);

            Title = AppSettings.Ticket_Title;
            CopyText = AppSettings.Ticket_CopyText;
            ShareText = AppSettings.Ticket_ShareText;
        }

        #endregion
    }
}
