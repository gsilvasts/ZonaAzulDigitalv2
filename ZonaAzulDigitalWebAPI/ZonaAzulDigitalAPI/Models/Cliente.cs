﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ZonaAzulDigitalAPI.Models
{
    public class Cliente
    {
        
        public string CPF { get; set; }   
        public string Nome { get; set; }   
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Senha { get; set; }
    }
}