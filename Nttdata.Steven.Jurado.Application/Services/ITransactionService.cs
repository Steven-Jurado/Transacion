namespace Nttdata.Steven.Jurado.Application.Services
{
    using Nttdata.Steven.Jurado.Application.DTOs;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ITransactionService
    {
        Task<List<TransactionResponse>> GetTransacctionsAsync(DateTime startTime, DateTime endDateTime, Guid idClient);
        Task<TransacctionRequest> GetransacctionIdAsync(Guid idTransaction);
        Task<bool> SaveTransacctionAsync(TransacctionRequest transacctionRequest);

    }
}
