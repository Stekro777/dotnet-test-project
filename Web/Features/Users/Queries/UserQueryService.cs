using System;
using Microsoft.EntityFrameworkCore;
using Web.Data;
using Web.Domain;

namespace Web.Features.Users.Queries;

public class UserQueryService : IUserQueryService
{
    private readonly DataContext _context;

    public UserQueryService(DataContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<User>> GetAllAsync()
    {
        return await _context.Users
            .OrderBy(x => x.Id)
            .ToListAsync();
    }

    public async Task<User?> GetByIdAsync(int userId)
    {
        return await _context.Users
            .Include(x => x.Clients)
            .FirstOrDefaultAsync(x => x.Id == userId);
    }
}

