using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using MudBlazor;
using Treinaí.Email.EmailsNotifications;
using Treinaí.Models;
using Treinaí.Repositories.AlunoRepository;

namespace Treinaí.Components.Pages.Alunos
{
    public class IndexPage : ComponentBase
    {
        [Inject]
        public IAlunoRepository Repository { get; set; } = null!;

        [Inject]
        public IDialogService Dialog { get; set; } = null!;

        [Inject]
        public ISnackbar Snackbar { get; set; } = null!;

        [Inject]
        public NavigationManager NavigationManager { get; set; } = null!;

        [Inject]
        public EmailNotification Notification { get; set; } = null!;

        public List<Aluno> Alunos { get; set; } = new List<Aluno>();

        public bool HideButtons { get; set; }

        [CascadingParameter]
        private Task<AuthenticationState> AuthenticationState { get; set; }

        public async Task DeletePaciente(Aluno aluno)
        {
            try
            {
                var result = await Dialog.ShowMessageBox(

                    "Atenção",
                    $"Deseja excluir o aluno {aluno.Nome}?",
                    yesText: "SIM",
                    cancelText: "NÃO"
                );

                if (result is true)
                {
                    await Repository.DeleteByIdAsync(aluno.Id);

                    await Notification.DeletarAluno(aluno);

                    Snackbar.Add($"Aluno {aluno.Nome} excluído com sucesso!", Severity.Success);
                    await OnInitializedAsync();
                }
            }
            catch (Exception ex)
            {
                Snackbar.Add(ex.Message, Severity.Error);
            }
        }

        public void GoToUpdate(int id)
        {
            NavigationManager.NavigateTo($"/alunos/update/{id}");
        }
        protected override async Task OnInitializedAsync()
        {
            var auth = await AuthenticationState;

            HideButtons = !auth.User.IsInRole("Gestor");
            Alunos = await Repository.GetAllAsync();
        }
    }
}

