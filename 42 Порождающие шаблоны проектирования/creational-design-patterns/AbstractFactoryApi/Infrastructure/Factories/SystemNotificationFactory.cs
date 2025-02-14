using AbstractFactoryApi.Infrastructure.Factories.Interfaces;

namespace AbstractFactoryApi.Infrastructure.Factories
{
    public class SystemNotificationFactory : INotificationFactory
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<SystemNotificationFactory> _logger;

        public SystemNotificationFactory(IConfiguration configuration, ILogger<SystemNotificationFactory> logger)
        {
            _configuration = configuration;
            _logger = logger;
        }

        public IMessageBuilderAdaptor CreateMessageBuilder() => new SystemMessageBuilder();
        public IMessageValidator CreateMessageValidator() => new SystemMessageValidator();
        public IMessageSender CreateMessageSender() => new SystemMessageSender(_configuration, _logger);
    }
}
