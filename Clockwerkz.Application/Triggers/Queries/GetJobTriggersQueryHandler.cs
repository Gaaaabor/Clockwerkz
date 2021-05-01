using Clockwerkz.Application.Triggers.Models;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Clockwerkz.Application.Triggers.Queries
{
    public class GetJobTriggersQueryHandler : IRequestHandler<GetJobTriggersQuery, IEnumerable<TriggerDto>>
    {
        private readonly IJobManager _jobManager;

        public GetJobTriggersQueryHandler(IJobManager jobManager)
        {
            _jobManager = jobManager;
        }

        public async Task<IEnumerable<TriggerDto>> Handle(GetJobTriggersQuery request, CancellationToken cancellationToken)
        {
            var result = await _jobManager.GetTriggersAsync(request.JobName, request.JobGroup);
            return result;
        }
    }
}
