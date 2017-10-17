using System.Web.Mvc;
using System.Web.Http;
using ZonaAzulDigitalAPI.Models;

namespace ZonaAzulDigitalAPI.Controllers
{
    public class HomeController : Controller
    {
        //private readonly IClienteRepositorio _clienteRepositorio;

        //public HomeController(Cliente cliente)
        //{
        //    //_clienteRepositorio = new ClienteRepositorio();
        //    _clienteRepositorio.Insert(cliente);
        //}

        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }

        //public ActionResult Cadastro()
        //{
        //    return View();
        //}

        //[System.Web.Mvc.HttpPost()]
        //public void Post([FromBody] Cliente cliente)
        //{
        //    _clienteRepositorio.Insert(cliente);
        //}

    }
}
