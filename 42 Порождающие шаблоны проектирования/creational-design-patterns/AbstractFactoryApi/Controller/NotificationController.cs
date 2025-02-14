using AbstractFactoryApi.Infrastructure.Core;
using AbstractFactoryApi.Infrastructure.Service;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace AbstractFactoryApi.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class NotificationController : ControllerBase
    {
        private readonly NotificationService _notificationService;

        public NotificationController(NotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        [HttpPost("{channel}")]
        public async Task<IActionResult> SendNotification(
            string channel,
            [FromBody] NotificationRequest request)
        {
            try
            {
                var response = await _notificationService.SendNotificationAsync(channel, request);
                return Ok(response);
            }
            catch (ValidationException ex)
            {
                return BadRequest(new { error = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "An error occurred while sending the notification" });
            }
        }
    }
}
