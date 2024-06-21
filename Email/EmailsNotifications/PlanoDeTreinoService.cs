using Treinaí.Models;
using Treinaí.Repositories.PlanoDeTreinoRepository;

namespace Treinaí.Email.EmailsNotifications
{
    public class PlanoDeTreinoService
    {
        private readonly IPlanoDeTreinoRepository _planoDeTreinoRepository;
        private readonly IEmailService _emailService;

        public PlanoDeTreinoService(IPlanoDeTreinoRepository planoDeTreinoRepository, IEmailService emailService)
        {
            _planoDeTreinoRepository = planoDeTreinoRepository;
            _emailService = emailService;
        }

        public async Task CriarPlanoDeTreino(PlanoDeTreino planoDeTreino)
        {
            await _planoDeTreinoRepository.AddAsync(planoDeTreino);

            
            string emailAluno = "fabricio_dev@outlook.com"; 
            string assunto = "Novo plano de treino criado";
            string mensagem = $"Olá {planoDeTreino.Aluno.Nome},\n\nUm novo plano de treino foi criado para você pelo professor {planoDeTreino.Professor.Nome}.\n\nAtenciosamente,\nEquipe Treinaí";

            await _emailService.EnviarEmail(emailAluno, assunto, mensagem);
        }
    }
}
