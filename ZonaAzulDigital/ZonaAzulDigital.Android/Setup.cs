using Android.Content;
using MvvmCross.Droid.Platform;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform.Platform;
using ZonaAzulDigital.Core;
using System.Collections.Generic;
using System.Reflection;
using MvvmCross.Droid.Views;
using MvvmCross.Platform;
using ZonaAzulDigital.Core.Provider.DialogProvider;

namespace ZonaAzulDigital.Droid
{
    public class Setup : MvxAndroidSetup
    {
        public Setup(Context applicationContext) : base(applicationContext)
        {
        }

        protected override IMvxApplication CreateApp()
        {
            return new App();
        }

        protected override IMvxTrace CreateDebugTrace()
        {
            return new DebugTrace();
        }
        protected override IEnumerable<Assembly> AndroidViewAssemblies => new List<Assembly>(base.AndroidViewAssemblies)
        {
            typeof(global::Android.Support.V7.Widget.Toolbar).Assembly,
        };

        protected override void InitializeIoC()
        {
            base.InitializeIoC();
            Mvx.LazyConstructAndRegisterSingleton<IDialogProvider, DroidDialogProvider>();
        }


    }
}
