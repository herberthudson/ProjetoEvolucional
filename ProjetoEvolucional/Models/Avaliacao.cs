using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoEvolucional.Models
{
    [Table(nameof(Avaliacao))]
    public class Avaliacao : Entity
    {

        public int AlunoId { get; set; }

        [ForeignKey(nameof(AlunoId))]
        public Aluno Aluno { get; set; }

        public int DisciplinaId { get; set; }

        [ForeignKey(nameof(DisciplinaId))]
        public Disciplina Disciplina { get; set; }


        public decimal Nota { get; set; } = 0;
    }
}
