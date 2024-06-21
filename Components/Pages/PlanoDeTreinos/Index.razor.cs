using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using MudBlazor;
using Treinaí.Models;
using Treinaí.Repositories.PlanoDeTreinoRepository;

namespace Treinaí.Components.Pages.PlanoDeTreinos
{
    public class IndexPlanoDeTreinoPage : ComponentBase
    {
        [Inject]
        private IPlanoDeTreinoRepository PlanoRepository { get; set; } = null!;

        [Inject]
        public IDialogService Dialog { get; set; } = null!;

        [Inject]
        public ISnackbar Snackbar { get; set; } = null!;

        public List<PlanoDeTreino> PlanosDeTreinos { get; set; } = new List<PlanoDeTreino>();

        public bool HideButtons { get; set; }

        [CascadingParameter]
        private Task<AuthenticationState> AuthenticationState { get; set; }

        public async Task DeletePlanoDeTreino(PlanoDeTreino planoDeTreino)
        {
            try
            {
                var result = await Dialog.ShowMessageBox(
                    "Atenção",
                    "Deseja exluir o Plano de Treino?",
                    yesText: "SIM",
                    cancelText: "NÂO"
                );

                if (result is true)
                {
                    await PlanoRepository.DeleteByIdAsync(planoDeTreino.Id);
                    Snackbar.Add("Plano de Treino exluído com sucesso!", Severity.Success);
                    await OnInitializedAsync();
                }
            }
            catch (Exception ex)
            {
                Snackbar.Add(ex.Message, Severity.Error);
            }

        }

        protected override async Task OnInitializedAsync()
        {
            var auth = await AuthenticationState;

            HideButtons = !auth.User.IsInRole("Gestor");

            PlanosDeTreinos = await PlanoRepository.GetAllAsync();
        }
    }
}

