using Microsoft.AspNetCore.Mvc;
using atividade.Models;
using atividade.Repositorio;

namespace atividade.Controllers
{
    public class UsuarioController1 : Controller
    {
        private readonly UsuarioRepositorio _usuarioRepositorio;

        public UsuarioController1(UsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string email, string senha)
        {
            var usuario = _usuarioRepositorio.ObterUsuario(email);
            if(usuario != null && usuario.Senha == senha )
            {
                return RedirectToAction("Index", "Home");
            }
            ModelState.AddModelError("", "Email ou senhas invalidos");
        }


        public IActionResult Cadastro()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Cadastro(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                _usuarioRepositorio.AdicionarUsuario(usuario);
                return RedirectToAction("Login");
            }
            return View(usuario);



        }
    }
}
