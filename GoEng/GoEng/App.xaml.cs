using GoEng.Services.AccountService;
using GoEng.Services.Auth;
using GoEng.Services.Cache;
using GoEng.Services.Default;
using GoEng.Services.DefaultRepository;
using GoEng.Services.Game;
using GoEng.Services.Mapper;
using GoEng.Settings;
using GoEng.ViewModels;
using GoEng.ViewModels.Popups;
using GoEng.ViewModels.RegisterDetails;
using GoEng.Views;
using GoEng.Views.Popups;
using GoEng.Views.RegisterDetails;
using MonkeyCache.SQLite;
using Prism;
using Prism.Ioc;
using Prism.Plugin.Popups;
using Prism.Unity;
using Xamarin.Forms;

namespace GoEng
{
    public partial class App : PrismApplication
    {
        public static T Resolve<T>() => Current.Container.Resolve<T>();
        public App(IPlatformInitializer platformInitializer) : base(platformInitializer) { }

        protected override void OnInitialized()
        {
            InitializeComponent();

            Barrel.ApplicationId = AppSettings.AppName;

            SetStartPage();

        }

        private async void SetStartPage()
        {
            IAccountService accountService = Resolve<IAccountService>();
            var res = await accountService.LoginSilentAsync();
            if (res.IsSuccessful)
                await NavigationService.NavigateAsync($"/{nameof(NavigationPage)}/{nameof(HomeView)}");
            else
                await NavigationService.NavigateAsync($"/{nameof(NavigationPage)}/{nameof(WelcomeView)}");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            //packages
            containerRegistry.RegisterPopupNavigationService();

            //services
            containerRegistry.Register<IMapperService, MapperService>();
            containerRegistry.Register<ICacheService, CacheService>();
            containerRegistry.Register<IDefaultRepository, DefaultRepository>();
            containerRegistry.Register<IAccountService, AccountService>();
            containerRegistry.RegisterInstance<IAuth>(DependencyService.Get<IAuth>());
            containerRegistry.RegisterInstance<IGame>(DependencyService.Get<IGame>());

            //navigations
            containerRegistry.RegisterForNavigation<NavigationPage>(nameof(NavigationPage));
            containerRegistry.RegisterForNavigation<WelcomeView, WelcomeViewMoodel>();
            containerRegistry.RegisterForNavigation<SignInView, SignInViewModel>();
            containerRegistry.RegisterForNavigation<GenderNameAndBirthView, GenderNameAndBirthViewModel>();
            containerRegistry.RegisterForNavigation<SellectDifficultView, SellectDifficultViewModel>();
            containerRegistry.RegisterForNavigation<VideoView, VideoViewModel>();
            containerRegistry.RegisterForNavigation<HomeView, HomeViewModel>();

            //popups
            containerRegistry.RegisterForNavigation<LoadingPopupView, LoadingPopupViewModel>();
        }
    }
}
