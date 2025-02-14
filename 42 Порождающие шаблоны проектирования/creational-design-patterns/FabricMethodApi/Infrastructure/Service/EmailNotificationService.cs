using FabricMethodApi.Infrastructure.Configuration;
using FabricMethodApi.Infrastructure.Core;
using System.ComponentModel.DataAnnotations;

namespace FabricMethodApi.Infrastructure.Service
{
    public class EmailNotificationService : NotificationService
    {
        private readonly EmailSettings _settings;

        public EmailNotificationService(
            ILogger<EmailNotificationService> logger,
            IConfiguration configuration)
            : base(logger, configuration)
        {
            _settings = configuration.GetSection("NotificationSettings:Email").Get<EmailSettings>();
        }

        protected override async Task<NotificationResponse> SendNotificationImpl(NotificationRequest request)
        {
            // Implement actual email sending logic here
            var smtp=_settings.SmtpServer;
            await Task.Delay(100); // Simulated delay
            return new NotificationResponse
            {
                Id = Guid.NewGuid().ToString(),
                Status = "Sent",
                SentAt = DateTime.UtcNow
            };
        }

        protected override Task ValidateNotification(NotificationRequest request)
        {
            base.ValidateNotification(request);
            if (!request.Recipient.Contains("@"))
                throw new ValidationException("Invalid email address");
            return Task.CompletedTask;
        }
    }
}
