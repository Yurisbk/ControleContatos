using ControleContatos.Models;
using ControleContatos.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace ControleContatos.Controllers
{
    public class GerenciarContatos : Controller
    {
        private readonly IContatoRepositorio _contatoRepositorio;
        public GerenciarContatos(IContatoRepositorio contatoRepositorio)
        {
            _contatoRepositorio = contatoRepositorio;
        }
        public IActionResult Index()
        {
           var all = _contatoRepositorio.BuscarTodos();

            return View(all);
        }
        public IActionResult CriarContato()
        {
            return View();
        }
        public IActionResult EditarContato(int id)
        {
            var contato = _contatoRepositorio.ListarId(id);
            return View(contato);
        }
        public IActionResult DeletarContatoConfirm()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CriarContato(ContatoModel contato)
        {
            _contatoRepositorio.Adicionar(contato);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult EditarContato(ContatoModel contato)
        {
            _contatoRepositorio.Atualizar(contato);

            return RedirectToAction("Index");
        }
    }
}
