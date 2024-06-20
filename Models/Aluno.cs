namespace Treinaí.Models
{
    public class Aluno
    {
        public int Id { get; set; }
        public string Nome { get; set; } = null!;
        public string Documento { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Celular { get; set; } = null!;
        public DateTime DataNascimento { get; set; }

        public ICollection<PlanoDeTreino> Planos { get; set; } = new List<PlanoDeTreino>();
    }
}
