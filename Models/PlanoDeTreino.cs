using Treinaí.Data;

namespace Treinaí.Models
{
    public class PlanoDeTreino
    {
        public int Id { get; set; }
        public string? Observacao { get; set; }
        public int AlunoId { get; set; }
        public Aluno Aluno { get; set; }
        public int ProfessorId { get; set; }
        public Professor Professor { get; set; }
        public TimeSpan HoraTreino { get; set; }
        public DateTime DataTreino { get; set; }

    }
}
