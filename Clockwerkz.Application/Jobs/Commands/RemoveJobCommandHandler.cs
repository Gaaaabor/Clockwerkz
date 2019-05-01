using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace Clockwerkz.Application.Jobs.Commands
{
    public class RemoveJobCommandHandler : IRequestHandler<RemoveJobCommand>
    {
        public Task<Unit> Handle(RemoveJobCommand request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}
