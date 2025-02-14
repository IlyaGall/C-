namespace AbstractFactoryApi.Infrastructure.Core.Messages
{
    public class SmsMessage : IMessage
    {
        public string Id { get; } = Guid.NewGuid().ToString();
        public string Recipient { get; set; }
        public DateTime CreatedAt { get; } = DateTime.UtcNow;
        public string Content { get; set; }
        public string SenderNumber { get; set; }
        public bool RequireDeliveryReport { get; set; }
    }
}
