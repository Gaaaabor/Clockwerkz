using Clockwerkz.Application.JobTypes.Models;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Clockwerkz.Application.JobTypes.Queries
{
    public class ListJobDataMapKeysQueryHandler : IRequestHandler<ListJobDataMapKeysQuery, ICollection<JobDataMapKey>>
    {
        private readonly IJobSettingsProvider _jobSettingsProvider;

        public ListJobDataMapKeysQueryHandler(IJobSettingsProvider jobSettingsProvider)
        {
            _jobSettingsProvider = jobSettingsProvider;
        }

        public async Task<ICollection<JobDataMapKey>> Handle(ListJobDataMapKeysQuery request, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;
            return await _jobSettingsProvider.ListJobDataMapKeys();
        }
    }
}
