using Treinaí.Models;
using Treinaí.RabbitMQ;
using Treinaí.Repositories.AlunoRepository;
using Treinaí.Repositories.PlanoDeTreinoRepository;
using Treinaí.Repositories.ProfessorRepository;

namespace Treinaí.Email.EmailsNotifications
{
    public class EmailNotification
    {
        private readonly IEmailService _emailService;
        private readonly IAlunoRepository _alunoRepository;
        private readonly IProfessorRepository _professorRepository;
        private readonly IPlanoDeTreinoRepository _planoDeTreinoRepository;
        private readonly IConfiguration _configuration;
        private readonly IRabbitMQService _rabbitMQService;

        public EmailNotification(IEmailService emailService, 
            IAlunoRepository alunoRepository, 
            IProfessorRepository professorRepository,
            IPlanoDeTreinoRepository planoDeTreinoRepository,
            IConfiguration configuration,
            IRabbitMQService rabbitMQService)
        {
            _emailService = emailService;
            _alunoRepository = alunoRepository;
            _professorRepository = professorRepository;
            _planoDeTreinoRepository = planoDeTreinoRepository;
            _configuration = configuration;
            _rabbitMQService = rabbitMQService;
        }

        public async Task CadastrarAluno(Aluno aluno)
        {
            await _alunoRepository.AddAsync(aluno);

            string emailProfessor = "seu_email_aqui@outlook.com";
            string assunto = "Novo aluno cadastrado";
            string mensagem = $"Olá professor,\n\nUm novo aluno se cadastrou na plataforma: {aluno.Nome} ({aluno.Email}).\n\nAtenciosamente,\nEquipe Treinaí";

            await _emailService.EnviarEmail(emailProfessor, assunto, mensagem);

            _rabbitMQService.Publish($"Novo aluno cadastrado: {aluno.Nome}");
        }

        public async Task DeletarAluno(Aluno aluno)
        {
            await _alunoRepository.DeleteByIdAsync(aluno.Id);

            string emailAluno = "seu_email_aqui@outlook.com";
            string assunto = "Seu perfil foi excluído";
            string mensagem = $"Olá {aluno.Nome},\n\nVocê não faz mais parte do quadro de alunos do TreinaÍ.\n\nAtenciosamente,\nEquipe Treinaí";

            await _emailService.EnviarEmail(emailAluno, assunto, mensagem);

            _rabbitMQService.Publish($"Perfil do aluno excluído: {aluno.Nome}");


        }

        public async Task CadastrarProfessor(Professor professor)
        {
            await _professorRepository.AddAsync(professor);

            string emailProfessor = "seu_email_aqui@outlook.com";
            string assunto = "Novo professor cadastrado";
            string mensagem = $"Olá Gestor,\n\nUm novo professor se cadastrou na plataforma: {professor.Nome}.\n\nAtenciosamente,\nEquipe Treinaí";

            await _emailService.EnviarEmail(emailProfessor, assunto, mensagem);

            _rabbitMQService.Publish($"Novo professor cadastrado: {professor.Nome}");
        }

        public async Task DeletarProfessor(Professor professor)
        {
            await _professorRepository.DeleteByIdAsync(professor.Id);

            string emailProfessor = "seu_email_aqui@outlook.com";
            string assunto = "Seu perfil foi exluído";
            string mensagem = $"Olá {professor.Nome},\n\nVocê não faz mais parte do quadro de professores do TreinaÍ.\n\nAtenciosamente,\nEquipe Treinaí";

            await _emailService.EnviarEmail(emailProfessor, assunto, mensagem);

            _rabbitMQService.Publish($"Perfil do professor excluído: {professor.Nome}");

        }

        public async Task CriarPlanoDeTreino(PlanoDeTreino planoDeTreino)
        {
            await _planoDeTreinoRepository.AddAsync(planoDeTreino);


            string emailAluno = "seu_email_aqui@outlook.com";
            string assunto = "Novo plano de treino criado";
            string mensagem = $"Olá {planoDeTreino.Aluno.Nome},\n\nUm novo plano de treino foi criado para você pelo professor {planoDeTreino.Professor.Nome}.\n\nAtenciosamente,\nEquipe Treinaí";

            await _emailService.EnviarEmail(emailAluno, assunto, mensagem);

            _rabbitMQService.Publish($"Novo plano de treino criado para aluno: {planoDeTreino.Aluno.Nome}");
        }
    }
}
