using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZonaAzulDigitalWebAPI.Models
{
    public interface IClienteRepositorio
    {
        IEnumerable<Cliente> All { get; }
        Cliente Find(int id);
        void Insert(Cliente item);
        void Update(Cliente item);
        void Delete(int id);
    }
}
