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
        public string CPF { get; set; }

        public string Login { get; set; }
        public string Nome { get; set; }        
        public string RG { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Senha { get; set; }

    }
}