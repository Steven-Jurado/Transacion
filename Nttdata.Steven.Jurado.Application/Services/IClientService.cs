namespace Nttdata.Steven.Jurado.Application.Services
{
    using Nttdata.Steven.Jurado.Application.DTOs;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IClientService
    {
        Task<List<ClientRequest>> GetClientAsync();
        Task<ClientRequest> GetClientIdAsync(Guid IdClient);
        Task<bool> AddClientAsync(ClientRequest clientRequest);
        Task<bool> UpdateClientAsync(ClientRequest clientRequest);
        Task<bool> DeleteClientAsync(Guid IdClient);
    }
}
