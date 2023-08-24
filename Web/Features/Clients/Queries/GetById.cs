using System;
using MediatR;
using Web.ServiceManager;

namespace Web.Features.Clients.Queries;

public class GetById
{
    //Input
    public record GetClientQuery(int Id) : IRequest<GetClientResponse>;

    //Output
    public class GetClientResponse
    {
        public required Guid Guid { get; set; }

        public required string Name { get; set; }

        public required int UserId { get; set; }
    }

    //Handler
    public class Handler : IRequestHandler<GetClientQuery, GetClientResponse>
    {
        private readonly IServiceManager _serviceManager;

        public Handler(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        public async Task<GetClientResponse> Handle(GetClientQuery request, CancellationToken cancellationToken)
        {
            var client = await _serviceManager.Client.GetByIdAsync(request.Id);

            var mappedResult = new GetClientResponse
            {
                UserId = client.UserId,
                Name = client.Name,
                Guid = client.Guid
            };

            return mappedResult;
        }
    }
}
 
