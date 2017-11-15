using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;
using ZonaAzulDigital.Core.Models;
using ZonaAzulDigital.Core.Services;

namespace ZonaAzulDigital.Core.ViewModels
{
    public partial class CadastroClienteViewModel : MvxViewModel
    {
        //Corrigir, código com erro

        DataService dataService;
        List<Cliente> cliente;

        public CadastroClienteViewModel()
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
        
        public IMvxCommand CadastroCommand => new MvxCommand(CadastroAsync);
        private async void CadastroAsync()
        {            
            if (Valida())
            {
                            
                Cliente novocliente = new Cliente
                {
                    CPF = txtCPF,
                    Nome = txtNome,
                    Email = txtEmail,                    
                    Telefone = txtTelefone,
                    Senha = txtSenha,
                };

                if (ValidaCPF(novocliente)) //verifica se os CPF já existe no banco
                {
                    try
                    {
                        await dataService.AddClienteAsync(novocliente);
                        AtualizaDados();
                        LimparCliente();
                        ShowViewModel<MainViewModel>();
                    }
                        //exception não funcionando corrigir aparte do alertdialogo.
                    catch (Exception ex)
                    {
                        //await alertDialog("Erro", ex.Message, "OK");
                    }
                }
                else
                {
                    //Message(message: "CPF já cadastrado.");
                    //await Application.Current.MainPage.DisplayAlert("ERRO", "CPF já cadastrado.", "OK");
                    
                    LimparCliente();
                }
            }                
            else
            {
                //await alertDialog("Erro", "Dados Invalidos", "OK");
            }
        }

        private void LimparCliente()
        {
            txtCPF = "";
            txtNome = "";
            txtEmail = "";
            txtTelefone = "";
            txtSenha = "";
        }

        private bool Valida()
        {
            if (string.IsNullOrEmpty(txtCPF) && string.IsNullOrEmpty(txtNome) && string.IsNullOrEmpty(txtEmail) && string.IsNullOrEmpty(txtTelefone) && string.IsNullOrEmpty(txtSenha))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private bool ValidaCPF(Cliente c)
        {
            foreach (Cliente client in cliente)
            {
                if (c.CPF == client.CPF)                
                    return false;                
            }
            return true;
        }
        private void Message(string message)
        {
            
        }

        /*private Task alertDialog(string v1, string message, string v2)
        {
            throw new NotImplementedException();
        }*/
        #region Propriedades

        private string _cpf;
        private string _nome;
        private string _email;          
        private string _telefone;
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
 
               
        public string txtTelefone
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