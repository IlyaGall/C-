using FabricMethodApi.Infrastructure.Core;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;

namespace FabricMethodApi.Infrastructure.Service
{
    public abstract class NotificationService
    {
        protected readonly ILogger<NotificationService> _logger;
        protected readonly IConfiguration _configuration;

        protected NotificationService(ILogger<NotificationService> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        /// <summary>
        /// AnOperation or Template Method
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<NotificationResponse> SendNotificationAsync(NotificationRequest request)
        {
            try
            {
                await ValidateNotification(request);
                await PrepareNotification(request);
                var response = await SendNotificationImpl(request);
                await LogNotification(request, response);
                return response;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error sending notification");
                throw;
            }
        }
        /// <summary>
        /// Factory method
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        protected abstract Task<NotificationResponse> SendNotificationImpl(NotificationRequest request);

        protected virtual Task ValidateNotification(NotificationRequest request)
        {
            if (string.IsNullOrEmpty(request.Message))
                throw new ValidationException("Message cannot be empty");
            if (string.IsNullOrEmpty(request.Recipient))
                throw new ValidationException("Recipient cannot be empty");
            return Task.CompletedTask;
        }

        protected virtual Task PrepareNotification(NotificationRequest request)
        {
            return Task.CompletedTask;
        }

        protected virtual Task LogNotification(NotificationRequest request, NotificationResponse response)
        {
            _logger.LogInformation("Notification sent: {Response}", JsonSerializer.Serialize(response));
            return Task.CompletedTask;
        }
    }
}
