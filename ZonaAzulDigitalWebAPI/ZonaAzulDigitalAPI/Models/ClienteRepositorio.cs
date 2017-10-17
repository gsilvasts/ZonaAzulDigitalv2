using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ZonaAzulDigitalAPI.Models
{
    public class ClienteRepositorio : IClienteRepositorio

    {
        private List<Cliente> _cliente;

        public ClienteRepositorio()
        {
            InicializaDados();
        }

        private void InicializaDados()
        {
            _cliente = DalHelper.GetCliente();
        }

        public IEnumerable<Cliente> All
        {
            get
            {
                return _cliente;
            }
        }

        public Cliente Find(string CPF)
        {
            return DalHelper.GetCliente(CPF);
        }

        public void Insert(Cliente cliente)
        {
            if (cliente == null)
            {
                throw new ArgumentNullException("cliente");
            }

            DalHelper.InsertCliente(cliente);
        }

        public void Update(Cliente cliente)
        {

            if (cliente == null)
            {
                throw new ArgumentNullException("cliente");
            }

            DalHelper.UpdateCliente(cliente);
        }


        public void Delete(string CPF)
        {
            DalHelper.DeleteCliente(CPF);
        }

    }
}