﻿using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Clockwerkz.Application.JobTypes.Queries
{
    public class ListDefaultJobDataMapKeysQueryHandler : IRequestHandler<ListDefaultJobDataMapKeysQuery, ICollection<string>>
    {
        private readonly IJobSettingsProvider _jobSettingsProvider;

        public ListDefaultJobDataMapKeysQueryHandler(IJobSettingsProvider jobSettingsProvider)
        {
            _jobSettingsProvider = jobSettingsProvider;
        }
        public async Task<ICollection<string>> Handle(ListDefaultJobDataMapKeysQuery request, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;
            return await _jobSettingsProvider.ListDefaultJobDataMapKeys();
        }
    }
}
