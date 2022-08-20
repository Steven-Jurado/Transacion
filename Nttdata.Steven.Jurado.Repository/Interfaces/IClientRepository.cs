namespace Nttdata.Steven.Jurado.Repository.Interfaces
{
    using Nttdata.Steven.Jurado.Domain.Entities;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IClientRepository
    {
        Task<List<Client>> GetclientAsync();
        Task<Client> GetClientIdAsync(Guid idClient);
        Task<bool> AddClientAsync(Client client);
        Task<bool> UpdateClientAsync(Client client);
        Task<bool> DeleteClientAsync(Guid idClient);
    }
}
