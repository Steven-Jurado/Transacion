namespace Nttdata.Steven.Jurado.Repository.Interfaces
{
    using Nttdata.Steven.Jurado.Domain.Entities;
    using Nttdata.Steven.Jurado.Repository.Helpers;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ITransactionRepository
    {
        Task<List<TransactionHelper>> GetTransactionsAsync(DateTime startDatetime, DateTime endDateTime, Guid ìdClient);
        Task<Transaction> GetTransactionIdAsync(Guid idTransaction);
        Task<bool> SaveTransactionsAsync(Transaction transaction);


    }
}
