using System;
using System.Threading.Tasks;
using System.Web.Mvc;
using WebApplicationSolution.WebMVC.Models;

namespace WebMVC.Controllers
{
    public class ClienteController : Controller
    {
        public ActionResult Criar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Criar(DadosPessoais dadosPessoais)
        {
            try
            {
                var retorno = CriarDados(dadosPessoais);

                return View(retorno);
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        public async Task<DadosPessoais> CriarDados(DadosPessoais dadosPessoais)
        {
            try
            {
                var integrationService = new Integration.IntegrationService();
                return await integrationService.CriarDados(dadosPessoais);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public ActionResult Editar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Editar(int id, FormCollection collection)
        {
            try
            {

                return RedirectToAction("Create");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Deletar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Deletar(int id)
        {
            try
            {
                return RedirectToAction("Create");
            }
            catch
            {
                return View();
            }
        }
    }
}
