using System.ComponentModel.DataAnnotations;

namespace Treinaí.Components.Pages.Alunos
{
    public class AlunoInputModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Nome deve ser fornecido")]
        [MaxLength(50, ErrorMessage = "{0} deve ter no máximo {1} caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Documento deve ser fornecido")]
        public string Documento { get; set; }

        [Required(ErrorMessage = "E-mail deve ser fornecido")]
        [EmailAddress(ErrorMessage = "E-mail inválido")]
        [MaxLength(50, ErrorMessage = "{0} deve ter no máximo {1} caracateres")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Celular deve ser fornecido")]
        public string Celular { get; set; }

        [Required(ErrorMessage = "Data de nascimento deve ser fornecida")]
        public DateTime DataNascimento { get; set; } = DateTime.Today;

    }
}
