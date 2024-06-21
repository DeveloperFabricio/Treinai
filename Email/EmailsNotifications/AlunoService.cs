using Treinaí.Models;
using Treinaí.Repositories.AlunoRepository;

namespace Treinaí.Email.EmailsNotifications
{
    public class AlunoService
    {
        private readonly IAlunoRepository _alunoRepository;
        private readonly IEmailService _emailService;

        public AlunoService(IAlunoRepository alunoRepository, IEmailService emailService)
        {
            _alunoRepository = alunoRepository;
            _emailService = emailService;
        }

        public async Task CadastrarAluno(Aluno aluno)
        {
            await _alunoRepository.AddAsync(aluno);

            string emailProfessor = "fabricio_dev@outlook.com"; 
            string assunto = "Novo aluno cadastrado";
            string mensagem = $"Olá professor,\n\nUm novo aluno se cadastrou na plataforma: {aluno.Nome} ({aluno.Email}).\n\nAtenciosamente,\nEquipe Treinaí";

            await _emailService.EnviarEmail(emailProfessor, assunto, mensagem);
        }
    }
}
