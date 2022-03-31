using GoEng.Views.Popups;
using Prism.AppModel;
using Prism.Mvvm;
using Prism.Navigation;

namespace GoEng.ViewModels
{
    public class BaseViewModel : BindableBase, IInitialize, IPageLifecycleAware
    {

        protected INavigationService NavigationService { get; }
        
        public BaseViewModel(INavigationService navigationService)
        {
            NavigationService = navigationService;
        }

        private bool _isBusy;
        public bool IsBusy
        {
            get => _isBusy;
            set
            {
                if (_isBusy != value)
                {
                    SetProperty(ref _isBusy, value);
                    SetLoadingPage();
                }
            }
        }

        private async void SetLoadingPage()
        {
            if (IsBusy)
            {
                await NavigationService.NavigateAsync(nameof(LoadingPopupView));
            }
            else
            {
                await NavigationService.ClearPopupStackAsync();
            }
        }

        #region -- Iinitialize implementation --

        public virtual void Initialize(INavigationParameters parameters)
        {
        }

        public virtual void OnAppearing()
        {
        }

        public virtual void OnDisappearing()
        {
        }

        #endregion
    }
}