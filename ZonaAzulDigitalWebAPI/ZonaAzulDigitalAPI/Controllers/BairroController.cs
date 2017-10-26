using System.Collections.Generic;
using System.Web.Http;
using ZonaAzulDigitalAPI.Models;

namespace ZonaAzulDigitalAPI.Controllers
{
    public class BairroController : ApiController
    {
        // GET: Bairro
        private readonly IBairroRepositorio _bairroRepositorio;

        public BairroController()
        {
            _bairroRepositorio = new BairroRepositorio();
        }
        //GET: api/Cliente
        [HttpGet]
        public IEnumerable<Bairro> List()
        {
            return _bairroRepositorio.All;
        }
    }
}