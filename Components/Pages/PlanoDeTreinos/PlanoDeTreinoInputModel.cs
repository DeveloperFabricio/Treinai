using System.ComponentModel.DataAnnotations;

namespace Treinaí.Components.Pages.PlanoDeTreinos
{
    public class PlanoDeTreinoInputModel
    {
        [MaxLength(250, ErrorMessage = "O campo {0} deve ter no máximo {1} caracteres")]
        public string? Observacao { get; set; }

        [Required(ErrorMessage = "{0} deve ser fornecido")]
        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "Valor fornecido é inválido!")]
        public int AlunoId { get; set; }

        [Required(ErrorMessage = "{0} deve ser fornecido")]
        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "Valor fornecido é inválido!")]
        public int ProfessorId { get; set; }

        [Required(ErrorMessage = "{0} deve ser fornecido")]
        public TimeSpan HoraTreino { get; set; }

        [Required(ErrorMessage = "{0} deve ser fornecido")]
        public DateTime DataTreino { get; set; }
    }
}
