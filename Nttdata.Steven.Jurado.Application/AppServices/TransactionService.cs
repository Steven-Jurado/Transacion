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

    public class TransactionService : ITransactionService
    {
        private readonly ITransactionRepository _transactionRepository;

        public TransactionService(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }

        public async Task<List<TransactionResponse>> GetTransacctionsAsync(DateTime startTime, DateTime endDateTime, Guid idClient)
        {
            var responseRepository = await _transactionRepository.GetTransactionsAsync(startTime, endDateTime, idClient);

            var responseConvet = ConvertHelper.ConvertType<List<TransactionResponse>>(responseRepository);

            return responseConvet;
        }

        public async Task<TransacctionRequest> GetransacctionIdAsync(Guid idTransaction)
        {
            var responseRepository = await _transactionRepository.GetTransactionIdAsync(idTransaction);

            var responseConvet = ConvertHelper.ConvertType<TransacctionRequest>(responseRepository);

            return responseConvet;
        }


        public async Task<bool> SaveTransacctionAsync(TransacctionRequest transacctionRequest)
        {
            var responseConvert = ConvertHelper.ConvertType<Transaction>(transacctionRequest);

            return await _transactionRepository.SaveTransactionsAsync(responseConvert);
        }
    }
}
