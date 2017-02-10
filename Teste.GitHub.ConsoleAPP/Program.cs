using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teste.GitHub.Domain.Context;
using Teste.GitHub.Domain.Entidades;
using Teste.GitHub.Domain.Repositorio;

namespace Teste.GitHub.ConsoleAPP
{
    class Program
    {
        static void Main(string[] args)
        {

           // var nomes = new Pessoa { Nome = "Galeroso da Sobral", Endereco = "Rua Pedro Amaral, 1785", CPF = "00461443236", Email = "saulosantos89@gmail.com", DataNascimento = DateTime.Today, Telefone = "68992317348", DataCadastro = DateTime.Today, Ativo = true };
            var usuarios = new Usuario { Ativo = true, ConfirmaSenha = "123456abc", DataCadastro = DateTime.Now, LoginUser = "juma", NomeUsuario = "Juma Mahua", SenhaUsuario = "123456abc", TipoUsuarioId = 1 };
           
            UsuarioRepositorio db = new UsuarioRepositorio();
            db.CadastrarUsuario(usuarios);

            //   using (DbContextGit db = new DbContextGit())
            //  {
            //     db.Pessoas.Add(nomes);
            //    db.SaveChanges();
            // }

            //PessoaReposotorio db = new PessoaReposotorio();
            //db.SalvarPessoa(nomes);




            //LISTAR ------
          //  UsuarioRepositorio _context = new UsuarioRepositorio();

          /*  var usuarios = _context.ObterTipoUser();
            foreach(TipoUsuario tipousuario in usuarios)
            {
                Console.WriteLine(
                    tipousuario.NomeTipoUsuario);
            }
             */
            //FIM LISTAR -----


                Console.WriteLine("Olá mundo maluco!");
            Console.ReadKey();
    }
    }
}

