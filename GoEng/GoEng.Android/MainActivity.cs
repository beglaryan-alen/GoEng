using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using FFImageLoading.Forms.Platform;
using Firebase;
using Firebase.Firestore;
using GoEng.Settings;
using Xamarin.Forms;

namespace GoEng.Droid
{
    [Activity(Label = "GoEng", Icon = "@mipmap/ic_launcher", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        #region Overrides

        public static FirebaseFirestore firebase;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            InitializePackages(savedInstanceState);

            BuildFirestore();

            base.OnCreate(savedInstanceState);


            LoadApplication(new App(new AndroidInitializer()));
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        #endregion

        #region Firestore

        private void BuildFirestore()
        {
            var options = new Firebase.FirebaseOptions.Builder()
            .SetApplicationId("1:599292463338:android:f624f0b6f0208f6962af93")
            .SetApiKey("AIzaSyCPE0Xx8zAhvCdUqjAnOI6epFI_Hqxqwhw")
            .SetDatabaseUrl($"https://goeng-836a3-default-rtdb.europe-west1.firebasedatabase.app")
            .SetGcmSenderId("599292463338")
            .SetStorageBucket("goeng-836a3.appspot.com")
            .SetProjectId("goeng-836a3")
            .Build();

            var app = Firebase.FirebaseApp.InitializeApp(this, options, AppSettings.AppName);
            firebase =  FirebaseFirestore.GetInstance(app);
        }

        #endregion

        #region -- Private helpers --

        private void InitializePackages(Bundle savedInstanceState)
        {
            Rg.Plugins.Popup.Popup.Init(this);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            Forms.Init(this, savedInstanceState);
            FormsMaterial.Init(this, savedInstanceState);
            CachedImageRenderer.Init(enableFastRenderer: true);
            FirebaseApp.InitializeApp(this);
        }

        #endregion
    }
}