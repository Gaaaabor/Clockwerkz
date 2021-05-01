using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Clockwerkz.Application.Jobs.Commands
{
    public class DeleteJobCommandHandler : IRequestHandler<DeleteJobCommand, bool>
    {
        private readonly IJobManager _jobManager;

        public DeleteJobCommandHandler(IJobManager jobManager)
        {
            _jobManager = jobManager;
        }

        public async Task<bool> Handle(DeleteJobCommand request, CancellationToken cancellationToken)
        {
            var result = await _jobManager.DeleteJobAsync(request.JobName, request.GroupName);
            return result;
        }
    }
}
