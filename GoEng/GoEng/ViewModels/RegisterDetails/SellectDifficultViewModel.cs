using GoEng.Views.RegisterDetails;
using MvvmHelpers.Commands;
using Prism.Navigation;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GoEng.ViewModels.RegisterDetails
{
    public class SellectDifficultViewModel : BaseViewModel
    {
        public SellectDifficultViewModel(
                    INavigationService navigationService)
                    : base(navigationService)
        {
        }

        #region Commands

        public ICommand ButtonCommand => new AsyncCommand<string>(OnButtonCommandAsync);

        #endregion

        #region Commands Implementations

        private async Task OnButtonCommandAsync(string difficult)
        {
            await NavigationService.NavigateAsync(nameof(VideoView));
        }

        #endregion
    }
}
