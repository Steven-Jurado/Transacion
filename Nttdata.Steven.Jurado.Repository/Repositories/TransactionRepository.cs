namespace Nttdata.Steven.Jurado.Repository.Repositories
{
    using Microsoft.Extensions.Logging;
    using Nttdata.Steven.Jurado.Repository.Interfaces;
    using Nttdata.Steven.Jurado.Repository.Sql.Context;

    public class TransactionRepository : ITransactionRepository
    {

        private readonly TransactionContext _transactionContext;
        private readonly ILogger<TransactionRepository> _logger;

        public TransactionRepository(TransactionContext transactionContext, ILogger<TransactionRepository> logger)
        {
            _transactionContext = transactionContext;
            _logger = logger;
        }
    }
}
