using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZonaAzulDigitalAPI.Models
{
    interface ICartoesRepositorio
    {
        IEnumerable<Cartoes> All { get; }
        Cartoes Find(int Cd_Cartoes);
        void Insert(Cartoes item);
        void Update(Cartoes item);
        void Delete(int Cd_Cartoes);
    }
}
