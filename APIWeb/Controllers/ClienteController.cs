using APIWeb.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using WebApplicationSolution.APIWeb.Models;

namespace APIWeb.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly IDadosPessoaisService _dadosPessoaisService;
        private readonly ILogger<ClienteController> _logger;

        public ClienteController(ILogger<ClienteController> logger, IDadosPessoaisService dadosPessoaisService)
        {
            _logger = logger;
            _dadosPessoaisService = dadosPessoaisService;
        }

        [HttpGet]
        public IActionResult ObterTodosDadosPessoais()
        {
            _logger.LogInformation($"ClienteController - ObterTodosDadosPessoais");
            return Ok(_dadosPessoaisService.ObterTodosOsDadosPessoais());
        }

        [HttpPost]
        public IActionResult CriarDadosPessoais(DadosPessoais dadosPessoais)
        {
            _logger.LogInformation($"ClienteController - CriarDadosPessoais {dadosPessoais}");
            return Ok(_dadosPessoaisService.CriarDadosPessoais(dadosPessoais));
        }

        [HttpDelete]
        public IActionResult DeletarDadosPessoais([FromHeader] string CPF, [FromHeader] string CEP)
        {
            _logger.LogInformation($"ClienteController - DeletarDadosPessoais {CPF}, {CEP}");
            return Ok(_dadosPessoaisService.DeletarDadosPessoais(CPF, CEP));
        }

        [HttpPut]
        public IActionResult AtualizarDadosPessoais([FromHeader] string CPF, [FromHeader] string CEP, DadosPessoais dadosPessoais)
        {
            _logger.LogInformation($"ClienteController - AtualizarDadosPessoais {CPF}, {CEP}, {dadosPessoais}");
            return Ok(_dadosPessoaisService.AtualizarDadosPessoais(CPF, CEP, dadosPessoais));
        }

    }
}
