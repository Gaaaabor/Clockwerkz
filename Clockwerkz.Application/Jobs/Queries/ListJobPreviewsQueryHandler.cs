﻿using Clockwerkz.Application.Jobs.Models;
using Clockwerkz.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Clockwerkz.Application.Jobs.Queries
{
    public class ListJobPreviewsQueryHandler : IRequestHandler<ListJobPreviewsQuery, ICollection<JobPreviewDto>>
    {
        private readonly ClockwerkzDbContext _context;

        public ListJobPreviewsQueryHandler(ClockwerkzDbContext context)
        {
            _context = context;
        }

        public async Task<ICollection<JobPreviewDto>> Handle(ListJobPreviewsQuery request, CancellationToken cancellationToken)
        {
            var tmp = await _context.QrtzJobDetails
                .Include(x => x.QrtzTriggers)
                .OrderBy(x => x.JobName)
                .GroupBy(x => x.JobGroup)
                .Select(JobPreviewDto.Projection)
                .ToListAsync();

            return tmp;
        }
    }
}
