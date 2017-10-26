using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using ZonaAzulDigitalAPI.Models;

namespace ZonaAzulDigitalAPI.Controllers
{
    public class RuaController : ApiController
    {
        // GET: Rua
        private readonly IRuaRepositorio _ruaRepositorio;

        public RuaController()
        {
            _ruaRepositorio = new RuaRepositorio();
        }
        //GET: api/Cliente
        [HttpGet]
        public IEnumerable<Rua> List()
        {
            return _ruaRepositorio.All;
        }
    }
}