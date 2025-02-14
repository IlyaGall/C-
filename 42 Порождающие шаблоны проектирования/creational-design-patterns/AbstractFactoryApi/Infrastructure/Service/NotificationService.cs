using AbstractFactoryApi.Infrastructure.Core;
using AbstractFactoryApi.Infrastructure.Factories.Interfaces;

namespace AbstractFactoryApi.Infrastructure.Service
{
    public class NotificationService
    {
        private readonly IDictionary<string, INotificationFactory> _factories;
        private readonly ILogger<NotificationService> _logger;

        public NotificationService(
            IEnumerable<INotificationFactory> factories,
            ILogger<NotificationService> logger)
        {
            _factories = factories.ToDictionary(f => f.GetType().Name.Replace("NotificationFactory", "").ToLower());
            _logger = logger;
        }

        public async Task<NotificationResponse> SendNotificationAsync(string channel, NotificationRequest request)
        {
            try
            {
                if (!_factories.TryGetValue(channel.ToLower(), out var factory))
                {
                    throw new ArgumentException($"Unsupported notification channel: {channel}");
                }

                var builder = factory.CreateMessageBuilder();
                var validator = factory.CreateMessageValidator();
                var sender = factory.CreateMessageSender();

                var message = builder.BuildMessage(request);
                await validator.ValidateMessage(message);
                return await sender.SendMessage(message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error sending notification through channel {Channel}", channel);
                throw;
            }
        }
    }

}
