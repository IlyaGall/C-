using FabricMethodApi.Infrastructure.Configuration;
using FabricMethodApi.Infrastructure.Core;

namespace FabricMethodApi.Infrastructure.Service
{
    public class SystemNotificationService : NotificationService
    {
        private readonly SystemSettings _settings;

        public SystemNotificationService(
            ILogger<SystemNotificationService> logger,
            IConfiguration configuration)
            : base(logger, configuration)
        {
            _settings = configuration.GetSection("NotificationSettings:System").Get<SystemSettings>();
        }

        protected override async Task<NotificationResponse> SendNotificationImpl(NotificationRequest request)
        {
            // Implement actual System notification sending logic here
            await Task.Delay(100); // Simulated delay
            return new NotificationResponse
            {
                Id = Guid.NewGuid().ToString(),
                Status = "Sent",
                SentAt = DateTime.UtcNow
            };
        }

    }

}
