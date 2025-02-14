namespace AbstractFactoryApi.Infrastructure.Core.Messages
{
    public class SystemMessage : IMessage
    {
        public string Id { get; } = Guid.NewGuid().ToString();
        public string Recipient { get; set; }
        public DateTime CreatedAt { get; } = DateTime.UtcNow;
        public string Title { get; set; }
        public string Content { get; set; }
        public string Severity { get; set; }
        public bool RequireAcknowledgement { get; set; }
    }
}
