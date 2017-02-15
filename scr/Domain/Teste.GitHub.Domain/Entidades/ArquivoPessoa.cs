using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teste.GitHub.Domain.Entidades
{
    public class ArquivoPessoa
    {

        [Key]
        public int ArquivoPessoaId { get; set; }

        [Required(ErrorMessage ="Preencha o caminho")]
        [Column(TypeName = "VARCHAR")]
        [MaxLength(100, ErrorMessage = "No máximo 100 caracteres")]
        public string ArquivoCaminho { get; set; }

        [Column(TypeName = "VARCHAR")]
        [MaxLength(5, ErrorMessage = "No máximo 5 caracteres")]
        public string extencao { get; set; }

        [Required(ErrorMessage = "Data Obrigatoria")]
        public DateTime DataCadastro { get; set; }

        [Required(ErrorMessage = "Informe se o arquivo e ativo")]
        public bool Ativo { get; set; }

        public int PessoaId { get; set; }



        public virtual Pessoa Pessoa { get; set; }

    }
}
