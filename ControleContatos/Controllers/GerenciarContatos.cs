using Microsoft.AspNetCore.Mvc;

namespace ControleContatos.Controllers
{
    public class GerenciarContatos : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult CriarContato()
        {
            return View();
        }
        public IActionResult EditarContato()
        {
            return View();
        }
        public IActionResult DeletarContatoConfirm()
        {
            return View();
        }

    }
}
