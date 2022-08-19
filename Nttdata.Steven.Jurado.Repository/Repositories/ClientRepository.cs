namespace Nttdata.Steven.Jurado.Repository.Repositories
{
    using Microsoft.Extensions.Logging;
    using Nttdata.Steven.Jurado.Repository.Interfaces;
    using Nttdata.Steven.Jurado.Repository.Sql.Context;

    public class ClientRepository : IClientRepository
    {
        private readonly TransactionContext _transactionContext;
        private readonly ILogger<ClientRepository> _logger;

        public ClientRepository(TransactionContext transactionContext, ILogger<ClientRepository> logger)
        {
            _transactionContext = transactionContext;
            _logger = logger;
        }
    }
}
