using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ZonaAzulDigitalAPI.Models;

namespace ZonaAzulDigitalAPI.Controllers
{
    public class CartoesController : ApiController
    {
        private readonly ICartoesRepositorio _cartoesRepositorio;

        [HttpGet]
        public IEnumerable<Cartoes> List()
        {
            return _cartoesRepositorio.All;
        }


        //GET: api/Cliente/5
        public Cartoes GetCartoes(int Cd_Cartoes)
        {
            var cartoes = _cartoesRepositorio.Find(Cd_Cartoes);

            if (cartoes == null)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));

            }

            return cartoes;
        }

        [HttpPost()]
        public void Post([FromBody]Cartoes cartoes)
        {
            _cartoesRepositorio.Insert(cartoes);
        }

        [HttpPut()]
        public void Put(int Cd_Cartoes, [FromBody] Cartoes cartoes)
        {
            cartoes.Cd_Cartoes = Cd_Cartoes;
            _cartoesRepositorio.Update(cartoes);

        }

        [HttpDelete()]
        public void Delete(int Cd_Cartoes)
        {
            _cartoesRepositorio.Delete(Cd_Cartoes);
        }
    }
}
