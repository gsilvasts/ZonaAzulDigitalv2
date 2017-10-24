using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ZonaAzulDigitalAPI.Models
{
    public class Rua
    {
        public int Cd_rua { get; set; }        
        public string Nome { get; set; }
        public virtual int Cd_bairro { get; set; }
    }
}