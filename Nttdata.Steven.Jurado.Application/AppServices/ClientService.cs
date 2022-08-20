namespace Nttdata.Steven.Jurado.Application.AppServices
{
    using Nttdata.Steven.Jurado.Application.DTOs;
    using Nttdata.Steven.Jurado.Application.Helpers;
    using Nttdata.Steven.Jurado.Application.Services;
    using Nttdata.Steven.Jurado.Domain.Entities;
    using Nttdata.Steven.Jurado.Repository.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class ClientService : IClientService
    {

        private readonly IClientRepository _clientRepository;

        public ClientService(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public async Task<List<ClientRequest>> GetClientAsync()
        {
            var responseRepository = await _clientRepository.GetclientAsync();

            var responseConvert = ConvertHelper.ConvertType<List<ClientRequest>>(responseRepository);

            return responseConvert;

        }

        public async Task<ClientRequest> GetClientIdAsync(Guid IdClient)
        {
            var responseRepository = await _clientRepository.GetClientIdAsync(IdClient);

            var responseConvert = ConvertHelper.ConvertType<ClientRequest>(responseRepository);

            return responseConvert;
        }

        public async Task<bool> AddClientAsync(ClientRequest clientRequest)
        {

            var responseConvert = ConvertHelper.ConvertType<Client>(clientRequest);

            return await _clientRepository.AddClientAsync(responseConvert);
        }

        

        public async Task<bool> UpdateClientAsync(ClientRequest clientRequest)
        {
            var responseConvert = ConvertHelper.ConvertType<Client>(clientRequest);

            return await _clientRepository.UpdateClientAsync(responseConvert);
        }

        public async Task<bool> DeleteClientAsync(Guid IdClient)
        {
            return await _clientRepository.DeleteClientAsync(IdClient);
        }
    }
}
