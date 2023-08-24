using System;
using MediatR;
using Web.ServiceManager;

namespace Web.Features.Clients.Queries;

public class GetAllClients
{
    //Input
    public class GetClientsQuery : IRequest<IEnumerable<GetAllClientsResult>> { }

    //Output
    public class GetAllClientsResult
    {
        public required Guid Guid { get; set; }

        public required string Name { get; set; }

        public required int UserId { get; set; }
    }

    //Handler
    public class Handler : IRequestHandler<GetClientsQuery, IEnumerable<GetAllClientsResult>>
    {
        private readonly IServiceManager _serviceManager;

        public Handler(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        public async Task<IEnumerable<GetAllClientsResult>> Handle(GetClientsQuery request, CancellationToken cancellationToken)
        {
            var clients = await _serviceManager.Client.GetAllAsync();
            var result = new List<GetAllClientsResult>();

            foreach(var client in clients)
            {
                var mappedResult = new GetAllClientsResult
                {
                    UserId = client.UserId,
                    Name = client.Name,
                    Guid = client.Guid
                };

                result.Add(mappedResult);
            }

            return result;
        }
    }
}


