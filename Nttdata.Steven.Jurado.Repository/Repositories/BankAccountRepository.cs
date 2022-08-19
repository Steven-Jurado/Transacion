namespace Nttdata.Steven.Jurado.Repository.Repositories
{
    using Microsoft.Extensions.Logging;
    using Nttdata.Steven.Jurado.Repository.Interfaces;
    using Nttdata.Steven.Jurado.Repository.Sql.Context;

    public class BankAccountRepository : IBankAccountRepository
    {
        private readonly TransactionContext _transactionContext;
        private readonly ILogger<BankAccountRepository> _logger;

        public BankAccountRepository(TransactionContext transactionContext, ILogger<BankAccountRepository> logger)
        {
            _transactionContext = transactionContext;
            _logger = logger;
        }
    }
}
