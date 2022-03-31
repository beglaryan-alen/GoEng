using FFImageLoading.Forms.Platform;
using Foundation;
using Rg.Plugins.Popup;
using UIKit;
using Xamarin.Forms;

namespace GoEng.iOS
{
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        #region Overrides

        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            InitializePackages();
            LoadApplication(new App(new IOSInitializer()));

            return base.FinishedLaunching(app, options);
        }



        #endregion

        #region Private Helpers

        private void InitializePackages()
        {
            Forms.Init();
            CachedImageRenderer.Init();
            FormsMaterial.Init();
            Popup.Init();
        }

        #endregion

    }
}


