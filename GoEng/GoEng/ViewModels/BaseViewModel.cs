using GoEng.Enums.NavBar;
using GoEng.Models.NavBar;
using GoEng.Views.Popups;
using GoEng.Views.Popups.PagesPopup;
using MvvmHelpers.Commands;
using Prism.AppModel;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GoEng.ViewModels
{
    public class BaseViewModel : BindableBase, IInitialize, IPageLifecycleAware
    {

        protected INavigationService NavigationService { get; }
        
        public BaseViewModel(
            INavigationService navigationService)
        {
            NavigationService = navigationService;
        }

        #region Public Properties

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

        

        public ICommand GoBackCommand => new AsyncCommand(async() => await NavigationService.GoBackAsync());

        #endregion

        #region Iinitialize implementation

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

        #region Private Helpers

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

        

        #endregion
    }
}