using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using MudBlazor;
using Treinaí.Email;
using Treinaí.Email.EmailsNotifications;
using Treinaí.Models;
using Treinaí.Repositories.AlunoRepository;
using Treinaí.Repositories.PlanoDeTreinoRepository;
using Treinaí.Repositories.ProfessorRepository;

namespace Treinaí.Components.Pages.PlanoDeTreinos
{
    public class CreatePlanoDeTreinoPage : ComponentBase
    {
        [Inject]
        private IPlanoDeTreinoRepository PlanoRepository { get; set; } = null!;

        [Inject]
        private IProfessorRepository ProfessorRepository { get; set; } = null!;

        [Inject]
        private IAlunoRepository AlunoRepository { get; set; } = null!;

        [Inject]
        private ISnackbar Snackbar { get; set; } = null!;

        [Inject]
        private NavigationManager NavigationManager { get; set; } = null!;

        [Inject]
        private EmailNotification Notification { get; set; }

        public PlanoDeTreinoInputModel InputModel { get; set; } = new PlanoDeTreinoInputModel();

        public List<Professor> Professores { get; set; } = new List<Professor>();
        public List<Aluno> Alunos { get; set; } = new List<Aluno>();

        public TimeSpan? time = new TimeSpan(09, 00, 00);
        public DateTime? date { get; set; } = DateTime.Now.Date;

        public DateTime? MinDate { get; set; } = DateTime.Now.Date;

        public async Task OnValidSubmitAsync(EditContext editContext)
        {
            try
            {
                if (editContext.Model is PlanoDeTreinoInputModel model)
                {
                    var planoDeTreino = new PlanoDeTreino
                    {
                        Observacao = model.Observacao,
                        AlunoId = model.AlunoId,
                        ProfessorId = model.ProfessorId,
                        HoraTreino = time!.Value,
                        DataTreino = date!.Value,
                    };

                    await PlanoRepository.AddAsync(planoDeTreino);

                    Snackbar.Add("Plano de Treino criado com sucesso!", Severity.Success);

                    await Notification.CriarPlanoDeTreino(planoDeTreino);

                    NavigationManager.NavigateTo("/planosdetreinos");
                }
            }
            catch (Exception ex)
            {
                Snackbar.Add(ex.Message, Severity.Error);
            }
        }

        protected override async Task OnInitializedAsync()
        {
            Professores = await ProfessorRepository.GetAllAsync();
            Alunos = await AlunoRepository.GetAllAsync();
        }
    }
}
