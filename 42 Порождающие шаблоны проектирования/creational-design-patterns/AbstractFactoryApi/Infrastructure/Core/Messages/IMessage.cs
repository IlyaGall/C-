namespace AbstractFactoryApi.Infrastructure.Core.Messages
{
    public interface IMessage
    {
        string Id { get; }
        string Recipient { get; }
        DateTime CreatedAt { get; }
    }
}
