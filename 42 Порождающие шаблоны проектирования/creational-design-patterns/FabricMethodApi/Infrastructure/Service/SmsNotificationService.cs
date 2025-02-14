using FabricMethodApi.Infrastructure.Configuration;
using FabricMethodApi.Infrastructure.Core;
using System.ComponentModel.DataAnnotations;

namespace FabricMethodApi.Infrastructure.Service
{
    public class SmsNotificationService : NotificationService
    {
        private readonly SmsSettings _settings;

        public SmsNotificationService(
            ILogger<SmsNotificationService> logger,
            IConfiguration configuration)
            : base(logger, configuration)
        {
            _settings = configuration.GetSection("NotificationSettings:Sms").Get<SmsSettings>();
        }

        protected override async Task<NotificationResponse> SendNotificationImpl(NotificationRequest request)
        {
            // Implement actual SMS sending logic here
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
            if (!request.Recipient.All(char.IsDigit))
                throw new ArgumentException("Phone number must contain only digits");
            return Task.CompletedTask;
        }
    }     
}
