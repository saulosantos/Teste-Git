using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teste.GitHub.Domain.Entidades
{
    public class TipoUsuario
    {
        [Key]
        public int TipoUsuarioId { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR")]
        public string NomeTipoUsuario { get; set; }

        public bool Ativo { get; set; }


    }
}
