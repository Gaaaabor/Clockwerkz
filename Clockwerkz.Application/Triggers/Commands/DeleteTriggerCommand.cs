using MediatR;

namespace Clockwerkz.Application.Triggers.Commands
{
    public class DeleteTriggerCommand : IRequest<bool>
    {
        public string TriggerName { get; set; }
        public string GroupName { get; set; }
    }
}
