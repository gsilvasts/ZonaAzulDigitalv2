using MvvmCross.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZonaAzulDigital.Core.Models;
using ZonaAzulDigital.Core.Services;
using Xamarin.Forms;

namespace ZonaAzulDigital.Core.ViewModels
{
    public class CadastroClienteViewModel : MvxViewModel
    {
        DataService dataService;
       
        public CadastroClienteViewModel()
        {
            //InitializeComponent();
            //dataService = new DataService();
            //AtualizaDados();
        }
        //async void AtualizaDados()
        //{
        //    await dataService.AddClienteAsync(cliente);
        //}

        public override Task Initialize()
        {
            return base.Initialize();
        }

        public IMvxCommand CadastroCommand => new MvxCommand(CadastroAsync);
        private async void CadastroAsync()
        {
            if (txtCPF != 0)
            {

                Cliente cliente = new Cliente
                {
                    Login = txtLogin,
                    Nome = txtNome,
                    CPF = txtCPF,
                    RG = txtRG,
                    Email = txtEmail,
                    Telefone = txtTelefone,
                    Senha = txtSenha,
                };

                try
                {
                    await dataService.AddClienteAsync(cliente);
                  
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            else
            {

            }
        }


        #region Propriedades
        private string _login;
        private string _nome;
        private int _cpf;
        private int _rg;
        private string _email;
        private int _telefone;
        private string _senha;

        public string txtLogin
        {
            get
            {
                return _login;
            }
            set
            {
                _login = value;
                RaisePropertyChanged(() => txtLogin);
            }
        }

        public string txtNome
        {
            get
            {
                return _nome;
            }
            set
            {
                _nome = value;
                RaisePropertyChanged(() => txtNome);
            }
        }
        public int txtCPF
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

        public int txtRG
        {
            get
            {
                return _rg;
            }
            set
            {
                _rg = value;
                RaisePropertyChanged(() => txtRG);
            }
        }
        public string txtEmail
        {
            get
            {
                return _email;
            }
            set
            {
                _email = value;
                RaisePropertyChanged(() => txtEmail);
            }
        }

        public int txtTelefone
        {
            get
            {
                return _telefone;
            }
            set
            {
                _telefone = value;
                RaisePropertyChanged(() => txtTelefone);
            }
        }

        public string txtSenha
        {
            get { return _senha; }
            set { _senha = value; RaisePropertyChanged(() => txtSenha); }
        }

        #endregion

    }
}