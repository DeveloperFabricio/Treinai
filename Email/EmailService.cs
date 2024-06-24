
using System.Net.Mail;
using System.Net;
using Treinaí.Components.Account.Pages.Manage;
using Treinaí.RabbitMQ;

namespace Treinaí.Email
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _configuration;
        private readonly IRabbitMQService _rabbitmqService;
        private readonly ILogger<EmailService> _logger;

        public EmailService(IConfiguration configuration, IRabbitMQService rabbitMQService, ILogger<EmailService> logger)
        {
            _configuration = configuration;
            _rabbitmqService = rabbitMQService;
            _logger = logger;
        }

        public async Task<bool> EnviarEmail(string email, string assunto, string messagem)
        {
            try
            {
                string host = _configuration.GetValue<string>("SMTP:Host");
                string nome = _configuration.GetValue<string>("SMTP:Nome");
                string username = _configuration.GetValue<string>("SMTP:UserName");
                string senha = _configuration.GetValue<string>("SMTP:Senha");
                int porta = _configuration.GetValue<int>("SMTP:Porta");

                MailMessage mail = new MailMessage()
                {
                    From = new MailAddress(username, nome)
                };

                mail.To.Add(email);
                mail.Subject = assunto;
                mail.Body = messagem;
                mail.IsBodyHtml = true;
                mail.Priority = MailPriority.High;

                using (SmtpClient smtp = new SmtpClient(host, porta))
                {
                    smtp.Credentials = new NetworkCredential(username, senha);
                    smtp.EnableSsl = true;

                    _logger.LogInformation("Sending email to {Email} with subject {Assunto}", email, assunto);
                    smtp.Send(mail);

                    string rabbitMessage = $"Email enviado para {email} com o assunto: {assunto}";
                    _rabbitmqService.Publish(rabbitMessage);
                    _logger.LogInformation("Published message to RabbitMQ: {RabbitMessage}", rabbitMessage);

                    return true;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to send email to {Email} with subject {Assunto}", email, assunto);
                return false;
            }
        }
    }
}
