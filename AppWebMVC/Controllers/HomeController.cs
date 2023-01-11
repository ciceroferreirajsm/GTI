using AppWebMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RestSharp;
using AppWebMVC.Integration;

namespace AppWebMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly RestClient _client = new RestClient("http://localhost:5001/");
        private readonly IntegrationService _integrationService;

        public HomeController(ILogger<HomeController> logger, IntegrationService integrationService)
        {
            _logger = logger;
            _integrationService = integrationService;
        }

        public IActionResult Index()
        {
            var retorno = _integrationService.ObterTodos().Result;
            return View(retorno.ListDadosPessoais);
        }

        public IActionResult CriarDados()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CriarDados(DadosPessoais dados)
        {
            var retorno = _integrationService.CriarDados(dados);

            return RedirectToAction("Index", retorno);
        }

        public IActionResult AtualizarDados(int IdUsuario, string CEP)
        {
            var retorno = _integrationService.FiltrarDados(IdUsuario, CEP).DadosPessoais;
            return View(retorno);
        }

        [HttpPost]
        public IActionResult AtualizarDados(DadosPessoais dados)
        {
            var retorno = _integrationService.AtualizarDadosAsync(dados).Result;

            return RedirectToAction("AtualizarDados", new { retorno.DadosPessoais.DadosCliente.CPF, retorno.DadosPessoais.EnderecoCliente.CEP });
        }

        public IActionResult DeletarDados(int IdUsuario, string CEP)
        {
            var retorno = _integrationService.FiltrarDados(IdUsuario, CEP).DadosPessoais;
            return View(retorno);
        }

        [HttpPost]
        public IActionResult DeletarDados(DadosPessoais dados)
        {
            var retorno = _integrationService.DeletarDados(dados).Result;

            return RedirectToAction("DeletarDados", new { retorno.DadosPessoais.DadosCliente.CPF, retorno.DadosPessoais.EnderecoCliente.CEP });
        }
    }
}
