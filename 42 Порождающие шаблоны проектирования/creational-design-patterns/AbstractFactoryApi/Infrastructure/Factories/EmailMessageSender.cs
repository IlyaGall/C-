using AbstractFactoryApi.Infrastructure.Core;
using AbstractFactoryApi.Infrastructure.Core.Messages;
using AbstractFactoryApi.Infrastructure.Factories.Interfaces;

namespace AbstractFactoryApi.Infrastructure.Factories
{
    public class EmailMessageSender : IMessageSender
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<EmailMessageSender> _logger;

        public EmailMessageSender(IConfiguration configuration, ILogger<EmailMessageSender> logger)
        {
            _configuration = configuration;
            _logger = logger;
        }

        public async Task<NotificationResponse> SendMessage(IMessage message)
        {
            var emailMessage = (EmailMessage)message;
            // Implement actual email sending logic here
            await Task.Delay(100); // Simulated delay

            return new NotificationResponse
            {
                Id = emailMessage.Id,
                Status = "Sent",
                SentAt = DateTime.UtcNow,
                Channel = "Email"
            };
        }
    }
}
