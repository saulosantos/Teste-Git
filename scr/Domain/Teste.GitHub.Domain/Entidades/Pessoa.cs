using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        [Column(TypeName = "VARCHAR")]
        public string Nome { get; set; }

        [MaxLength(100), MinLength(4, ErrorMessage = "Digite no minimo 4 caracteres")]
        [Column(TypeName = "VARCHAR")]
        public string Endereco { get; set; }

        [Required(ErrorMessage = "Preencha o CPF")]
        [Column(TypeName = "VARCHAR")]
        public string CPF { get; set; }

        //[Required(ErrorMessage = "Informe o seu email")]
        //[EmailAddress(ErrorMessage = "E-mail em formato inválido.")]
        [Column(TypeName = "VARCHAR")]
        public string Email { get; set; }


        [Required(ErrorMessage = "Data de nascimento obrigatorio", AllowEmptyStrings = false)]
        [Display(Name = "Data Nascimento")]
        [DisplayFormat(DataFormatString = "dd/mm/yyyy")]
        public DateTime DataNascimento { get; set; }

        [Required(ErrorMessage = "Preencha o telefone")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "Número inválido 68992317348")]
        [Column(TypeName = "VARCHAR")]
        public string Telefone { get; set; }

        public DateTime DataCadastro { get; set; }
        public bool Ativo { get; set; }

        public virtual ICollection<Propriedade> propriedades { get; set; }

    }
}
