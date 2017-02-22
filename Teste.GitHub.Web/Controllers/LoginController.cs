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
        public ActionResult Index(Usuario usuario)
        {

            if (ModelState.IsValid)
            {
              Usuario user =  _contexto.verificaUsuario(usuario);
                if (user != null)
                {
                    if (!Equals(usuario.SenhaUsuario, user.SenhaUsuario))
                    {
                        ModelState.AddModelError("", "Senha/Usuario incorreta!");
                    }
                    else
                    {
                        FormsAuthentication.SetAuthCookie(user.LoginUser, false);
                    }

                    return RedirectToAction("Index", "home");
                }
            }


            return View(new Usuario());
        }
    }
}