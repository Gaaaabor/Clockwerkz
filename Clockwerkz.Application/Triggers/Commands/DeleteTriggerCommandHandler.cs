using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Clockwerkz.Application.Triggers.Commands
{
    public class DeleteTriggerCommandHandler : IRequestHandler<DeleteTriggerCommand>
    {
        private readonly IJobManager _jobManager;

        public DeleteTriggerCommandHandler(IJobManager jobManager)
        {
            _jobManager = jobManager;
        }

        public async Task<Unit> Handle(DeleteTriggerCommand request, CancellationToken cancellationToken)
        {
            await _jobManager.DeleteTrigger(request.Name, request.GroupName);

            return Unit.Value;
        }
    }
}
