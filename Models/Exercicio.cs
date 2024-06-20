namespace Treinaí.Models
{
    public class Exercicio
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int TipoDeExercicioId { get; set; }
        public TipoDeExercicio TipoDeExercicio { get; set; }
        public string Descricao { get; set; } // Descrição do exercício
    }
}
