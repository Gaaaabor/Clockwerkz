using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace Clockwerkz.Application.Jobs.Commands
{
    public class DeleteJobCommandHandler : IRequestHandler<DeleteJobCommand>
    {
        public Task<Unit> Handle(DeleteJobCommand request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}
