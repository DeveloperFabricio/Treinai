using System.ComponentModel.DataAnnotations;

namespace Treinaí.Components.Pages.Professores
{
    public class ProfessorInputModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} deve ser fornecido")]
        [MaxLength(50, ErrorMessage = "{0} deve conter no máximo {1} caracteres")]
        public string Nome { get; set; } = null!;

        [Required(ErrorMessage = "{0} deve ser fornecido")]
        public string Documento { get; set; } = null!;

        [Required(ErrorMessage = "{0} deve ser fornecido")]
        public string Cref { get; set; } = null!;
        public string Celular { get; set; } = null!;

        [Required(ErrorMessage = "{0} deve ser fornecido")]
        [RegularExpression("([1-9] [0-9] *)", ErrorMessage = "Valor selecionado inválido!")]
        public DateTime DataCadastro { get; set; } = DateTime.Now;
        public int TipoDeExercicioId { get; set; }
    }
}
