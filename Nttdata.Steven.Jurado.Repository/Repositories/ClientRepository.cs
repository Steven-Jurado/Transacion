namespace Nttdata.Steven.Jurado.Repository.Repositories
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Logging;
    using Nttdata.Steven.Jurado.Domain.Entities;
    using Nttdata.Steven.Jurado.Repository.Interfaces;
    using Nttdata.Steven.Jurado.Repository.Sql.Context;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class ClientRepository : IClientRepository
    {
        private readonly TransactionContext _transactionContext;
        private readonly ILogger<ClientRepository> _logger;

        public ClientRepository(TransactionContext transactionContext, ILogger<ClientRepository> logger)
        {
            _transactionContext = transactionContext;
            _logger = logger;
        }

        public async Task<List<Client>> GetclientAsync()
        {
            try
            {
                _logger.LogInformation("Comnezo El Proceso de Obtener Cliente");

                return await _transactionContext.Clients.Where(x=>x.Status.Equals(Domain.Helpers.Status.Active)).ToListAsync();
            }
            catch (Exception Ex)
            {
                _logger.LogCritical("Ocurrio un erro al Obtener Cliente {0} ", Ex.Message);
                return new List<Client>();
            }
            finally
            {
                await _transactionContext.DisposeAsync();
            }
        }

        public async Task<Client> GetClientIdAsync(Guid idClient)
        {
            try
            {
                _logger.LogInformation("Comnezo El Proceso de Obtener Cliente Por Id {0}", idClient);

                var responseRepository = await _transactionContext.Clients.FirstOrDefaultAsync(x => x.IdClient.Equals(idClient) && x.Status.Equals(Domain.Helpers.Status.Active));

                return responseRepository;
            }
            catch (Exception Ex)
            {
                _logger.LogCritical("Ocurrio un erro al Agregar Cliente {0} ", Ex.Message);
                return new Client();
            }
            finally
            {
                await _transactionContext.DisposeAsync();
            }
        }

        public async Task<bool> AddClientAsync(Client client)
        {
            try
            {
                _logger.LogInformation("Comnezo El Proceso de Guardar Cliente {0}", client.Name);
                
                if (client is not null)
                    _transactionContext.Clients.Add(client);

                return await _transactionContext.SaveChangesAsync() > 0 ;
            }
            catch (Exception Ex)
            {
                _logger.LogCritical("Ocurrio un erro al Agregar Cliente {0} ", Ex.Message);
                return false;
            }
            finally
            {
                await _transactionContext.DisposeAsync();
            }

        }
               

        public async Task<bool> UpdateClientAsync(Client client)
        {
            try
            {
                _logger.LogInformation("Comnezo El Proceso de Actualizacion Cliente {0}", client.Name);

                if (client is not null)
                    _transactionContext.Clients.Update(client);

                return await _transactionContext.SaveChangesAsync() > 0;
            }
            catch (Exception Ex)
            {
                _logger.LogCritical("Ocurrio un error al Actualizacion Cliente {0} ", Ex.Message);
                return false;
            }
            finally
            {
                await _transactionContext.DisposeAsync();
            }
        }

        public async Task<bool> DeleteClientAsync(Guid idClient)
        {
            try
            {
                _logger.LogInformation("Comnezo El Proceso de Eliminacion Cliente {0}", idClient);

                var responseRepository = await _transactionContext.Clients.FirstOrDefaultAsync(x => x.IdClient.Equals(idClient) && x.Status.Equals(Domain.Helpers.Status.Active));

                responseRepository.Status = Domain.Helpers.Status.Inactive;

                if (responseRepository is not null)
                    _transactionContext.Clients.Update(responseRepository);

                return await _transactionContext.SaveChangesAsync() > 0;
            }
            catch (Exception Ex)
            {
                _logger.LogCritical("Ocurrio un error al Actualizacion Cliente {0} ", Ex.Message);
                return false;
            }
            finally
            {
                await _transactionContext.DisposeAsync();
            }
        }

    }
}
