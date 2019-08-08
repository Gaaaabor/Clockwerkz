using MediatR;

namespace Clockwerkz.Application.Triggers.Commands
{
    public class DeleteTriggerCommand : IRequest
    {
        public string Name { get; set; }
        public string GroupName { get; set; }
    }
}
