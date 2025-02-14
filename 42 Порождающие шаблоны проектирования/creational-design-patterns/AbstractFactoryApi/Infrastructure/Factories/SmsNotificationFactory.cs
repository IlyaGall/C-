using AbstractFactoryApi.Infrastructure.Factories.Interfaces;

namespace AbstractFactoryApi.Infrastructure.Factories
{
    public class SmsNotificationFactory : INotificationFactory
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<SmsNotificationFactory> _logger;

        public SmsNotificationFactory(IConfiguration configuration, ILogger<SmsNotificationFactory> logger)
        {
            _configuration = configuration;
            _logger = logger;
        }

        public IMessageBuilderAdaptor CreateMessageBuilder() => new SmsMessageBuilder();
        public IMessageValidator CreateMessageValidator() => new SmsMessageValidator();
        public IMessageSender CreateMessageSender() => new SmsMessageSender(_configuration, _logger);
    }
}
