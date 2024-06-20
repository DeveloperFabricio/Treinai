namespace Treinaí.Models
{
    public class DiaDeTreino
    {
        public int Id { get; set; }
        public int PlanoDeTreinoId { get; set; }
        public PlanoDeTreino PlanoDeTreino { get; set; }
        public DateTime Data { get; set; }
        public ICollection<SerieDeExercicio> SeriesDeExercicio { get; set; }
    }
}
