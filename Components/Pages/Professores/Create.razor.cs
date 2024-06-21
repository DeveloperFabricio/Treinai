﻿using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using MudBlazor;
using Treinaí.Email.EmailsNotifications;
using Treinaí.Extensions;
using Treinaí.Models;
using Treinaí.Repositories.ProfessorRepository;
using Treinaí.Repositories.TipoDeExercicioRepository;

namespace Treinaí.Components.Pages.Professores
{
        public class CreateProfessorPage : ComponentBase
        {
            [Inject]
            private ITipoDeExercicioRepository TipoDeExercicio { get; set; } = null!;

            [Inject]
            public IProfessorRepository Repository { get; set; } = null!;

            [Inject]
            public ISnackbar Snackbar { get; set; } = null!;

            [Inject]
            public NavigationManager NavigationManager { get; set; } = null!;

            [Inject]
            public EmailNotification Notification { get; set; } = null!;

            public ProfessorInputModel InputModel { get; set; } = new ProfessorInputModel();

            public List<TipoDeExercicio> TiposDeExercicios { get; set; } = new List<TipoDeExercicio>();


            public async Task OnValidSubmitAsync(EditContext editContext)
            {
                try
                {
                    if (editContext.Model is ProfessorInputModel model)
                    {
                        var professor = new Professor
                        {
                            Nome = model.Nome,
                            Documento = model.Documento.SomenteCaracteres(),
                            Celular = model.Celular.SomenteCaracteres(),
                            Cref = model.Cref.SomenteCaracteres(),
                            TipoDeExercicioId = model.TipoDeExercicioId,
                            DataCadastro = model.DataCadastro
                        };

                        await Repository.AddAsync(professor);

                        await Notification.CadastrarProfessor(professor);

                        Snackbar.Add("Professor cadastrado com sucesso!", Severity.Success);
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
                TiposDeExercicios = await TipoDeExercicio.GetAllAsync();
            }
        }
    
}
