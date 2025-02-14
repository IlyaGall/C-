namespace AbstractFactoryApi.Infrastructure.Configuration
{
    public class NotificationSettings
    {
        public EmailSettings Email { get; set; }
        public SmsSettings Sms { get; set; }
        public SystemSettings System { get; set; }
    }
}
