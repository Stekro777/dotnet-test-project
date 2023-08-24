using System;
using Web.Domain;

namespace Web.Features.Clients;

public interface IClientService
{
    Task<IEnumerable<Client>> GetAllAsync();
    Task<Client?> GetByIdAsync(int ClientId);
}