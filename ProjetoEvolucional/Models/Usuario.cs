using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoEvolucional.Models
{
    [Table(nameof(Usuario))]
    public class Usuario: Entity
    {
        [Column(TypeName = "varchar(100)")]
        public string Nome { get; set; }

        [Column(TypeName = "varchar(100)")]
        [Required]
        public string Login { get; set; }

        [Column(TypeName = "varchar(100)")]
        [Required]
        public string Senha { get; set; }
    }
}
