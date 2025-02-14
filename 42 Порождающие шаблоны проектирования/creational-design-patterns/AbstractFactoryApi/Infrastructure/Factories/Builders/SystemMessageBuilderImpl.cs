using AbstractFactoryApi.Infrastructure.Core.Messages;

namespace AbstractFactoryApi.Infrastructure.Factories.Builders
{
    public class SystemMessageBuilderImpl
    {
        private readonly SystemMessage _message = new();

        public SystemMessageBuilderImpl WithRecipient(string recipient)
        {
            _message.Recipient = recipient;
            return this;
        }

        public SystemMessageBuilderImpl WithTitle(string title)
        {
            _message.Title = title;
            return this;
        }

        public SystemMessageBuilderImpl WithContent(string content)
        {
            _message.Content = content;
            return this;
        }

        public SystemMessageBuilderImpl WithSeverity(string severity)
        {
            _message.Severity = severity;
            return this;
        }

        public SystemMessageBuilderImpl WithAcknowledgementRequired(bool requireAcknowledgement)
        {
            _message.RequireAcknowledgement = requireAcknowledgement;
            return this;
        }

        public SystemMessage Build()
        {
            return _message;
        }
    }
}
