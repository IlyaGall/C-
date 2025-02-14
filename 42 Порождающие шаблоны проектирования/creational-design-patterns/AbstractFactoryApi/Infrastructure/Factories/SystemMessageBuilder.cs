using AbstractFactoryApi.Infrastructure.Core;
using AbstractFactoryApi.Infrastructure.Core.Messages;
using AbstractFactoryApi.Infrastructure.Factories.Builders;
using AbstractFactoryApi.Infrastructure.Factories.Interfaces;

namespace AbstractFactoryApi.Infrastructure.Factories
{
    public class SystemMessageBuilder : IMessageBuilderAdaptor
    {
        public IMessage BuildMessage(NotificationRequest request)
        {
            return new SystemMessageDirector()
                .ConstructMessage(new SystemMessageBuilderImpl(), request)
                .Build();
        }
    }
}