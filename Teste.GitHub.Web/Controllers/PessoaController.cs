using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Teste.GitHub.Domain.Entidades;
using Teste.GitHub.Domain.Repositorio;

namespace Teste.GitHub.Web.Controllers
{
    public class PessoaController : Controller
    {

        private PessoaReposotorio _repositorio;

        // GET: Pessoa
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CadastrarPessoa(Pessoa pessoa)
        {
            _repositorio.SalvarPessoa(pessoa);
            return View();

        }
    }
}