using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Clockwerkz.Application.Triggers.Commands
{
    public class PauseTriggerCommandHandler : IRequestHandler<PauseTriggerCommand>
    {
        public Task<Unit> Handle(PauseTriggerCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
