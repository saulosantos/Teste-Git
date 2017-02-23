using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Teste.GitHub.Domain.Entidades;
using Teste.GitHub.Domain.Repositorio;

namespace Teste.GitHub.Web.Controllers
{
    public class LoginController : Controller
    {
        UsuarioRepositorio _contexto = new UsuarioRepositorio();

        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index([Bind(Include = "LoginUser, SenhaUsuario")]Usuario usuario)
        {

            //  if (ModelState.IsValid)
            // {
            Usuario user = _contexto.verificaUsuario(usuario);
            if (user == null)
            {
                ModelState.AddModelError("", "Usuário ou senha incorreta!");

                return View(new Usuario());
            }

                FormsAuthentication.SetAuthCookie(user.LoginUser, false);
                return RedirectToAction("Index", "home");


        }
    }
}