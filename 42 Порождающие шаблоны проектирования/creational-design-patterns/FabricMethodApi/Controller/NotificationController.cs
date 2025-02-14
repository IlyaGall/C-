using FabricMethodApi.Infrastructure.Core;
using FabricMethodApi.Infrastructure.Service;
using Microsoft.AspNetCore.Mvc;

namespace FabricMethodApi.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class NotificationController : ControllerBase
    {
        private readonly NotificationManager _notificationManager;

        public NotificationController(NotificationManager notificationManager)
        {
            _notificationManager = notificationManager;
        }

        [HttpPost]
        public async Task<IActionResult> SendNotification(string channel, [FromBody] NotificationRequest notification)
        {
            try
            {
                var response=await _notificationManager.SendNotificationAsync(channel, notification);
                return Ok(new { message = $"Notification sent via {channel} : {response}" });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }
    }
}
