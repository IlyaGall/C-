using AbstractFactoryApi.Infrastructure.Core;
using AbstractFactoryApi.Infrastructure.Core.Messages;

namespace AbstractFactoryApi.Infrastructure.Factories.Interfaces
{
    public interface IMessageSender
    {
        Task<NotificationResponse> SendMessage(IMessage message);
    }
}
