using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
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

            return View(_contexto.ListarUsuarios().ToList());
        }



        public ActionResult Cadastrar()
        {

            ViewBag.TipoUsuarioId = new SelectList(
                _contexto.ListaTiposUsuarios(), "TipoUsuarioId", "NomeTipoUsuario"
                );

            return View();
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Cadastrar([Bind(Include = "NomeUsuario, LoginUser, SenhaUsuario, ConfirmaSenha, TipoUsuarioId")]Usuario usuario)
        //public ActionResult Cadastrar(Usuario usuario)
        {
            ViewBag.TipoUsuarioId = new SelectList(
                _contexto.ListaTiposUsuarios(),
                "TipoUsuarioId",
                "NomeTipoUsuario",
                usuario.TipoUsuarioId);

            if (ModelState.IsValid)
            {
                usuario.Ativo = true;
                usuario.DataCadastro = DateTime.Now;
                _contexto.CadastrarUsuario(usuario);

                return RedirectToAction("Index");
            }

            return View();
        }


        //Cadastra o Tipo do Usuario -Admim, Comum, Etc...
        [ValidateAntiForgeryToken]
        public ActionResult CadastrarTipoUsuario(TipoUsuario tipoUser)
        {


            if (ModelState.IsValid)
            {
                tipoUser.Ativo = true;
                _contexto.CadastrarTipoUsuario(tipoUser);
            }

            return View();
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            Usuario usurio = _contexto.BuscarPorId(id);

            ViewBag.TipoUsuarioId = new SelectList(
            _contexto.ListaTiposUsuarios(), "TipoUsuarioId", "NomeTipoUsuario"
             );

            return View(usurio);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UsuarioId, NomeUsuario, LoginUser, Ativo, TipoUsuarioId")]Usuario usuario)
        {

             ViewBag.TipoUsuarioId = new SelectList(
                 _contexto.ListaTiposUsuarios(),
                 "TipoUsuarioId",
                 "NomeTipoUsuario",
                 usuario.TipoUsuarioId);

            if (ModelState.IsValid)
            {
                _contexto.AtualizaUsuario(usuario);
            }

                        
            return View();

        }

        public ActionResult ListaTipoUSer()
        {

           // return View(_contexto.ListaTipoUser());

            return Json(_contexto.ListaTipoUser(), JsonRequestBehavior.AllowGet);
        }




    }
}