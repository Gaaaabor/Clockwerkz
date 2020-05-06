using Clockwerkz.Application.Jobs.Interfaces;
using Clockwerkz.Application.Jobs.Models;
using Clockwerkz.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Clockwerkz.Application.Jobs.Queries
{
    public class JobDetailsQueryHandler : IRequestHandler<JobDetailsQuery, JobDetailDto>
    {
        private readonly IClockwerkzDbContext _context;
        private readonly IJobDataSerializer _jobDataSerializer;

        public JobDetailsQueryHandler(IClockwerkzDbContext context, IJobDataSerializer jobDataSerializer)
        {
            _context = context;
            _jobDataSerializer = jobDataSerializer;
        }

        public async Task<JobDetailDto> Handle(JobDetailsQuery request, CancellationToken cancellationToken)
        {
            var jobDetail = await _context.JobDetails.FirstOrDefaultAsync(x => x.JobName == request.JobName && x.JobGroup == request.JobGroup);
            if (jobDetail == null)
            {
                return null;
            }

            var jobDetailDto = JobDetailDto.Create(jobDetail);

            jobDetailDto.JobDataMap = _jobDataSerializer.Deserialize(jobDetail.JobData);

            return jobDetailDto;
        }
    }
}
