using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZonaAzulDigital.Core.Models
{
    public class Cartoes
    {
        public int Cd_Cartoes { get; set; }
        public DateTime DataEntrada { get; set; }
        public string Placa { get; set; }
        public int Tipo_Cartao { get; set; }
        public bool Ativo { get; set; }
    }
}
