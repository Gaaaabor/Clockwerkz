using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Clockwerkz.Application.Triggers.Commands
{
    public class CreateTriggerCommandHandler : IRequestHandler<CreateTriggerCommand>
    {
        public Task<Unit> Handle(CreateTriggerCommand request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}
