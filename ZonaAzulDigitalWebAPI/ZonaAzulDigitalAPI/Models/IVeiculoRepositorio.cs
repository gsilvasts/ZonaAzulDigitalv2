using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZonaAzulDigitalAPI.Models
{
    public interface IVeiculoRepositorio
    {
        IEnumerable<Veiculos> All { get; }
        Veiculos Find(string CPF);
        void Insert(Veiculos item);
        void Delete(string CPF);
    }
}
