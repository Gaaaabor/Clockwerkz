using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Clockwerkz.Application.Triggers.Commands
{
    public class DeleteTriggerCommandHandler : IRequestHandler<DeleteTriggerCommand, bool>
    {
        private readonly IJobManager _jobManager;

        public DeleteTriggerCommandHandler(IJobManager jobManager)
        {
            _jobManager = jobManager;
        }

        public async Task<bool> Handle(DeleteTriggerCommand request, CancellationToken cancellationToken)
        {
            var result = await _jobManager.DeleteTriggerAsync(request.TriggerName, request.GroupName);
            return result;
        }
    }
}
