using System;
using System.Collections.Generic;



namespace ZonaAzulDigitalWebAPI.Models
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

        public Cliente Find(int id)
        {
            return DalHelper.GetCliente(id);
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

        //public void Update(int id)
        //{
        //    throw new NotImplementedException();
        //}

        public void Delete(int id)
        {
            DalHelper.DeleteCliente(id);
        }
       
    }
}