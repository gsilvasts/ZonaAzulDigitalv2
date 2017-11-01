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
        //List<Cliente> cliente;

        //public MainViewModel()
        //{
        //    Initialize();
        //    dataService = new DataService();
        //    AtualizaDados();
        //}
        //async void AtualizaDados()
        //{
        //    cliente = await dataService.GetClienteAsync();
        //}

        //public override Task Initialize()
        //{
        //    //TODO: Add starting logic here

        //    return base.Initialize();
        //}

        public MainViewModel()
        {
            Initialize();
        }

        public override Task Initialize()
        {
            return base.Initialize();
        }

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
            get { return _senha;  }
            set { _senha = value; RaisePropertyChanged(() => txtSenha); }
        }

        public IMvxCommand LoginTextCommand
        {
            
            
            get
            {
                return new MvxCommand(async () =>
                {

                    await dataService.LoginAsync(txtCPF, txtSenha);
                });
            }
        }



        public IMvxCommand CadastroTextCommand => new MvxCommand(CadastroReturn);
        private void CadastroReturn()
        {
            
            ShowViewModel<CadastroClienteViewModel>();        
        }
    }
    
}