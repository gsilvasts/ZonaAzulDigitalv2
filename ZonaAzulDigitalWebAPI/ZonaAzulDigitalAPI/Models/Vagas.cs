using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ZonaAzulDigitalAPI.Models
{
    public class Vagas
    {
        public int Cd_Vaga { get; set; }
        public DateTime Duração { get; set; }
        public DateTime Entrada { get; set; }
        public DateTime Saida { get; set; }
        public int Tipo_Cartao { get; set; }
    }
}