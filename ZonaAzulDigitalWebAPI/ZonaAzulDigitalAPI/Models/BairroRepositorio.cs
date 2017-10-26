using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ZonaAzulDigitalAPI.Models
{
    public class BairroRepositorio : IBairroRepositorio
    {
        private List<Bairro> _bairro;

        public BairroRepositorio()
        {
            InicializaDados();
        }

        private void InicializaDados()
        {
            _bairro = DalHelper.GetBairro();
        }

        public IEnumerable<Bairro> All
        {
            get
            {
                return _bairro;
            }
        }
    }
}