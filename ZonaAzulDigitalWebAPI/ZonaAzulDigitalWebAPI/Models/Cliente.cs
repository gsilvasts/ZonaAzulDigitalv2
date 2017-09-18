using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ZonaAzulDigitalWebAPI.Models
{
    public class Cliente
    {
        [Key]
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