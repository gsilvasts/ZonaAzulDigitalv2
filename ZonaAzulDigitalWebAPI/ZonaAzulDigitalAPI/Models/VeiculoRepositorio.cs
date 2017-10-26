using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ZonaAzulDigitalAPI.Models
{
    public class VeiculoRepositorio : IVeiculoRepositorio
    {
        private List<Veiculos> _veiculos;


        public IEnumerable<Veiculos> All
        {
            get
            {
                return _veiculos;
            }
        }

        public void Delete(string CPF)
        {
            DalHelper.DeleteVeiculos(CPF);
           
        }

        public Veiculos Find(string CPF)
        {
            return DalHelper.GetVeiculos(CPF);
        }

        public void Insert(Veiculos veiculos)
        {
            if (veiculos == null)
            {
                throw new ArgumentNullException("veiculos");
            }

            DalHelper.InsertVeiculos(veiculos);
        }
    }
}