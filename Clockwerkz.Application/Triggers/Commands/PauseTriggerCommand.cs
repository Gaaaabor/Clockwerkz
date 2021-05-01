using MediatR;

namespace Clockwerkz.Application.Triggers.Commands
{
    public class PauseTriggerCommand : IRequest<bool>
    {
        public string TriggerName { get; set; }
        public string GroupName { get; set; }
    }
}
