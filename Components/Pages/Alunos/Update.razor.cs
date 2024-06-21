using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using MudBlazor;
using Treinaí.Extensions;
using Treinaí.Models;
using Treinaí.Repositories.AlunoRepository;

namespace Treinaí.Components.Pages.Alunos
{
    public class UpdateAluno : ComponentBase
    {
        [Parameter]
        public int AlunoId { get; set; }

        [Inject]
        public IAlunoRepository Repository { get; set; } = null!;

        [Inject]
        public ISnackbar Snackbar { get; set; } = null!;

        [Inject]
        public NavigationManager NavigationManager { get; set; } = null!;

        public AlunoInputModel InputModel { get; set; } = new AlunoInputModel();
        private Aluno? CurrentAluno { get; set; }
        public DateTime? DataNascimento { get; set; } = DateTime.Today;
        public DateTime? Maxdate { get; set; } = DateTime.Today;

        protected override async Task OnInitializedAsync()
        {
            CurrentAluno = await Repository.GetByIdAsync(AlunoId);

            if (CurrentAluno is null)
                return;

            InputModel = new AlunoInputModel
            {
                Id = CurrentAluno.Id,
                Nome = CurrentAluno.Nome,
                Celular = CurrentAluno.Celular,
                DataNascimento = CurrentAluno.DataNascimento,
                Email = CurrentAluno.Email,
                Documento = CurrentAluno.Documento,
            };

            DataNascimento = CurrentAluno.DataNascimento;
        }

        public async Task OnValidSubmitAsync(EditContext editContext)
        {
            try
            {
                if (editContext.Model is AlunoInputModel model)
                {
                    CurrentAluno.Nome = model.Nome;
                    CurrentAluno.Documento = model.Documento.SomenteCaracteres();
                    CurrentAluno.Celular = model.Celular.SomenteCaracteres();
                    CurrentAluno.Email = model.Email;
                    CurrentAluno.DataNascimento = DataNascimento.Value;

                    await Repository.UpdateAsync(CurrentAluno);

                    Snackbar.Add($"Aluno {CurrentAluno.Nome} atualizado com sucesso!", Severity.Success);
                    NavigationManager.NavigateTo("/alunos");

                }
            }
            catch (Exception ex)
            {
                Snackbar.Add(ex.Message, Severity.Error);
            }

        }
    }
}

