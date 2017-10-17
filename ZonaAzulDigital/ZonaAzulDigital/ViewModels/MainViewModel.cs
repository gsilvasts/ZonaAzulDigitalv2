using System.Threading.Tasks;
using MvvmCross.Core.ViewModels;
using Xamarin.Forms;


namespace ZonaAzulDigital.Core.ViewModels
{
    public class MainViewModel : MvxViewModel
    {
        public MainViewModel()
        {
        }
        
        public override Task Initialize()
        {
            //TODO: Add starting logic here
		    
            return base.Initialize();
        }
        
        public IMvxCommand LoginTextCommand => new MvxCommand(LoginText);
        private void LoginText()
        {
            Text = "Hello MvvmCross";
        }

        private string _text = "Hello MvvmCross";
        public string Text
        {
            get { return _text; }
            set { SetProperty(ref _text, value); }
        }

        public IMvxCommand CadastroTextCommand => new MvxCommand(CadastroReturn);
        private void CadastroReturn()
        {
            ShowViewModel<CadastroClienteViewModel>();
        }
    }
    
}