using GoEng.Services.Auth;
using GoEng.Services.Cache;
using GoEng.Services.Home;
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
using System.Threading.Tasks;
using Xamarin.Forms;

namespace GoEng
{
    public partial class App : PrismApplication
    {
        public static T Resolve<T>() => Current.Container.Resolve<T>();
        public App(IPlatformInitializer platformInitializer) : base(platformInitializer) { }

        protected async override void OnInitialized()
        {
            InitializeComponent();

            Barrel.ApplicationId = AppSettings.AppName;

            await SetStartPage();

        }

        private async Task SetStartPage()
        {
            IAuth auth = Resolve<IAuth>();
            var res = await auth.SignInSilent();
            if (res)
            {
                await NavigationService.NavigateAsync($"/{nameof(NavigationPage)}/{nameof(HomeView)}");
            }
            else
            {
                await NavigationService.NavigateAsync($"/{nameof(NavigationPage)}/{nameof(WelcomeView)}");
            }
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            //packages
            containerRegistry.RegisterPopupNavigationService();

            //services
            containerRegistry.RegisterScoped<IMapperService, MapperService>();
            containerRegistry.RegisterScoped<ICacheService, CacheService>();
            containerRegistry.RegisterScoped<IHomeService, HomeService>();
            containerRegistry.RegisterScoped<IAuth, Auth>();

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
