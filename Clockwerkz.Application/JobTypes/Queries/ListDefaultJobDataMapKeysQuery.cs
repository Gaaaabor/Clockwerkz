using MediatR;
using System.Collections.Generic;

namespace Clockwerkz.Application.JobTypes.Queries
{
    public class ListDefaultJobDataMapKeysQuery : IRequest<ICollection<string>>
    {
    }
}
