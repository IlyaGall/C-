namespace AbstractFactoryApi.Infrastructure.Core.Messages
{
    public class EmailMessage : IMessage
    {
        public string Id { get; } = Guid.NewGuid().ToString();
        public string Recipient { get; set; }
        public DateTime CreatedAt { get; } = DateTime.UtcNow;
        public string Subject { get; set; }
        public string Body { get; set; }
        public string FromAddress { get; set; }
        public bool IsHtml { get; set; }
        public List<string> Attachments { get; set; } = new();
    }
}
