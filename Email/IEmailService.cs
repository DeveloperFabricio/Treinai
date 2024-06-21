namespace Treinaí.Email
{
    public interface IEmailService
    {
        Task<bool> EnviarEmail(string toEmail, string subject, string message);
    }
}
