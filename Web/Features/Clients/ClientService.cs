using System;
using Microsoft.EntityFrameworkCore;
using Web.Data;
using Web.Domain;

namespace Web.Features.Clients;

public class ClientService : IClientService
{
    private readonly DataContext _context;

    public ClientService(DataContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Client>> GetAllAsync()
    {
        return await _context.Clients
            .OrderBy(x => x.Id)
            .ToListAsync();
    }

    public async Task<Client?> GetByIdAsync(int clientId)
    {
        return await _context.Clients
            .FirstOrDefaultAsync(x => x.Id == clientId);
    }
}