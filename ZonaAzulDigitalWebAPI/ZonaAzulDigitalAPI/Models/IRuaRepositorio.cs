using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZonaAzulDigitalAPI.Models
{
    public interface IRuaRepositorio
    {
        IEnumerable<Rua> All { get; }
    

    }
}
