using System;
using Web.Features.Clients;
using Web.Features.Users;
using Web.Features.Users.Queries;

namespace Web.ServiceManager;

public interface IServiceManager
{
    IClientService Client { get; }
    IUserQueryService QueryUser { get; }
    Task SaveAsync();
}

