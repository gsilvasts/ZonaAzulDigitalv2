using System.Threading.Tasks;
using MvvmCross.Core.ViewModels;
using Xamarin.Forms;
using System;
using ZonaAzulDigital.Core.Services;
using ZonaAzulDigital.Core.Models;
using System.Collections.Generic;
using Android.Content.Res;
using ZonaAzulDigital.Core.Provider.DialogProvider;
using MvvmCross.Platform;

namespace ZonaAzulDigital.Core.ViewModels
{
    public class MainViewModel : MvxViewModel
    {
        private DataService dataService = new DataService();
        List<Cliente> cliente;
        protected IDialogProvider _dialogProvider;

        public MainViewModel()
        {
            Initialize();
            dataService = new DataService();
            AtualizaDados();
            _dialogProvider = Mvx.Resolve<IDialogProvider>();
        }
        
        async void AtualizaDados()
        {
            cliente = await dataService.GetClienteAsync(); //
        }        

        public override Task Initialize()
        {
            return base.Initialize();
        }

        public IMvxCommand LoginTextCommand => new MvxCommand(LoginAsync);        
        private void LoginAsync()
        {
            LoginRequest login = new LoginRequest
            {
                CPF = txtCPF,
                Senha = txtSenha
            };
            if (Autentica(login))
            {
                ShowViewModel<HomeViewModel>(new { CPF = login.CPF });
            }
            else
            {
                
                _dialogProvider.ShowMessage("ERRO","CPF e/ou Senha inválidos, digite novamente.", "OK", () => { });
                LimparLogin();
            }
        }

        private void LimparLogin()
        {
            txtCPF = "";
        }

        private bool Autentica(LoginRequest login)
        {
            if (login.CPF == "1") return true; //para testes
            foreach (Cliente c in cliente)
            {
                if ((c.CPF == login.CPF) && (c.Senha == login.Senha)) return true;
            }
            return false;
        }

        public IMvxCommand CadastroTextCommand => new MvxCommand(CadastroReturn);
        private void CadastroReturn()
        {

            ShowViewModel<CadastroClienteViewModel>();
        }
        
        
        
        #region Propriedades

        private string _cpf;    
        private string _senha;

        public string txtCPF
        {
            get
            {
               return _cpf;              
            }
            set
            {
                _cpf = value;
                RaisePropertyChanged(() => txtCPF);
            }
        }
        public string txtSenha
        {
            get
            {
                return _senha;
            }
            set
            {
                _senha = value;
                RaisePropertyChanged(() => txtSenha);
            }
        }

        #endregion

    }

}