using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ZonaAzulDigitalAPI.Models
{
    public class RuaRepositorio : IRuaRepositorio
    {
        private List<Rua> _rua;

        public RuaRepositorio()
        {
            InicializaDados();
        }

        private void InicializaDados()
        {
            _rua = DalHelper.GetRua();
        }

        public IEnumerable<Rua> All
        {
            get
            {
                return _rua;
            }
        }

    }
}