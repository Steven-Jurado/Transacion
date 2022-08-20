namespace Nttdata.Steven.Jurado.Repository.Repositories
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Logging;
    using Newtonsoft.Json;
    using Nttdata.Steven.Jurado.Domain.Entities;
    using Nttdata.Steven.Jurado.Domain.Helpers;
    using Nttdata.Steven.Jurado.Repository.Interfaces;
    using Nttdata.Steven.Jurado.Repository.Sql.Context;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class BankAccountRepository : IBankAccountRepository
    {
        private readonly TransactionContext _transactionContext;
        private readonly ILogger<BankAccountRepository> _logger;

        public BankAccountRepository(TransactionContext transactionContext, ILogger<BankAccountRepository> logger)
        {
            _transactionContext = transactionContext;
            _logger = logger;
        }

        public async Task<List<BankAccount>> GetBankAccountsAsyn()
        {
            try
            {
                _logger.LogInformation("Comnezo El Proceso de Obtener Cuenta Bancaria");

                var responseRepository = await _transactionContext.BankAccounts.Where(x => x.BankAccountStatus.Equals(Status.Active)).ToListAsync();

                return responseRepository;
            }
            catch (Exception Ex)
            {
                _logger.LogCritical("Ocurrio un error al Obtener Cuentas Bancarias {0}", Ex.Message);
                return new List<BankAccount>();
            }
            finally
            {
                await _transactionContext.DisposeAsync();
            }
        }

        public async Task<BankAccount> GetBankAccountIdAsyn(Guid idBankAccount)
        {
            try
            {
                _logger.LogInformation("Comnezo El Proceso de Obtener Cuenta Bancaria Por Id");

                var responseRepository = await _transactionContext.BankAccounts.Include(x =>x.ClientNav).FirstOrDefaultAsync(x => x.BankAccountStatus.Equals(Status.Active) && x.IdBankAccount.Equals(idBankAccount));

                return responseRepository;
            }
            catch (Exception Ex)
            {
                _logger.LogCritical("Ocurrio un error al Obtener Cuentas Bancarias {0}", Ex.Message);
                return null;
            }
            finally
            {
                await _transactionContext.DisposeAsync();
            }
        }

        public async Task<bool> AddBankAccountAsyn(BankAccount bankAccount)
        {
            try
            {
                _logger.LogInformation("Comnezo El Proceso de Agregar Cuenta Bancaria");

                await _transactionContext.BankAccounts.AddAsync(bankAccount);

                return await _transactionContext.SaveChangesAsync() > 0;
            }
            catch (Exception Ex)
            {
                _logger.LogCritical("Ocurrio un error al Agregar Cuentas Bancarias {0}", Ex.Message);
                return false;
            }
            finally
            {
                await _transactionContext.DisposeAsync();
            }
        }

        public async Task<bool> UpdateBankAccountAsyn(BankAccount bankAccount)
        {
            try
            {
                _logger.LogInformation("Comnezo El Proceso de Actualizacion Cuenta Bancaria");

                _transactionContext.BankAccounts.Update(bankAccount);

                return await _transactionContext.SaveChangesAsync() > 0;
            }
            catch (Exception Ex)
            {
                _logger.LogCritical("Ocurrio un error al Eliminar Cuentas Bancarias {0}", Ex.Message);
                return false;
            }
            finally
            {
                await _transactionContext.DisposeAsync();
            }
        }

        public async Task<bool> DeleteBankAccountAsyn(Guid idBankAccount)
        {
            try
            {
                _logger.LogInformation("Comnezo El Proceso de Eliminacion Cuenta Bancaria");

                var responseRepository = await _transactionContext.BankAccounts.FirstOrDefaultAsync(x => x.BankAccountStatus.Equals(Status.Active) && x.IdBankAccount.Equals(idBankAccount));

                if (responseRepository is not null)
                {
                    responseRepository.BankAccountStatus = Status.Inactive;
                    _transactionContext.BankAccounts.Update(responseRepository);
                }

                return await _transactionContext.SaveChangesAsync() > 0;
            }
            catch (Exception Ex)
            {
                _logger.LogCritical("Ocurrio un error al Eliminar Cuentas Bancarias {0}", Ex.Message);
                return false;
            }
            finally
            {
                await _transactionContext.DisposeAsync();
            }
        }

    }
}
