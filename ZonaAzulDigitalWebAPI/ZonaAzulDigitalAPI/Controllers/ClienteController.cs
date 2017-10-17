using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using ZonaAzulDigitalAPI.Models;

namespace ZonaAzulDigitalAPI.Controllers
{
    public class ClienteController : ApiController
    {

        //GET: Cliente
        //public ActionResult Cadastro()
        //{
        //    return View();
        //}



        private readonly IClienteRepositorio _clienteRepositorio;

        public ClienteController()
        {
            _clienteRepositorio = new ClienteRepositorio();
        }
        //GET: api/Cliente
        [HttpGet]
        public IEnumerable<Cliente> List()
        {
            return _clienteRepositorio.All;
        }


        //GET: api/Cliente/5
        public Cliente GetCliente(string CPF)
        {
            var cliente = _clienteRepositorio.Find(CPF);

            if (cliente == null)
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
        public void Put(string CPF, [FromBody] Cliente cliente)
        {
            cliente.CPF = CPF;
            _clienteRepositorio.Update(cliente);

        }

       [HttpDelete()]
        public void Delete(string CPF)
        {
            _clienteRepositorio.Delete(CPF);
        }

    }
}