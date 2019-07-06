using Clockwerkz.Application.Jobs.Models;
using MediatR;
using System.Collections.Generic;

namespace Clockwerkz.Application.Jobs.Queries
{
    public class ListJobDetailsQuery : IRequest<ICollection<JobDetailsDto>>
    {
    }
}
