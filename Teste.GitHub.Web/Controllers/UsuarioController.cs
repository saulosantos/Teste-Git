using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Teste.GitHub.Domain.Entidades;
using Teste.GitHub.Domain.Repositorio;

namespace Teste.GitHub.Web.Controllers
{
    public class UsuarioController : Controller
    {

        UsuarioRepositorio _contexto = new UsuarioRepositorio();

        // GET: Usuario
        public ActionResult Index()
        {
            return View();
        }



        public ActionResult Cadastrar()
        {
            ViewBag.ListaTipoUser = new SelectList(_contexto.ObterTipoUser(), "TipoUsuarioId", "NomeTipoUsuario");

            return View();
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
       // public ActionResult Cadastrar([Bind(Include = "NomeUsuario, LoginUser, SenhaUsuario, ConfirmaSenha, ListaTipoUser")]Usuario usuario)
        public ActionResult Cadastrar(Usuario usuario)
        {
           

            if (ModelState.IsValid)
            {
                usuario.TipoUsuarioId = 1;
                usuario.Ativo = true;
                usuario.DataCadastro = DateTime.Now;
                _contexto.CadastrarUsuario(usuario);
                return View(usuario);
            }

            return View();
        }


        //Cadastra o Tipo do Usuario -Admim, Comum, Etc...
        public ActionResult CadastrarTipoUsuario(TipoUsuario tipoUser)
        {


            if (ModelState.IsValid)
            {
                tipoUser.Ativo = true;
                _contexto.CadastrarTipoUsuario(tipoUser);
            }

            return View();
        }
    }
}