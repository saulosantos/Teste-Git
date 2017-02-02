using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teste.GitHub.Domain.Entidades
{
   public class Pessoa
    {
        public Pessoa()
        {
            this.propriedades = new List<Propriedade>();
        }
        

        public int PessoaId { get; set; }
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public DateTime DataNascimento { get; set; }
        public DateTime DataCadastro { get; set; }
        public bool Ativo { get; set; }

        public virtual ICollection<Propriedade> propriedades { get; set; }

    }
}
