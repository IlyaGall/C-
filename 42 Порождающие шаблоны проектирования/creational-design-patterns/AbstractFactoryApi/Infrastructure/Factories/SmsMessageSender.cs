using AbstractFactoryApi.Infrastructure.Configuration;
using AbstractFactoryApi.Infrastructure.Core;
using AbstractFactoryApi.Infrastructure.Core.Messages;
using AbstractFactoryApi.Infrastructure.Factories.Interfaces;

namespace AbstractFactoryApi.Infrastructure.Factories
{
    public class SmsMessageSender : IMessageSender
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger _logger;

        public SmsMessageSender(IConfiguration configuration, ILogger logger)
        {
            _configuration = configuration;
            _logger = logger;
        }

        public async Task<NotificationResponse> SendMessage(IMessage message)
        {
            var smsMessage = (SmsMessage)message;
            try
            {
                // Get SMS configuration
                var smsConfig = _configuration.GetSection("NotificationSettings:Sms").Get<SmsSettings>();

                // Log the attempt
                _logger.LogInformation(
                    "Attempting to send SMS to {Recipient} from {Sender}",
                    smsMessage.Recipient,
                    smsMessage.SenderNumber);

                // Simulate SMS sending delay
                await Task.Delay(100);

                // Here you would typically integrate with an SMS provider like Twilio
                // Example:
                // var twilioClient = new TwilioRestClient(smsConfig.AccountSid, smsConfig.AuthToken);
                // var twilioMessage = await twilioClient.SendMessageAsync(
                //     smsMessage.SenderNumber,
                //     smsMessage.Recipient,
                //     smsMessage.Content);

                return new NotificationResponse
                {
                    Id = smsMessage.Id,
                    Status = "Sent",
                    SentAt = DateTime.UtcNow,
                    Channel = "SMS",
                    AdditionalInfo = new Dictionary<string, string>
                {
                    { "deliveryReport", smsMessage.RequireDeliveryReport.ToString() }
                }
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to send SMS to {Recipient}", smsMessage.Recipient);
                throw;
            }
        }
    }
}