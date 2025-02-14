using AbstractFactoryApi.Infrastructure.Configuration;
using AbstractFactoryApi.Infrastructure.Core;
using AbstractFactoryApi.Infrastructure.Core.Messages;
using AbstractFactoryApi.Infrastructure.Factories.Interfaces;

namespace AbstractFactoryApi.Infrastructure.Factories
{
    public class SystemMessageSender : IMessageSender
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger _logger;

        public SystemMessageSender(IConfiguration configuration, ILogger logger)
        {
            _configuration = configuration;
            _logger = logger;
        }

        public async Task<NotificationResponse> SendMessage(IMessage message)
        {
            var systemMessage = (SystemMessage)message;
            try
            {
                // Get system notification configuration
                var systemConfig = _configuration.GetSection("NotificationSettings:System").Get<SystemSettings>();

                _logger.LogInformation(
                    "Sending system notification to {Recipient} with severity {Severity}",
                    systemMessage.Recipient,
                    systemMessage.Severity);

                // Simulate system notification delay
                await Task.Delay(100);

                // Here you would typically integrate with your system notification service
                // Example:
                // await _notificationHub.SendAsync(
                //     systemMessage.Recipient,
                //     systemMessage.Title,
                //     systemMessage.Content,
                //     systemMessage.Severity);

                return new NotificationResponse
                {
                    Id = systemMessage.Id,
                    Status = "Sent",
                    SentAt = DateTime.UtcNow,
                    Channel = "System",
                    AdditionalInfo = new Dictionary<string, string>
                {
                    { "severity", systemMessage.Severity },
                    { "requireAcknowledgement", systemMessage.RequireAcknowledgement.ToString() }
                }
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to send system notification to {Recipient}", systemMessage.Recipient);
                throw;
            }
        }
    }
}