using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ZonaAzulDigitalWebAPI.Models;

namespace ZonaAzulDigitalWebAPI.Controllers
{
    public class ClienteController : ApiController
    {
        private readonly IClienteRepositorio _clienteRepositorio;

        public ClienteController()
        {
            _clienteRepositorio = new ClienteRepositorio();
        }

        [HttpGet]
        public IEnumerable<Cliente> List()
        {
            return _clienteRepositorio.All;
        }

        public Cliente GetCliente(int id)
        {
            var cliente = _clienteRepositorio.Find(id);

            if(cliente == null)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));

            }

            return cliente;
        }
        [HttpPost()]
        public void Post([FromBody]Cliente cliente)
        {
            _clienteRepositorio.Insert(cliente);
        }

        [HttpPut()]
        public void Put(int id, [FromBody] Cliente cliente)
        {
            cliente.Cd_Cliente = id;
            _clienteRepositorio.Update(cliente);

        }

        [HttpDelete()]
        public void Delete(int id)
        {
            _clienteRepositorio.Delete(id);
        }
    }
}
