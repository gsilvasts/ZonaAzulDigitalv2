using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ZonaAzulDigitalAPI.Models
{
    public interface IClienteRepositorio
    {
        IEnumerable<Cliente> All { get; }
        Cliente Find(string CPF);
        void Insert(Cliente item);
        void Update(Cliente item);
        void Delete(string CPF);
    }
}