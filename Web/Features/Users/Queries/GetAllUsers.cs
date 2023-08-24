using System;
using MediatR;
using Web.Domain;
using Web.ServiceManager;

namespace Web.Features.Users.Queries;


//Input
public record GetAllUsersQuery : IRequest<IEnumerable<GetAllUsersResponse>>;

//Output
public class GetAllUsersResponse
{
    public required Guid Guid { get; set; }

    public required string FirstName { get; set; }

    public required string LastName { get; set; }
}

//Handler
public class GetAllUsersHandler : IRequestHandler<GetAllUsersQuery, IEnumerable<GetAllUsersResponse>>
{
    private readonly IServiceManager _serviceManager;

    public GetAllUsersHandler(IServiceManager serviceManager)
    {
        _serviceManager = serviceManager;
    }

    public async Task<IEnumerable<GetAllUsersResponse>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
    {
        var users = await _serviceManager.QueryUser.GetAllAsync();
        var result = new List<GetAllUsersResponse>();

        foreach (var user in users)
        {
            var mappedResult = new GetAllUsersResponse
            {
                Guid = user.Guid,
                FirstName = user.FirstName,
                LastName = user.LastName
            };

            result.Add(mappedResult);
        }

        return result;
    }
}

