using GoEng.Views;
using MvvmHelpers.Commands;
using Prism.Navigation;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace GoEng.ViewModels.RegisterDetails
{
    public class VideoViewModel : BaseViewModel
    {
        public VideoViewModel(
                    INavigationService navigationService)
                    : base(navigationService)
        {
        }

        public ICommand NextCommand => new AsyncCommand(OnNextCommandAsync);

        private async Task OnNextCommandAsync()
        {
            await NavigationService.NavigateAsync($"/{nameof(NavigationPage)}/{nameof(HomeView)}");
        }
    }
}
