namespace Treinaí.Models
{
    public class Professor
    {
        public int Id { get; set; }
        public string Nome { get; set; } = null!;
        public string Documento { get; set; } = null!;
        public string Cref { get; set; } = null!;
        public string Celular { get; set; } = null!;
        public DateTime DataCadastro { get; set; }
        public int TipoDeExercicioId { get; set; }
        public TipoDeExercicio TipoDeExercicio { get; set; } = null!;

        public ICollection<PlanoDeTreino> Planos { get; set; } = new List<PlanoDeTreino>();
    }
}
