using Library.Application.Interfaces.Repositories;
using Microsoft.Extensions.Logging;

namespace Library.Infrastructure.Services
{
    public class EmailService : IEmailService
    {
        private readonly ILogger<EmailService> _logger;

        public EmailService(ILogger<EmailService> logger)
        {
            _logger = logger;
        }

        public Task SendEmailAsync(string to, string subject, string body)
        {
            // Log instead of sending for demonstration
            _logger.LogInformation($"Email sent to {to} with subject {subject}.");
            return Task.CompletedTask;
        }
    }

}
