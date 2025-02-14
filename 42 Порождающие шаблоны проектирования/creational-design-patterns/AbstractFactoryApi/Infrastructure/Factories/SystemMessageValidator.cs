using AbstractFactoryApi.Infrastructure.Core.Messages;
using AbstractFactoryApi.Infrastructure.Factories.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace AbstractFactoryApi.Infrastructure.Factories
{
    public class SystemMessageValidator : IMessageValidator
    {
        private readonly HashSet<string> _validSeverityLevels = new()
    {
        "info", "warning", "error", "critical"
    };

        public Task ValidateMessage(IMessage message)
        {
            var systemMessage = (SystemMessage)message;
            var errors = new List<string>();

            // Validate recipient
            if (string.IsNullOrEmpty(systemMessage.Recipient))
            {
                errors.Add("Recipient is required");
            }

            // Validate title
            if (string.IsNullOrEmpty(systemMessage.Title))
            {
                errors.Add("Title is required");
            }
            else if (systemMessage.Title.Length > 100)
            {
                errors.Add("Title exceeds maximum length of 100 characters");
            }

            // Validate content
            if (string.IsNullOrEmpty(systemMessage.Content))
            {
                errors.Add("Content is required");
            }

            // Validate severity
            if (!string.IsNullOrEmpty(systemMessage.Severity) &&
                !_validSeverityLevels.Contains(systemMessage.Severity.ToLower()))
            {
                errors.Add($"Invalid severity level. Valid levels are: {string.Join(", ", _validSeverityLevels)}");
            }

            if (errors.Any())
            {
                throw new ValidationException(string.Join(", ", errors));
            }

            return Task.CompletedTask;
        }
    }
}