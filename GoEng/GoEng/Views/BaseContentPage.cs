using Xamarin.Forms;

namespace GoEng.Views
{
    public class BaseContentPage : ContentPage
    {
        public BaseContentPage()
        {
            //On<Xamarin.Forms.PlatformConfiguration.iOS>().SetUseSafeArea(true);

            Xamarin.Forms.NavigationPage.SetHasNavigationBar(this, false);

        }
    }
}
