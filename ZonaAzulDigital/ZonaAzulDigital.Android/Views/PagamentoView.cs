using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Views;
using Android.Widget;
using MvvmCross.Droid.Views;
using System;

namespace ZonaAzulDigital.Droid.Views
{
    [Activity]
    public class PagamentoView : MvxActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            RequestWindowFeature(WindowFeatures.NoTitle);
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.PagamentoView);            
        }       
    }
   
}
