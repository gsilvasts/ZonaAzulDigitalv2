using System.Threading.Tasks;
using MvvmCross.Core.ViewModels;
using ZonaAzulDigital.Core.Services;
using ZonaAzulDigital.Core.Provider.DialogProvider;
using MvvmCross.Platform;

namespace ZonaAzulDigital.Core.ViewModels
{
    public class PagamentoViewModel : MvxViewModel
    {
        private DataService dataService = new DataService();
        
        protected IDialogProvider _dialogProvider;

        public PagamentoViewModel()
        {
            Initialize();
            dataService = new DataService();
            _dialogProvider = Mvx.Resolve<IDialogProvider>();
        }

        public override Task Initialize()
        {
            return base.Initialize();
        }
 
        
        private bool Valida()
        {            
            if(string.IsNullOrEmpty(txtNumero) && string.IsNullOrEmpty(txtNome) && string.IsNullOrEmpty(txtAno) && 
                    string.IsNullOrEmpty(txtMes) && string.IsNullOrEmpty(txtCodSeg))
            {
                return true;
            }
            return false;
        }

        public void Limpar()
        {
            txtNumero = "";
            txtNome = "";
            txtAno = "";
            txtMes = "";
            txtCodSeg = "";
        }

        public IMvxCommand ConfirmarCommand => new MvxCommand(Confirmar);
        private void Confirmar()
        {
            _dialogProvider.Confirm("Atenção!", "Confirma os dados de pagamento?", "Não", "Sim", () => { Limpar(); }, () => {  Close(this); });
        }



        #region Propriedades

        private string _ano;
        public string txtAno
        {
            get
            {
                return _ano;
            }
            set
            {
                _ano = value;
                RaisePropertyChanged(() => txtAno);
            }
        }
        private string _mes;
        public string txtMes
        {
            get
            {
                return _mes;
            }
            set
            {
                _mes = value;
                RaisePropertyChanged(() => txtMes);
            }
        }
        private string _numero;
        public string txtNumero
        {
            get
            {
                return _numero;
            }
            set
            {
                _numero = value;
                RaisePropertyChanged(() => txtNumero);
            }
        }
        private string _nome;
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
        private string _codseg;
        public string txtCodSeg
        {
            get
            {
                return _codseg;
            }
            set
            {
                _codseg = value;
                RaisePropertyChanged(() => txtCodSeg);
            }
        }



        #endregion

    }

}