using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Views;
using MvvmCross.Droid.Views;
using Xamarin.Forms;

namespace ZonaAzulDigital.Droid.Views
{
    [Activity(Label = "View for MainViewModel", MainLauncher =false , ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainView : MvxActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            RequestWindowFeature(WindowFeatures.NoTitle);
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.MainView);   
        }
        public void MessageBox_Show(string message)
        {
            AlertDialog.Builder alert = new AlertDialog.Builder(this);
            alert.SetTitle("ERRO");
            alert.SetMessage(message);
            alert.SetPositiveButton("OK", (senderAlert, args) => {
               });           
            Dialog dialog = alert.Create();
            dialog.Show();
        }
 
    }
   
}
