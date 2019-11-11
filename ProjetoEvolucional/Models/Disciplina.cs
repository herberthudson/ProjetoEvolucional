using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoEvolucional.Models
{
    [Table(nameof(Disciplina))]
    public class Disciplina : Entity
    {
        
        [Column(TypeName ="varchar(100)")]
        [Required]
        public string Titulo { get; set; }

        public IList<Avaliacao> Notas { get; set; } = new List<Avaliacao>();
    }
}
