namespace AbstractFactoryApi.Infrastructure.Core
{
    public class NotificationResponse
    {
        public string Id { get; set; }
        public string Status { get; set; }
        public DateTime SentAt { get; set; }
        public string Channel { get; set; }
        public Dictionary<string,string> AdditionalInfo { get; set; } = new();
        public override string ToString()
        {
            return $"{Id}-{Channel}-{Status}-{SentAt}";
        }
    }
}
