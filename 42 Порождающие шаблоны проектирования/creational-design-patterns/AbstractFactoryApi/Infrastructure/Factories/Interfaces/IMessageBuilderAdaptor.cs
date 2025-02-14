using AbstractFactoryApi.Infrastructure.Core;
using AbstractFactoryApi.Infrastructure.Core.Messages;

namespace AbstractFactoryApi.Infrastructure.Factories.Interfaces
{
    public interface IMessageBuilderAdaptor
    {
        IMessage BuildMessage(NotificationRequest request);
    }
}
