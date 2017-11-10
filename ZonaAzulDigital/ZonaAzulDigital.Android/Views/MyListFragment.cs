using Android.OS;
using Android.Runtime;
using Android.Views;
using ZonaAzulDigital.Core.ViewModels;
using MvvmCross.Droid.Views.Fragments;
using MvvmCross.Droid.Views.Attributes;

namespace ZonaAzulDigital.Droid.Views
{
    [MvxFragmentPresentation(typeof(HomeViewModel), Resource.Id.frameLayout)]
    [Register("ZonaAzulDigital.Droid.Views.MyListFragment")]
    public class MyListFragment : MvxFragment<MyListViewModel>
    {
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            return inflater.Inflate(Resource.Layout.MyListView, container, false);
        }
    }
}
