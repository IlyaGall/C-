using AbstractFactoryApi.Infrastructure.Factories.Interfaces;

namespace AbstractFactoryApi.Infrastructure.Factories
{
    public class EmailNotificationFactory : INotificationFactory
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<EmailNotificationFactory> _logger;
        private readonly EmailMessageSender _emailMessageSender;

        public EmailNotificationFactory(IConfiguration configuration, ILogger<EmailNotificationFactory> logger, EmailMessageSender emailMessageSender)
        {
            _configuration = configuration;
            _logger = logger;
            _emailMessageSender = emailMessageSender;
        }

        public IMessageBuilderAdaptor CreateMessageBuilder() => new EmailMessageBuilder();
        public IMessageValidator CreateMessageValidator() => new EmailMessageValidator();
        public IMessageSender CreateMessageSender() => _emailMessageSender;
    }
}
