using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    public class ClienteController : Controller
    {
        [HttpGet("CriarCliente")]
        public IActionResult CriarCliente()
        {
            return Ok();
        }
    }
}
