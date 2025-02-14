using AbstractFactoryApi.Infrastructure.Core;

namespace AbstractFactoryApi.Infrastructure.Factories.Builders
{
    public class SmsMessageDirector
    {
        public SmsMessageBuilderImpl ConstructMessage(SmsMessageBuilderImpl builder, NotificationRequest request)
        {
            return builder
                .WithRecipient(request.Recipient)
                .WithContent(request.Message)
                .WithSenderNumber(request.AdditionalData.GetValueOrDefault("senderNumber", "+1234567890"))
                .WithDeliveryReport(bool.Parse(request.AdditionalData.GetValueOrDefault("requireDeliveryReport", "false")));
        }
    }
}
