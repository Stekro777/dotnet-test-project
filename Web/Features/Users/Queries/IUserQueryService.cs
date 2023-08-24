using System;
using Web.Domain;

namespace Web.Features.Users.Queries;

public interface IUserQueryService
{
    Task<IEnumerable<User>> GetAllAsync();
    Task<User?> GetByIdAsync(int userId);
}


