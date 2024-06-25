using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using MudBlazor;
using Treinaí.Email;
using Treinaí.Email.EmailsNotifications;
using Treinaí.Extensions;
using Treinaí.Models;
using Treinaí.Repositories.AlunoRepository;

namespace Treinaí.Components.Pages.Alunos
{
    public class CreateAlunoPage : ComponentBase
    {
        [Inject]
        public IAlunoRepository Repository { get; set; } = null!;

        [Inject]
        public NavigationManager NavigationManager { get; set; } = null!;

        [Inject]
        public ISnackbar Snackbar { get; set; } = null!;

        [Inject]
        public EmailNotification Notification { get; set; } = null!;

        public AlunoInputModel InputModel { get; set; } = new AlunoInputModel();

        public DateTime? DataNascimento { get; set; } = DateTime.Today;

        public DateTime? MaxDate {  get; set; } = DateTime.Today;

        public async Task OnValidSubmitAsync(EditContext editContext)
        {
            try
            {
                if (editContext.Model is AlunoInputModel inputModel)
                {
                    var aluno = new Aluno
                    {
                        Nome = inputModel.Nome,
                        Documento = inputModel.Documento.SomenteCaracteres(),
                        Celular = inputModel.Celular.SomenteCaracteres(),
                        Email = inputModel.Email,
                        DataNascimento = inputModel.DataNascimento,
                    };

                    await Repository.AddAsync(aluno);

                    Snackbar.Add("Aluno cadastrado com sucesso!", Severity.Success);

                    await Notification.CadastrarAluno(aluno);
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
