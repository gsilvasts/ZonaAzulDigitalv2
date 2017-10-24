using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ZonaAzulDigitalAPI.Models
{
    public class Cartoes
    {
        public int Cd_Cartoes { get; set; }
        public DateTime DataEntrada { get; set; }
        public DateTime DataSaida { get; set; }
        public DateTime Permanencia { get; set; }
        public int Tipo_Cartao { get; set; }

        public virtual int Cd_Veiculo { get; set; }
        public virtual int Cd_Vaga { get; set; }

    }
}