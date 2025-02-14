using AbstractFactoryApi.Infrastructure.Core;
using AbstractFactoryApi.Infrastructure.Core.Messages;
using AbstractFactoryApi.Infrastructure.Factories.Builders;
using AbstractFactoryApi.Infrastructure.Factories.Interfaces;

namespace AbstractFactoryApi.Infrastructure.Factories
{
    internal class SmsMessageBuilder : IMessageBuilderAdaptor
    {
        private SmsMessage _message = new();

        public IMessage BuildMessage(NotificationRequest request)
        {
            return new SmsMessageDirector()
                .ConstructMessage(new SmsMessageBuilderImpl(), request)
                .Build();
        }
    }
}