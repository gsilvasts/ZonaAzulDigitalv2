using Android.App;
using Android.OS;
using Android.Views;
using MvvmCross.Droid.Views;

namespace ZonaAzulDigital.Droid.Views
{
    [Activity(Label = "View for MainViewModel")]
    public class CadastroCliente : MvxActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            RequestWindowFeature(WindowFeatures.NoTitle);
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.CadastroCliente);
        }
    }
}