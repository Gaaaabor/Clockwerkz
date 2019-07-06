using Clockwerkz.Application.JobTypes.Models;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Clockwerkz.Application.JobTypes.Queries
{
    public class ListJobTypesQueryHandler : IRequestHandler<ListJobTypesQuery, ICollection<JobType>>
    {
        private readonly IJobSettingsProvider _jobSettingsProvider;

        public ListJobTypesQueryHandler(IJobSettingsProvider jobSettingsProvider)
        {
            _jobSettingsProvider = jobSettingsProvider;
        }

        public async Task<ICollection<JobType>> Handle(ListJobTypesQuery request, CancellationToken cancellationToken)
        {
            return await _jobSettingsProvider.GetJobTypesAsync();
        }
    }
}
