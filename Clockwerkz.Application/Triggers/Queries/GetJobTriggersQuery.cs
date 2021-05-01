using Clockwerkz.Application.Triggers.Models;
using MediatR;
using System.Collections.Generic;

namespace Clockwerkz.Application.Triggers.Queries
{
    public class GetJobTriggersQuery : IRequest<IEnumerable<TriggerDto>>
    {
        public string JobName { get; set; }
        public string JobGroup { get; set; }
    }
}
