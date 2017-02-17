using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Teste.GitHub.Domain.Context;
using Teste.GitHub.Domain.Entidades;
using Teste.GitHub.Domain.Repositorio;
using Teste.GitHub.Web.Models.Upload;

namespace Teste.GitHub.Web.Controllers
{
    public class PessoasController : Controller
    {
        private DbContextGit db = new DbContextGit();

        PessoaReposotorio _contexto = new PessoaReposotorio();

        // GET: Pessoas
        public ActionResult Index()
        {
            return View(db.Pessoas.ToList());
        }

        // GET: Pessoas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pessoa pessoa = _contexto.OberPorId(id);
            if (pessoa == null)
            {
                return HttpNotFound();
            }
            return View(pessoa);
        }

        // GET: Pessoas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Pessoas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PessoaId,Nome,Endereco,CPF,Email,DataNascimento,Telefone,Ativo")] Pessoa pessoa)
        {
            if (ModelState.IsValid)
            {

                _contexto.SalvarPessoa(pessoa);
                ViewBag.IdCadastrado = pessoa.PessoaId;


                //return RedirectToAction("Index");
                return View();
            }

            return View();
        }

        // GET: Pessoas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pessoa pessoa = _contexto.OberPorId(id);
            if (pessoa == null)
            {
                return HttpNotFound();
            }
            return View(pessoa);
        }

        // POST: Pessoas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PessoaId,Nome,Endereco,CPF,Email,DataNascimento,Telefone,DataCadastro,Ativo")] Pessoa pessoa)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pessoa).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pessoa);
        }


        public ActionResult uploadArquivos(Remessa arq, int IdCadastrado)
        {
            //Caminho URL
            // caminhoUrl: 1 = Novo Cadastro
            // caminhoUrl: 2 = Edição

            try
            {
                string nomeArquivo = "";
                string arquivoEnviados = "";
                string extencao = "";
                string endCaminho = "";
                int TamanhoArquivo = 0;
                foreach (var arquivo in arq.Arquivos)
                {
                    if (arquivo.ContentLength > 0)
                    {
                        //nomeArquivo = Path.GetFileName(arquivo.FileName);
                        nomeArquivo = Path.GetRandomFileName();
                        extencao = Path.GetExtension(arquivo.FileName);
                        var caminho = Path.Combine(Server.MapPath("~/App_Data/uploads"), nomeArquivo + extencao);
                        TamanhoArquivo = arquivo.ContentLength;
                        endCaminho = "/App_Data/uploads/" + nomeArquivo + extencao;
                        arquivo.SaveAs(caminho);
                   

                        //Salva no BD as informações
                        ArquivoPessoa pessoa = new ArquivoPessoa();
                        pessoa.PessoaId = IdCadastrado;
                        pessoa.ArquivoCaminho = endCaminho;
                        pessoa.extencao = extencao;
                        pessoa.Ativo = true;
                        pessoa.DataCadastro = DateTime.Now;


                        _contexto.CadastrarArquivos(pessoa);

                    }
                    arquivoEnviados = arquivoEnviados + " , " + nomeArquivo;
                }
                ViewBag.Mensagem = "Arquivos Enviados :" + arquivoEnviados + ", com sucesso!";

            }

            catch (Exception ex)
            {
                ViewBag.Mensagem = "Ocorreu um Erro: " + ex.Message;
            }

            return RedirectToAction("Details", new { id = IdCadastrado });
           

        }


        public ActionResult listarImagens(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

                return View(_contexto.ListarArquivos(id));
        }


        public ActionResult ultimosCadastros()
        {
            
            return View(_contexto.ultimosCadastros());
        }



        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
