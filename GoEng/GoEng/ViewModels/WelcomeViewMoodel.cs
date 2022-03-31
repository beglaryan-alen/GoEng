using GoEng.Views;
using MvvmHelpers.Commands;
using Prism.Navigation;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GoEng.ViewModels
{
    public class WelcomeViewMoodel : BaseViewModel
    {
        public WelcomeViewMoodel(
            INavigationService navigationService)
            : base(navigationService)
        {
        }

        #region Public Properties

        public ICommand LoginCommand => new AsyncCommand(OnLoginCommand);
        public ICommand RegisterCommand => new AsyncCommand(OnRegisterCommand);

        #endregion

        #region Private Helpers

        private async Task OnLoginCommand()
        {
            INavigationParameters parameters = new NavigationParameters();
            parameters.Add("pageIndex", 1);
            await NavigationService.NavigateAsync(nameof(SignInView), parameters);
        }

        private async Task OnRegisterCommand()
        {
            INavigationParameters parameters = new NavigationParameters();
            parameters.Add("pageIndex", 0);
            var res = await NavigationService.NavigateAsync(nameof(SignInView), parameters);
        }

        #endregion

    }
}
