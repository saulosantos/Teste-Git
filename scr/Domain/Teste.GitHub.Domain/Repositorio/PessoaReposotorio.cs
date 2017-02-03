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
        private readonly DbContextGit _context = new DbContextGit();

        public void SalvarPessoa(Pessoa pessoa)
        {
            _context.Pessoas.Add(pessoa);
            _context.SaveChanges();
        }


        public Pessoa OberPorId(int id)
        {
            return _context.Pessoas.Single(p => p.PessoaId == id);
        }

        public Pessoa ObterPorCpf(string cpf)
        {
            return _context.Pessoas.Single(p => p.CPF == cpf);
        }

    }
}
