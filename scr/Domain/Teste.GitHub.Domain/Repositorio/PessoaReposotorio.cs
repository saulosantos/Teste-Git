using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teste.GitHub.Domain.Context;
using Teste.GitHub.Domain.Entidades;

namespace Teste.GitHub.Domain.Repositorio
{
    public class PessoaReposotorio
    {
       

        public string SalvarPessoa(Pessoa pessoa)
        {
            using (var _context = new DbContextGit())
            {
                pessoa.DataCadastro = DateTime.Now;
                pessoa.Ativo = true;
                _context.Pessoas.Add(pessoa);
                _context.SaveChanges();

                return pessoa.PessoaId.ToString();

            }

        }


        public Pessoa OberPorId(int id)
        {
            using (var _context = new DbContextGit())
            {
                return _context.Pessoas.Single(p => p.PessoaId == id);
            }

        }

        public Pessoa ObterPorCpf(string cpf)
        {
            using (var _context = new DbContextGit())
            {
                return _context.Pessoas.Single(p => p.CPF == cpf);
            }
               
        }

    }
}
