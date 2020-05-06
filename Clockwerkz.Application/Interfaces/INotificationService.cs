using Clockwerkz.Application.Notifications;
using System.Threading.Tasks;

namespace Clockwerkz.Application.Interfaces
{
    public interface INotificationService
    {
        Task SendAsync(NotificationMessage notificationMessage);
    }
}
