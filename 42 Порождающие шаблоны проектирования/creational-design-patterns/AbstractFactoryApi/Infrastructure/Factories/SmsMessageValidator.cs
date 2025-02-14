using AbstractFactoryApi.Infrastructure.Core.Messages;
using AbstractFactoryApi.Infrastructure.Factories.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace AbstractFactoryApi.Infrastructure.Factories
{
    public class SmsMessageValidator : IMessageValidator
    {
        public Task ValidateMessage(IMessage message)
        {
            var smsMessage = (SmsMessage)message;
            var errors = new List<string>();

            // Validate recipient (phone number)
            if (string.IsNullOrEmpty(smsMessage.Recipient))
            {
                errors.Add("Recipient phone number is required");
            }
            else if (!IsValidPhoneNumber(smsMessage.Recipient))
            {
                errors.Add("Invalid phone number format");
            }

            // Validate content
            if (string.IsNullOrEmpty(smsMessage.Content))
            {
                errors.Add("Message content cannot be empty");
            }
            else if (smsMessage.Content.Length > 160)
            {
                errors.Add("SMS content exceeds 160 characters");
            }

            // Validate sender number
            if (!string.IsNullOrEmpty(smsMessage.SenderNumber) && !IsValidPhoneNumber(smsMessage.SenderNumber))
            {
                errors.Add("Invalid sender number format");
            }

            if (errors.Any())
            {
                throw new ValidationException(string.Join(", ", errors));
            }

            return Task.CompletedTask;
        }

        private bool IsValidPhoneNumber(string phoneNumber)
        {
            // Basic phone number validation (E.164 format)
            return !string.IsNullOrEmpty(phoneNumber) &&
                   phoneNumber.StartsWith("+") &&
                   phoneNumber.Skip(1).All(char.IsDigit) &&
                   phoneNumber.Length >= 8 &&
                   phoneNumber.Length <= 15;
        }
    }
}