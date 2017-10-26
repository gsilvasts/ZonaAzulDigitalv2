using System.Net;
using System.Net.Http;
using System.Web.Http;
using ZonaAzulDigitalAPI.Models;

namespace ZonaAzulDigitalAPI.Controllers
{
    public class VeiculoController : ApiController
    {
        private readonly IVeiculoRepositorio _veiculoRepositorio;

        public VeiculoController()
        {
            _veiculoRepositorio = new VeiculoRepositorio();
        }
        //GET: api/Veiculo
 
        //GET: api/Veiculo/5
        public Veiculos GetVeiculo(string CPF)
        {
            var veiculo = _veiculoRepositorio.Find(CPF);

            if (veiculo == null)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));

            }

            return veiculo;
        }

        [HttpPost()]
        public void Post([FromBody]Veiculos veiculo)
        {
            _veiculoRepositorio.Insert(veiculo);
        }

        [HttpDelete()]
        public void Delete(string CPF)
        {
            _veiculoRepositorio.Delete(CPF);
        }

    }
}