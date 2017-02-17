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
       

        public int SalvarPessoa(Pessoa pessoa)
        {
            using (var _context = new DbContextGit())
            {
                pessoa.DataCadastro = DateTime.Now;
                pessoa.Ativo = true;
                _context.Pessoas.Add(pessoa);
                _context.SaveChanges();

                return pessoa.PessoaId;

            }

        }


        public Pessoa OberPorId(int? id)
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

        public List<Pessoa> ultimosCadastros()
        {
            using (var _context = new DbContextGit())
            {
                return _context.Pessoas.Where(p => p.Ativo == true).Take(10).OrderByDescending(p => p.PessoaId).ToList();
            }

        }


        public void CadastrarArquivos(ArquivoPessoa arquivopessoa)
        {
            using (var _context = new DbContextGit())
            {
                _context.ArquivosPessoas.Add(arquivopessoa);
                _context.SaveChanges();
            }
        }


        public IList<ArquivoPessoa> ListarArquivos(int? id)
        {
            using(var _context = new DbContextGit())
            {
              return _context.ArquivosPessoas.Include("Pessoa")
                    .Where(p => p.Ativo == true)
                    .Where(p => p.PessoaId == id)
                    .OrderByDescending(p => p.DataCadastro).ToList();
            }
        }


    }
}
