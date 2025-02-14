using AbstractFactoryApi.Infrastructure.Core.Messages;
using AbstractFactoryApi.Infrastructure.Factories.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace AbstractFactoryApi.Infrastructure.Factories
{
    public class EmailMessageValidator : IMessageValidator
    {
        public Task ValidateMessage(IMessage message)
        {
            var emailMessage = (EmailMessage)message;
            if (string.IsNullOrEmpty(emailMessage.Body))
                throw new ValidationException("Email body cannot be empty");
            if (!emailMessage.Recipient.Contains("@"))
                throw new ValidationException("Invalid email address");
            return Task.CompletedTask;
        }
    }
}
