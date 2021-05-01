using MediatR;

namespace Clockwerkz.Application.Jobs.Commands
{
    public class DeleteJobCommand : IRequest<bool>
    {
        public string JobName { get; set; }
        public string GroupName { get; set; }
    }
}
