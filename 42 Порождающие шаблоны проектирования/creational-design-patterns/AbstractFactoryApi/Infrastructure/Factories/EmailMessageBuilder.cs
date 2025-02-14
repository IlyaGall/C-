using AbstractFactoryApi.Infrastructure.Core;
using AbstractFactoryApi.Infrastructure.Core.Messages;
using AbstractFactoryApi.Infrastructure.Factories.Interfaces;

namespace AbstractFactoryApi.Infrastructure.Factories
{
    public class EmailMessageBuilder : IMessageBuilderAdaptor
    {
        public IMessage BuildMessage(NotificationRequest request)
        {
            return new EmailMessage
            {
                Recipient = request.Recipient,
                Subject = request.Subject ?? "Notification",
                Body = request.Message,
                FromAddress = request.From ?? "noreply@example.com",
                IsHtml = request.IsHtml ?? false
            };
        }
    }
}
