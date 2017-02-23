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
            //var usuarios = new Usuario { UsuarioId = 1, Ativo = true, ConfirmaSenha = "123456abc", DataCadastro = DateTime.Now, LoginUser = "juma", NomeUsuario = "Juma Mahua Peligosa", SenhaUsuario = "123456abc", TipoUsuarioId = 1 };

            // UsuarioRepositorio db = new UsuarioRepositorio();
            // db.CadastrarUsuario(usuarios);

            //   using (DbContextGit db = new DbContextGit())
            //  {
            //     db.Pessoas.Add(nomes);
            //    db.SaveChanges();
            // }

            //PessoaReposotorio db = new PessoaReposotorio();
            //db.SalvarPessoa(nomes);



            /*LISTAGEM USUÁRIO
             *    
            int contador = 0;
            //LISTAR ------
            UsuarioRepositorio _context = new UsuarioRepositorio();

            Usuario modelUSer = new Usuario();
            modelUSer.SenhaUsuario = "123456abc";
            modelUSer.LoginUser = "saulo.santos";

            var usuarios = _context.verificaUsuario(modelUSer);
              foreach(Usuario listararq in usuarios)
            {
               contador +=  1;
              Console.WriteLine(
                 listararq.UsuarioId);
            }

            //Console.WriteLine(contador);

            */



                          Console.WriteLine("Olá mundo maluco!");
            Console.ReadKey();
    }
    }
}

