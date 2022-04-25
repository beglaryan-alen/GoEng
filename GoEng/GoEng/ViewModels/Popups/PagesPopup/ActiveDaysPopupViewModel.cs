using GoEng.Settings;
using Prism.Navigation;

namespace GoEng.ViewModels.Popups.PagesPopup
{
    public class ActiveDaysPopupViewModel : BasePopupViewModel
    {
        public ActiveDaysPopupViewModel(
            INavigationService navigationService) 
            : base(navigationService)
        {
        }

        private string _description;
        public string Description
        {
            get => _description;
            set => SetProperty(ref _description, value);
        }

        public override void Initialize(INavigationParameters parameters)
        {
            base.Initialize(parameters);

            int days = (int)parameters["activeDays"];
            Title = $"Դուք ակտիվ եք {days} օր";
            Description = AppSettings.ActiveDays_Description;
        }
    }
}
