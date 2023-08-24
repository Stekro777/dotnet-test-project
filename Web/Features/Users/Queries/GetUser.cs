using System;
using FluentValidation;
using MediatR;
using Web.Domain;
using Web.ServiceManager;

namespace Web.Features.Users.Queries;

public record GetUserQuery(int Id) : IRequest<GetUserResponse?>;

public class GetUserResponse
{
    public required Guid Guid { get; set; }

    public required string FirstName { get; set; }

    public required string LastName { get; set; }

    public required DateTime Created { get; set; }

    public required List<Client?> Clients { get; set; }
}

//Handler
public class GetUserHandler : IRequestHandler<GetUserQuery, GetUserResponse?>
{
    private readonly IServiceManager _serviceManager;

    public GetUserHandler(IServiceManager serviceManager)
    {
        _serviceManager = serviceManager;
    }

    public async Task<GetUserResponse?> Handle(GetUserQuery request, CancellationToken cancellationToken)
    {

        var user = await _serviceManager.QueryUser.GetByIdAsync(request.Id);

        if(user is null)
        {
            return null;
        }

        var userResponse = new GetUserResponse
        {
            Guid = user.Guid,
            FirstName = user.FirstName,
            LastName = user.LastName,
            Created = user.Created,
            Clients = (List<Client?>)user.Clients
        };

        return userResponse;

    }
}

public class GetMovieValidator : AbstractValidator<GetUserQuery>
{
    private readonly IServiceManager _serviceManager;

    public GetMovieValidator(IServiceManager serviceManager)
    {
        _serviceManager = serviceManager;

        RuleFor(userQuery => userQuery.Id).NotEmpty().NotNull().GreaterThan(0);
    }
}
