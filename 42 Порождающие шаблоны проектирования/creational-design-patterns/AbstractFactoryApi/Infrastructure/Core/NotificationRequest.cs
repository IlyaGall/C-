namespace AbstractFactoryApi.Infrastructure.Core
{
    public class NotificationRequest
    {
        public string Message { get; set; }
        public string Recipient { get; set; }
        public string? Subject { get; set; }
        public string? From { get; set; }
        public bool? IsHtml { get; set; }
        public Dictionary<string, string> AdditionalData { get; set; } = new();
    }
}
