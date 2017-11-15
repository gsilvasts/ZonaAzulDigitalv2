using System.Threading.Tasks;
using MvvmCross.Core.ViewModels;
using Xamarin.Forms;
using System;
using ZonaAzulDigital.Core.Services;
using ZonaAzulDigital.Core.Models;
using System.Collections.Generic;
using Android.Content.Res;

namespace ZonaAzulDigital.Core.ViewModels
{
    public class MainViewModel : MvxViewModel
    {
        private DataService dataService = new DataService();
        List<Cliente> cliente;

        public MainViewModel()
        {
            Initialize();
            dataService = new DataService();
            AtualizaDados();
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
                ShowViewModel<HomeViewModel>();
            }
            else
            {
                //Mensagem de Texto Popup a implementar;
                LimparLogin();
            }
        }

        private void LimparLogin()
        {
            txtCPF = "";
            txtSenha = "";
        }

        private bool Autentica(LoginRequest login)
        {
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