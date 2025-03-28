using Microsoft.AspNetCore.Mvc;
using atividade.Models;
using atividade.Repositorio;



namespace atividade.Controllers
{
    public class ProdutoController : Controller
    {
        private readonly ProdutoRepositorio _produtoRepositorio;

        public ProdutoController(ProdutoRepositorio produtoRepositorio)
        {
            _produtoRepositorio = produtoRepositorio;
        }

        public IActionResult Cadastro()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Cadastro(Produto produto)
        {
            if(ModelState.IsValid)
            {
                _produtoRepositorio.AdicionarProduto(produto);
                return RedirectToAction("Home");
            }
            return View();
        }

    }
}
