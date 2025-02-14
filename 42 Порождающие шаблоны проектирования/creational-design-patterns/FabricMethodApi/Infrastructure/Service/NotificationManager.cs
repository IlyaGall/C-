using FabricMethodApi.Infrastructure.Core;

namespace FabricMethodApi.Infrastructure.Service
{
    public class NotificationManager
    {
        private readonly Dictionary<string, NotificationService> _services;

        public NotificationManager(EmailNotificationService emailNotificationService, 
                                   SmsNotificationService smsNotificationService,
                                   SystemNotificationService systemNotificationService)
        {
            _services = new Dictionary<string, NotificationService>
        {
            { "email", emailNotificationService },
            { "sms", smsNotificationService },
            { "system", systemNotificationService }
        };
        }

        public async Task<NotificationResponse> SendNotificationAsync(string channel, NotificationRequest notification)
        {
            if (!_services.ContainsKey(channel.ToLower()))
            {
                throw new ArgumentException($"Unsupported notification channel: {channel}");
            }

            return await _services[channel.ToLower()].SendNotificationAsync(notification);
        }
    }
}
