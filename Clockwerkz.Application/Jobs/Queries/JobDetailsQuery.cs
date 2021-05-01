using MediatR;
using System.Collections.Generic;

namespace Clockwerkz.Application.Jobs.Queries
{
    public class JobDetailsQuery : IRequest<IDictionary<string, string>>
    {
        public string JobName { get; set; }
        public string GroupName { get; set; }
    }
}
