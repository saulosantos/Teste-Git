using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        
        [Key]
        public int PessoaId { get; set; }

        //AllowEmptyStrings permite escrita em branco
        [Required(ErrorMessage ="Informe o nome", AllowEmptyStrings=false)]
        [MaxLength(100), MinLength(2, ErrorMessage ="Escreva no minimo 3 caracteres")]
        public string Nome { get; set; }

        [MaxLength(100), MinLength(4, ErrorMessage = "Digite no minimo 4 caracteres")]
        public string Endereco { get; set; }


        [Required(ErrorMessage = "Informe o seu email")]
        [RegularExpression(".+\\@.+\\..+", ErrorMessage = "Informe um email válido...")]
        public string Email { get; set; }


        [Required(ErrorMessage = "Data de nascimento obrigatorio", AllowEmptyStrings = false)]
        [Display(Name = "Data Nascimento")]
        [DisplayFormat(DataFormatString = "dd/mm/yyyy")]
        public DateTime DataNascimento { get; set; }


        public string Telefone { get; set; }

        public DateTime DataCadastro { get; set; }
        public bool Ativo { get; set; }

        public virtual ICollection<Propriedade> propriedades { get; set; }

    }
}
