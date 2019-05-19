using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Clockwerkz.Application.Jobs.Commands
{
    public class CreateJobCommandHandler : IRequestHandler<CreateJobCommand>
    {
        private readonly IJobManager _jobManager;

        public CreateJobCommandHandler(IJobManager jobManager)
        {
            _jobManager = jobManager;
        }

        public async Task<Unit> Handle(CreateJobCommand request, CancellationToken cancellationToken)
        {            
            await _jobManager.CreateJobAsync();            

            return Unit.Value;
        }
    }
}
