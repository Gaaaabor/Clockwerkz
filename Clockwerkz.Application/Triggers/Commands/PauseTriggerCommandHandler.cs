using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Clockwerkz.Application.Triggers.Commands
{
    public class PauseTriggerCommandHandler : IRequestHandler<PauseTriggerCommand, bool>
    {
        private readonly IJobManager _jobManager;

        public PauseTriggerCommandHandler(IJobManager jobManager)
        {
            _jobManager = jobManager;
        }

        public async Task<bool> Handle(PauseTriggerCommand request, CancellationToken cancellationToken)
        {
            var result = await _jobManager.PauseTriggerAsync(request.TriggerName, request.GroupName);
            return result;
        }
    }
}
