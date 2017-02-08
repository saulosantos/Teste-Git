using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teste.GitHub.Domain.Entidades
{
    public class Usuario
    {
        [Key]
        public int UsuarioId { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR")]
        public string NomeUsuario { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR")]
        public string LoginUser { get; set; }

        [Required(ErrorMessage ="Preencha a senha",AllowEmptyStrings=false)]
        [Display (Name = "Senha")]
        [DataType(DataType.Password)]
        [StringLength(15, MinimumLength = 4, ErrorMessage ="No mínimo 4 caracteres e no máximo 15")]
        public string SenhaUsuario { get; set; }


        [DataType(DataType.Password)]
        [Display(Name = "Confirmar a senha")]
        [Compare("SenhaUsuario", ErrorMessage = "A senhe e a confirmação da senha são diferentes")]
        public string ConfirmaSenha { get; set; }



        public DateTime DataCadastro { get; set; }



        [Required]
        public bool Ativo { get; set; }


        public int TipoUsuarioId { get; set; }
        public virtual TipoUsuario TipoUsuario { get; set; }

    }
}
