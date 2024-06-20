namespace Treinaí.Models
{
    public class TipoDeExercicio
    {
        public int Id { get; set; }
        public string Nome { get; set; } = null!;
        public string? Descricao { get; set; }

        public ICollection<Professor> Professores { get; set; } = new List<Professor>();
    }
}
