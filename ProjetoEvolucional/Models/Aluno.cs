using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoEvolucional.Models
{
    [Table(nameof(Aluno))]
    public class Aluno : Entity
    {

        [Column(TypeName = "varchar(100)")]
        [Required]
        public string Nome { get; set; }

        public decimal Media { get; set; }

        public IList<Avaliacao> Notas { get; set; } = new List<Avaliacao>();
    }
}
