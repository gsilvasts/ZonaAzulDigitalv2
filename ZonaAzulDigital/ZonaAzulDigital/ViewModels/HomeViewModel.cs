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
using System.Text.RegularExpressions;

namespace ZonaAzulDigital.Core.ViewModels
{
    public class HomeViewModel : MvxViewModel
    {
        private DataService dataService = new DataService();
        List<Cliente> cliente;

        protected IDialogProvider _dialogProvider;


        public void Init(string CPF)
        {
            Cpf = CPF;
        }
        public HomeViewModel()
        {
            Initialize();
            _dialogProvider = Mvx.Resolve<IDialogProvider>();
        }

        async void AtualizaDados()
        {
            cliente = await dataService.GetClienteAsync(); //
        }

        public IMvxCommand EstacionarTextCommand => new MvxCommand(Estacionar);
        private void Estacionar()
        {
            DateTime restante;

            /*Cartoes novocliente = new Cartoes
            {
                CPF = Cpf;
            };*/


            restante = DateTime.Now;
            //Cartoes.Data = DateTime.Now;
            
            if (SelectedItem.Equals("1 hora"))
            {                
                restante.AddHours(1);
                //Cartoes.Tipo = 1;
            }
            else if(SelectedItem.Equals("2 horas"))
            {
                restante.AddHours(2);
               //Cartoes.Tipo = 2;
            }

            if (ValidaPlaca(txtPlaca))
            {
                txtPlacaEstacionada = txtPlaca.ToUpper().Trim().Insert(3, "-");
                //Cartoes.Placa = txtPlaca.ToUpper().Trim();
                txtHora = restante.ToString("HH:mm");
            }
            else
            {
                _dialogProvider.ShowMessage("Valor Inválido", 
                    "Digite novamente a placa do veículo no modelo XXX0000.", "OK", () => { });
                LimparPlaca();                
            }

            

            
        }

        private void LimparPlaca()
        {
            txtPlaca = "";
        }

        public bool ValidaPlaca(string placa)
        {
            if (!(string.IsNullOrEmpty(placa)))
            {
                if (placa.Length == 7 && //verifica se possui 7 caracteres XXX0000           
                  Regex.Matches(placa.Substring(0, 3), @"[a-zA-Z]").Count == 3 && //verifica se os 3 primeiros caracteres são letras
                  Regex.Matches(placa.Substring(3, 4), @"[0-9]").Count == 4) //verifica se os 4 ultimos caracteres são numericos
                {
                    return true;
                }
            }
            return false;
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


        private string _selectedtitem;

        public string SelectedItem
        {
            get
            {
                return _selectedtitem;
            }
            set
            {
                _selectedtitem = value;
                RaisePropertyChanged(() => SelectedItem);
            }
        }
        #endregion

    }


}
