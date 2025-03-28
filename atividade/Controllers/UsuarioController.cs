using Microsoft.AspNetCore.Mvc;
using atividade.Models;
using System.ComponentModel.DataAnnotations;
using atividade.Repositorio;

namespace atividade.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly UsuarioRepositorio _usuarioRepositorio;

        public UsuarioController(UsuarioRepositorio usuarioRepositorio)
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
            ModelState.AddModelError("", "Email ou senhas inválidos");
            return View();
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
