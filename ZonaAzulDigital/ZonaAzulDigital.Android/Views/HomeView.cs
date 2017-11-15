using Android.App;
using Android.OS;
using MvvmCross.Droid.Views;
using ZonaAzulDigital.Core.ViewModels;



namespace ZonaAzulDigital.Droid.Views
{

    [Activity]
    public class HomeView : MvxActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            RequestWindowFeature(Android.Views.WindowFeatures.NoTitle);
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.HomeView);
        }
    }
        
}