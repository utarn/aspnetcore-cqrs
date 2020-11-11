using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace aspnetcore_cqrs.Mediator.Home.Queries.GetPingQuery
{
    public class GetPingQuery : IRequest<string>
    {
        public string Command { get; set; }
        public class GetPingQueryHandler : IRequestHandler<GetPingQuery, string>
        {
            public async Task<string> Handle(GetPingQuery request, CancellationToken cancellationToken)
            {
                await Task.Delay(800);
                return "pong-" + request.Command;
            }
        }
    }
}