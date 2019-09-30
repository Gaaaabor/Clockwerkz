using Clockwerkz.Application.Jobs.Models;
using MediatR;

namespace Clockwerkz.Application.Jobs.Queries
{
    public class JobDetailsQuery : IRequest<JobDetailDto>
    {
        public string JobGroup { get; set; }
        public string JobName { get; set; }
    }
}
