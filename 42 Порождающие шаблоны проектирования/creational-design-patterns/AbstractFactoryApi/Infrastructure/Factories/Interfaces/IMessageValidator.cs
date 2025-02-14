using AbstractFactoryApi.Infrastructure.Core.Messages;

namespace AbstractFactoryApi.Infrastructure.Factories.Interfaces
{
    public interface IMessageValidator
    {
        Task ValidateMessage(IMessage message);
    }
}
