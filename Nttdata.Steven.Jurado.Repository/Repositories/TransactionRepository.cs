namespace Nttdata.Steven.Jurado.Repository.Repositories
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Logging;
    using Nttdata.Steven.Jurado.Domain.Entities;
    using Nttdata.Steven.Jurado.Repository.Helpers;
    using Nttdata.Steven.Jurado.Repository.Interfaces;
    using Nttdata.Steven.Jurado.Repository.Sql.Context;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class TransactionRepository : ITransactionRepository
    {

        private readonly TransactionContext _transactionContext;
        private readonly IBankAccountRepository _bankAccountRepository;
        private readonly ILogger<TransactionRepository> _logger;


        public TransactionRepository(TransactionContext transactionContext,
            ILogger<TransactionRepository> logger,
            IBankAccountRepository bankAccountRepository)
        {
            _transactionContext = transactionContext;
            _bankAccountRepository = bankAccountRepository;
            _logger = logger;
        }


        public async Task<List<TransactionHelper>> GetTransactionsAsync(DateTime startDateTime, DateTime endDateTime, Guid idClient)
        {
            try
            {
                var response = await (from transaction in _transactionContext.Transactions
                                      join bankAccount in _transactionContext.BankAccounts
                                      on transaction.IdBankAccount equals bankAccount.IdBankAccount
                                      join client in _transactionContext.Clients
                                      on bankAccount.IdUsuario equals client.IdClient 
                                      where bankAccount.IdUsuario == idClient
                                      &&
                                      transaction.TransactionDate >= startDateTime
                                      &&
                                      transaction.TransactionDate <= endDateTime
                                      select new TransactionHelper 
                                      {
                                          IdTransaction         = transaction.IdTransaction,
                                          TransactionDate       = transaction.TransactionDate,
                                          Name                  = client.Name,
                                          BankAccountNumber     = bankAccount.BankAccountNumber,
                                          BankAccountType       = bankAccount.BankAccountType,
                                          BankAccountBalance    = bankAccount.BankAccountBalance,
                                          TransactionValue      = transaction.TransactionValue,
                                      }
                                      ).ToListAsync();
                return response;

            }
            catch (Exception Ex)
            {
                _logger.LogCritical("Ocurrio un error al Obtener Movimientos Bancarios {0}", Ex.Message);
                return new List<TransactionHelper>();
            }
            finally
            {
                await _transactionContext.DisposeAsync();
            }
        }

        public async Task<Transaction> GetTransactionIdAsync(Guid idTransaction)
        {
            try
            {
                return await _transactionContext.Transactions.FirstOrDefaultAsync(x => x.IdTransaction.Equals(idTransaction));
            }
            catch (Exception Ex)
            {
                _logger.LogCritical("Ocurrio un error al Obtener Movimientos Bancarios por Id {0}", Ex.Message);
                return null;
            }
            finally
            {
                await _transactionContext.DisposeAsync();
            }
        }

        public async Task<bool> SaveTransactionsAsync(Transaction transaction)
        {
            try
            {

                var responseBankAccountRepository = await GetBankAccount(transaction.IdBankAccount);

                if (responseBankAccountRepository is null)
                    throw new TransactionExceptionHelper($"Cuenta Bancaria No Existe Contactese Con El Banco Steven Jurado +593 959 799 934");

                if (responseBankAccountRepository.BankAccountStatus.Equals((int)Domain.Helpers.Status.Active))
                    throw new TransactionExceptionHelper($"Cuenta {responseBankAccountRepository.BankAccountType} Bancaria Bloqueada Contactese Con El Banco Steven Jurado +593 959 799 934");

                if (responseBankAccountRepository.BankAccountBalance <= transaction.TransactionValue)
                    throw new TransactionExceptionHelper($"Saldo No Disponible En Cuenta {responseBankAccountRepository.BankAccountStatus} Contactese Con El Banco Steven Jurado +593 959 799 934");

                if (responseBankAccountRepository.BankAccountBalance >= transaction.TransactionValue)
                {
                    await _transactionContext.Transactions.AddAsync(transaction);
                }

                return await UpdateBankAccount(responseBankAccountRepository);
            }
            finally
            {
                await _transactionContext.DisposeAsync();
            }
        }

        protected async Task<BankAccount> GetBankAccount(Guid idBankAccount)
        {
            return await _bankAccountRepository.GetBankAccountIdAsyn(idBankAccount);
        }

        protected async Task<bool> UpdateBankAccount(BankAccount bankAccount)
        {
            return await _bankAccountRepository.UpdateBankAccountAsyn(bankAccount);
        }
    }
}
