using AbstractFactoryApi.Infrastructure.Core.Messages;

namespace AbstractFactoryApi.Infrastructure.Factories.Builders
{
    public class SmsMessageBuilderImpl
    {
        private readonly SmsMessage _message = new();

        public SmsMessageBuilderImpl WithRecipient(string recipient)
        {
            _message.Recipient = recipient.StartsWith("+") ? recipient : $"+{recipient}";
            return this;
        }

        public SmsMessageBuilderImpl WithContent(string content)
        {
            _message.Content = content;
            return this;
        }

        public SmsMessageBuilderImpl WithSenderNumber(string senderNumber)
        {
            _message.SenderNumber = senderNumber;
            return this;
        }

        public SmsMessageBuilderImpl WithDeliveryReport(bool requireDeliveryReport)
        {
            _message.RequireDeliveryReport = requireDeliveryReport;
            return this;
        }

        public SmsMessage Build()
        {
            return _message;
        }
    }
}
