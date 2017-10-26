using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZonaAzulDigitalAPI.Models
{
    public interface IBairroRepositorio
    {
        IEnumerable<Bairro> All { get; }
    }
}
