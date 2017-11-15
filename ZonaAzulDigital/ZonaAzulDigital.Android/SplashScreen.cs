using Android.App;
using Android.Content.PM;
using MvvmCross.Droid.Views;
using ZonaAzulDigital.Droid.Views;

namespace ZonaAzulDigital.Droid
{
    [Activity(
        Label = "ZonaAzulDigital.Droid"
        , MainLauncher = true
        , Icon = "@drawable/icon"
        , Theme = "@style/Theme.Splash"
        , NoHistory = true
        , ScreenOrientation = ScreenOrientation.Portrait)]
    public class SplashScreen : MvxSplashScreenActivity
    {
        public SplashScreen()
            : base(Resource.Layout.SplashScreen)
        {
            //System.Threading.Thread.Sleep(1000);
            //StartActivity(typeof(MainView));
        }
        
    }
}
