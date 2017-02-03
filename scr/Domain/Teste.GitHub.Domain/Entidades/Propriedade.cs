using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teste.GitHub.Domain.Entidades
{
   public  class Propriedade
    {
        [Key]
        public int PropriedadeId { get; set; }

        [Required(ErrorMessage ="Digite o nome da propriedade")]
        [MaxLength(100), MinLength(2)]
        public string Nome { get; set; }

        [MaxLength(100), MinLength(4)]
        public string Endereco { get; set; }
        public DateTime DataCadastro { get; set; }
        public bool Ativo { get; set; }


        public int PessoaId { get; set; }


        public virtual Pessoa Pessoa { get; set; }
    }
}
