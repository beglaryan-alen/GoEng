using GoEng.Services.AccountService;
using GoEng.Services.Auth;
using GoEng.Services.Cache;
using GoEng.Services.DefaultRepository;
using GoEng.Services.Game;
using GoEng.Services.Language;
using GoEng.Services.Mapper;
using GoEng.Settings;
using GoEng.ViewModels;
using GoEng.ViewModels.Home;
using GoEng.ViewModels.Home.GameVariantDetails;
using GoEng.ViewModels.Popups;
using GoEng.ViewModels.Popups.PagesPopup;
using GoEng.ViewModels.Profile;
using GoEng.ViewModels.RegisterDetails;
using GoEng.Views;
using GoEng.Views.Home;
using GoEng.Views.Home.GameVariantDetails;
using GoEng.Views.Popups;
using GoEng.Views.Popups.PagesPopup;
using GoEng.Views.Profile;
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

            SetAppCenter();

            SetStartPage();

        }

        private async void SetAppCenter()
        {
            AppCenter.Start("android=d5c2ba03-71a6-46f5-8ce3-a06283f71839;" +
                  "uwp={Your UWP App secret here};" +
                  "ios={Your iOS App secret here};" +
                  "macos={Your macOS App secret here};",
                  typeof(Analytics), typeof(Crashes));
        }

        private async void SetStartPage()
        {
            IAccountService accountService = Resolve<IAccountService>();
            var res = await accountService.LoginSilentAsync();
            if (res)
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
            containerRegistry.Register<ILanguage, Language>();
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
            containerRegistry.RegisterForNavigation<HomeDetailsView, HomeDetailsViewModel>();
            containerRegistry.RegisterForNavigation<ProfileView, ProfileViewModel>();
            containerRegistry.RegisterForNavigation<GameVariantView, GameVariantViewModel>();
            containerRegistry.RegisterForNavigation<AnimalTabView, AnimalTabViewModel>();
            containerRegistry.RegisterForNavigation<QuestionTabView, QuestionTabViewModel>();

            //popups
            containerRegistry.RegisterForNavigation<LoadingPopupView, LoadingPopupViewModel>();
            containerRegistry.RegisterForNavigation<TicketPopupView, TicketPopupViewModel>();
            containerRegistry.RegisterForNavigation<ActiveDaysPopupView, ActiveDaysPopupViewModel>();
        }
    }
}
