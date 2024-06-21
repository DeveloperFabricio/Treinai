using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using MudBlazor;
using Treinaí.Extensions;
using Treinaí.Models;
using Treinaí.Repositories.ProfessorRepository;
using Treinaí.Repositories.TipoDeExercicioRepository;

namespace Treinaí.Components.Pages.Professores
{
    public class UpdateProfessorPage : ComponentBase
    {
        [Parameter]
        public int ProfessorId { get; set; }

        [Inject]
        private ITipoDeExercicioRepository Repository { get; set; } = null!;

        [Inject]
        public IProfessorRepository professorRepository { get; set; } = null!;

        [Inject]
        public ISnackbar Snackbar { get; set; } = null!;

        [Inject]
        public NavigationManager NavigationManager { get; set; } = null!;

        public Professor? CurrentProfessor { get; set; }
        public ProfessorInputModel InputModel { get; set; } = new ProfessorInputModel();
        public List<TipoDeExercicio> TiposDeExercicios { get; set; } = new List<TipoDeExercicio>();

        public async Task OnValidSubmitAsync(EditContext editContext)
        {
            try
            {
                if (CurrentProfessor == null) return;

                if (editContext.Model is ProfessorInputModel model)
                {
                    CurrentProfessor.Id = model.Id;
                    CurrentProfessor.Nome = model.Nome;
                    CurrentProfessor.Documento = model.Documento.SomenteCaracteres();
                    CurrentProfessor.Cref = model.Cref.SomenteCaracteres();
                    CurrentProfessor.Celular = model.Celular.SomenteCaracteres();
                    CurrentProfessor.TipoDeExercicioId = model.TipoDeExercicioId;

                    await professorRepository.UpdateAsync(CurrentProfessor);
                    Snackbar.Add("Professor atualizado com sucesso!", Severity.Success);
                    NavigationManager.NavigateTo("/professores");

                }
            }
            catch (Exception ex)
            {
                Snackbar.Add(ex.Message, Severity.Error);
            }

        }

        protected override async Task OnInitializedAsync()
        {
            CurrentProfessor = await professorRepository.GetByIdAsync(ProfessorId);
            TiposDeExercicios = await Repository.GetAllAsync();

            if (CurrentProfessor is null) return;

            InputModel = new ProfessorInputModel
            {
                Nome = CurrentProfessor.Nome,
                Documento = CurrentProfessor.Documento,
                Cref = CurrentProfessor.Cref,
                Celular = CurrentProfessor.Celular,
                TipoDeExercicioId = CurrentProfessor.TipoDeExercicioId,

            };
        }
    }
}
