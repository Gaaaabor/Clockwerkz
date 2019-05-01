using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace Clockwerkz.Application.Triggers.Commands
{
    public class RemoveTriggerCommandHandler : IRequestHandler<RemoveTriggerCommand>
    {
        public Task<Unit> Handle(RemoveTriggerCommand request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}
