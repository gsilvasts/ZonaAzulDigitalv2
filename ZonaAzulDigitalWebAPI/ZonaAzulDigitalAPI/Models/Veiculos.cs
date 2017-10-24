using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ZonaAzulDigitalAPI.Models
{
    public class Veiculos
    {
        public int Cd_Veiculo { get; set; }
        public string Placa { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public virtual string CPF { get; set; }
    }
}