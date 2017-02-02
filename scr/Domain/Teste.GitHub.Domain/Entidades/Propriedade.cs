using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teste.GitHub.Domain.Entidades
{
   public  class Propriedade
    {
        public int PropriedadeId { get; set; }
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public DateTime DataCadastro { get; set; }
        public bool Ativo { get; set; }

        public int PessoaId { get; set; }

        public virtual Pessoa Pessoa { get; set; }
    }
}
