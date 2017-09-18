using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZonaAzulDigital.Core.Models
{
    public class Cliente
    {
        public int Cd_Cliente { get; set; }
        public string Login { get; set; }
        public string Nome { get; set; }
        public int CPF { get; set; }
        public int RG { get; set; }
        public string Email { get; set; }
        public int Telefone { get; set; }
        public string Senha { get; set; }
    }
}
