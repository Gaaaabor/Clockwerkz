using MediatR;
using System.Collections.Generic;

namespace Clockwerkz.Application.Jobs.Queries
{
    public class GetJobDetailsQuery : IRequest<ICollection<string>>
    {
    }
}
