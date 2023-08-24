using System;
using Web.Data;
using Web.Features.Clients;
using Web.Features.Users;
using Web.Features.Users.Queries;

namespace Web.ServiceManager;


public class ServiceManager : IServiceManager
{
    private readonly DataContext _context;
    private IClientService? _clientService;
    private IUserQueryService? _userQueryService;

    public ServiceManager(DataContext context)
    {
        _context = context;
    }

    public IClientService Client
    {
        get
        {
            _clientService ??= new ClientService(_context);

            return _clientService;
        }
    }

    public IUserQueryService QueryUser
    {
        get
        {
            _userQueryService ??= new UserQueryService(_context);

            return _userQueryService;
        }
    }

    public Task SaveAsync()
    {
        return _context.SaveChangesAsync();
    }
}

