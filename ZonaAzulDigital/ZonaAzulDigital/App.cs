using MvvmCross.Platform.IoC;
using ZonaAzulDigital.Core.ViewModels;
using Xamarin.Forms;

namespace ZonaAzulDigital.Core
{
    public class App : MvvmCross.Core.ViewModels.MvxApplication
    {
        public override void Initialize()
        {
            CreatableTypes()
                .EndingWith("Service")
                .AsInterfaces()
                .RegisterAsLazySingleton();
        
            RegisterAppStart<MainViewModel>();
        }
    }
}
