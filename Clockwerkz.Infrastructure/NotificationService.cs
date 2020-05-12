using Clockwerkz.Application.Interfaces;
using Clockwerkz.Application.Notifications;
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace Clockwerkz.Infrastructure
{
    public class NotificationService : Hub, INotificationService
    {
        private readonly IHubContext<NotificationService> _hubContext;

        public NotificationService(IHubContext<NotificationService> hubContext)
        {
            _hubContext = hubContext;
        }

        public async Task SendAsync(NotificationMessageBase notificationMessage)
        {
            await _hubContext.Clients.All.SendAsync(notificationMessage.EventName, notificationMessage.Item);
        }
    }
}
