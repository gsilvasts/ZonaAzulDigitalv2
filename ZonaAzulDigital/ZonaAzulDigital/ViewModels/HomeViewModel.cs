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
    public class HomeViewModel : MvxViewModel
    {
        private DataService dataService = new DataService();
        List<Cliente> cliente;

        
        public void Init(string CPF)
        {
            Cpf = CPF;
        }
        public HomeViewModel()
        {
            Initialize();
        }

        async void AtualizaDados()
        {
            cliente = await dataService.GetClienteAsync(); //
        }

        public IMvxCommand EstacionarTextCommand => new MvxCommand(Estacionar);
        private void Estacionar()
        {
            txtHora = System.DateTime.Now.ToString("HH:mm");
            txtPlacaEstacionada = txtPlaca;
        }

        #region Propriedades

        private string _cpf;
        private string _placa;
        private string _tempo;
        private string _placaEstacionada;
        private string _hora;

        public string Cpf { get => _cpf; set => _cpf = value; }

        public string txtPlaca
        {
            get
            {
                return _placa;
            }
            set
            {
                _placa = value;
                RaisePropertyChanged(() => txtPlaca);
            }
        }

        public string clkTempo
        {
            get
            {
                return _tempo;
            }
            set
            {
                _tempo = value;
                RaisePropertyChanged(() => clkTempo);
            }
        }
        public string txtPlacaEstacionada
        {
            get
            {
                return _placaEstacionada;
            }
            set
            {
                _placaEstacionada = value;
                RaisePropertyChanged(() => txtPlacaEstacionada);
            }
        }
        public string txtHora
        {
            get
            {
                return _hora;
            }
            set
            {
                _hora = value;
                RaisePropertyChanged(() => txtHora);
            }
        }


        #endregion

    }


}
