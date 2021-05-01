using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Clockwerkz.Application.Triggers.Commands
{
    public class CreateTriggerCommandHandler : IRequestHandler<CreateTriggerCommand, bool>
    {
        private readonly IJobManager _jobManager;

        public CreateTriggerCommandHandler(IJobManager jobManager)
        {
            _jobManager = jobManager;
        }

        public async Task<bool> Handle(CreateTriggerCommand request, CancellationToken cancellationToken)
        {
            var result = await _jobManager.CreateTriggerAsync(
                request.JobName,
                request.JobGroupName,
                request.TriggerName,
                request.TriggerGroupName,
                request.TriggerDescription,
                request.StartImmediately,
                request.CronExpression,
                request.JobDataMap);

            return result;
        }
    }
}
