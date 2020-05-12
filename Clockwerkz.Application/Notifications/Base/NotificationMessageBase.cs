namespace Clockwerkz.Application.Notifications
{
    public abstract class NotificationMessageBase
    {
        public string EventName { get; protected set; }
        public object Item { get; protected set; }
    }
}
