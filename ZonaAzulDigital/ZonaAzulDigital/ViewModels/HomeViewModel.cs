using System.Threading.Tasks;
using MvvmCross.Core.ViewModels;
using System;
using ZonaAzulDigital.Core.Services;
using ZonaAzulDigital.Core.Models;
using System.Collections.Generic;
using ZonaAzulDigital.Core.Provider.DialogProvider;
using MvvmCross.Platform;
using System.Text.RegularExpressions;
using System.Threading;

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
            double tipo = 0;
            /*Cartoes novocliente = new Cartoes
            {
                CPF = Cpf;
            };*/


            restante = DateTime.Now;
            //Cartoes.Data = DateTime.Now;
            

            if (OptionA)
            {
                tipo = 0.011; // para testes.
                //tipo = 1;
                //Cartoes.Tipo = 1;
            }
            else if(OptionB)
            {
                tipo = 2;
                //Cartoes.Tipo = 2;
            }

            if (ValidaPlaca(txtPlaca))
            {
                txtPlacaEstacionada = txtPlaca.ToUpper().Trim().Insert(3, "-");
                StartUpdate(restante, tipo);
                BloqueiaOpcoes();
                ShowViewModel<PagamentoViewModel>();                
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

        private void BloqueiaOpcoes()
        {
            txtPlaca_Enabled = false;
            Estacionar_Enabled = false;
            OptionA_Enabled = false;
            OptionB_Enabled = false;
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

        //Timer para atualizar tempo restante.
        private CancellationTokenSource cts;
        public void StartUpdate(DateTime hora, double tipo)
        {
            if (cts != null) cts.Cancel();
            cts = new CancellationTokenSource();
            var ignore = UpdaterAsync(hora, tipo);
        }

        public void StopUpdate()
        {
            if (cts != null) cts.Cancel();
            cts = null;
        }

        public async Task UpdaterAsync(DateTime hora, double tipo)
        {
            TimeSpan horarestante;
            while (!cts.IsCancellationRequested)
            {
                horarestante = hora.AddHours(tipo).Subtract(DateTime.Now);
                if(horarestante.TotalMilliseconds <= 0)
                {
                    txtHora = "Vencido";
                    break;
                }
                txtHora = horarestante.ToString(@"hh\:mm\:ss");
                await Task.Delay(500);
            }
        }


        #region Propriedades

        private string _cpf;

        public string Cpf { get => _cpf; set => _cpf = value; }

        private string _placa;

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

        private string _placaEstacionada;

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
        
        private string _hora;

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

        private bool _optiona;

        public bool OptionA
        {
            get
            {
                return _optiona;

            }
            set
            {
                _optiona = value;
                RaisePropertyChanged(() => OptionA);
            }
        }

        private bool _optionb;

        public bool OptionB
        {
            get
            {
                return _optionb;

            }
            set
            {
                _optionb = value;
                RaisePropertyChanged(() => OptionB);
            }
        }

        private bool _optiona_enabled = true;
        public bool OptionA_Enabled
        {   get { return _optiona_enabled;}
            set { _optiona_enabled = value; RaisePropertyChanged(() => OptionA_Enabled); }
        }
        private bool _optionb_enabled = true;
        public bool OptionB_Enabled
        {
            get { return _optionb_enabled; }
            set { _optionb_enabled = value; RaisePropertyChanged(() => OptionB_Enabled); }
        }
        private bool _txtplaca_enabled = true;
        public bool txtPlaca_Enabled
        {
            get { return _txtplaca_enabled; }
            set { _txtplaca_enabled = value; RaisePropertyChanged(() => txtPlaca_Enabled); }
        }
        private bool _estacionar_enabled = true;
        public bool Estacionar_Enabled
        {
            get { return _estacionar_enabled; }
            set { _estacionar_enabled = value; RaisePropertyChanged(() => Estacionar_Enabled); }
        }



        #endregion

    }


}
