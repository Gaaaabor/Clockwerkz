using Clockwerkz.Application.JobTypes.Models;
using MediatR;
using System.Collections.Generic;

namespace Clockwerkz.Application.JobTypes.Queries
{
    public class ListJobDataMapKeysQuery : IRequest<ICollection<JobDataMapKey>>
    {
    }
}
