using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Clockwerkz.Application.Jobs.Queries
{
    class GetJobDetailsQueryHandler : IRequestHandler<GetJobDetailsQuery, ICollection<string>>
    {
        public Task<ICollection<string>> Handle(GetJobDetailsQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
