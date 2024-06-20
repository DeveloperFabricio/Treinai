namespace Treinaí.Models
{
    public class SerieDeExercicio
    {
        public int Id { get; set; }
        public int DiaDeTreinoId { get; set; }
        public DiaDeTreino DiaDeTreino { get; set; }
        public int ExercicioId { get; set; }
        public Exercicio Exercicio { get; set; }
        public int Repeticoes { get; set; }
        public int Series { get; set; }
    }
}
