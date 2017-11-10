using Android.OS;
using Android.Runtime;
using Android.Views;
using ZonaAzulDigital.Core.ViewModels;
using MvvmCross.Droid.Views.Fragments;
using MvvmCross.Droid.Views.Attributes;

namespace ZonaAzulDigital.Droid.Views
{
    [MvxFragmentPresentation(typeof(HomeViewModel), Resource.Id.frameLayout)]    
    [Register("ZonaAzulDigital.Droid.Views.MySettingsFragment")]
    public class MySettingsFragment : MvxFragment<MySettingsViewModel>
       
    {
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            return inflater.Inflate(Resource.Layout.MySettingsView, container, false);
        }
    }
}