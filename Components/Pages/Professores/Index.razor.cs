using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using MudBlazor;
using Treinaí.Email.EmailsNotifications;
using Treinaí.Models;
using Treinaí.Repositories.ProfessorRepository;

namespace Treinaí.Components.Pages.Professores
{
    public class IndexProfessorPage : ComponentBase
    {
        [Inject]
        public IProfessorRepository Repository { get; set; } = null!;

        [Inject]
        public IDialogService Dialog { get; set; } = null!;

        [Inject]
        public ISnackbar Snackbar { get; set; } = null!;

        [Inject]
        public NavigationManager NavigationManager { get; set; } = null!;

        [Inject]
        public EmailNotification Notification { get; set; } 
        public List<Professor> Professores { get; set; } = new List<Professor>();

        public async Task DeleteProfessorAsync(Professor professor)
        {
            try
            {
                var result = await Dialog.ShowMessageBox(

                    "Atenção",
                    $"Deseja excluir o professor {professor.Nome}?",
                    yesText: "SIM",
                    cancelText: "NÂO"
                );

                if (result is true)
                {
                    await Repository.DeleteByIdAsync(professor.Id);

                    Snackbar.Add("Professor excluído com sucesso!", Severity.Success);

                    await Notification.DeletarProfessor(professor);

                    await OnInitializedAsync();
                }
            }
            catch (Exception ex)
            {
                Snackbar.Add(ex.Message, Severity.Error);
            };
        }

        public bool HideButtons { get; set; }

        [CascadingParameter]
        private Task<AuthenticationState> AuthenticationState { get; set; }

        public void GoToUpdate(int id)

            => NavigationManager.NavigateTo($"/professores/update/{id}");

        protected override async Task OnInitializedAsync()
        {
            var auth = await AuthenticationState;

            HideButtons = !auth.User.IsInRole("Gestor");

            Professores = await Repository.GetAllAsync();
        }
    }
}
