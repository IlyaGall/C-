namespace AbstractFactoryApi.Infrastructure.Factories.Interfaces
{
    public interface INotificationFactory
    {
        IMessageBuilderAdaptor CreateMessageBuilder();
        IMessageValidator CreateMessageValidator();
        IMessageSender CreateMessageSender();
    }
}
