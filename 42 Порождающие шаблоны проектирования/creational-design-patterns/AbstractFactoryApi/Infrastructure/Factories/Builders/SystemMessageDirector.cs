using AbstractFactoryApi.Infrastructure.Core;

namespace AbstractFactoryApi.Infrastructure.Factories.Builders
{

    public class SystemMessageDirector
    {
        public SystemMessageBuilderImpl ConstructMessage(SystemMessageBuilderImpl builder, NotificationRequest request)
        {
            return builder
                .WithRecipient(request.Recipient)
                .WithTitle(request.Subject ?? "System Notification")
                .WithContent(request.Message)
                .WithSeverity(request.AdditionalData.GetValueOrDefault("severity", "info"))
                .WithAcknowledgementRequired(bool.Parse(request.AdditionalData.GetValueOrDefault("requireAcknowledgement", "false")));
        }
    }
}
