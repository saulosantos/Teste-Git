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

            var nomes = new Pessoa { Nome = "Galeroso da Sobral", Endereco = "Rua Pedro Amaral, 1785", CPF = "00461443236", Email = "saulosantos89@gmail.com", DataNascimento = DateTime.Today, Telefone = "68992317348", DataCadastro = DateTime.Today, Ativo = true };
            //PessoaReposotorio db = new PessoaReposotorio();
            //db.SalvarPessoa(pessoas);

            //   using (DbContextGit db = new DbContextGit())
            //  {
            //     db.Pessoas.Add(nomes);
            //    db.SaveChanges();
            // }

            //PessoaReposotorio db = new PessoaReposotorio();
            //db.SalvarPessoa(nomes);


            Console.WriteLine("Olá mundo maluco!");
            Console.ReadKey();
    }
    }
}

