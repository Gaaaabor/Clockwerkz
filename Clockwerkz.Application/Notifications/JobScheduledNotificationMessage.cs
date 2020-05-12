using Clockwerkz.Application.Jobs.Models;

namespace Clockwerkz.Application.Notifications
{
    public class JobScheduledNotificationMessage : NotificationMessageBase
    {
        public static string Event= "JobScheduled";

        public JobScheduledNotificationMessage(JobListDto item)
        {
            EventName = NotificationEvents.JobScheduled;
            Item = item;
        }
    }
}
