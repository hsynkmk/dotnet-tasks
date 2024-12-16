namespace Library.Application.Interfaces.Repositories
{
    public interface IEmailService
    {
        Task SendEmailAsync(string to, string subject, string body);
    }
}
