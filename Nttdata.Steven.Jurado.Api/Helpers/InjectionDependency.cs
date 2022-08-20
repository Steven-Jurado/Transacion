namespace Nttdata.Steven.Jurado.Api.Helpers
{
    using Microsoft.Extensions.DependencyInjection;
    using Nttdata.Steven.Jurado.Application.AppServices;
    using Nttdata.Steven.Jurado.Application.Services;
    using Nttdata.Steven.Jurado.Repository.Interfaces;
    using Nttdata.Steven.Jurado.Repository.Repositories;
    using Nttdata.Steven.Jurado.Repository.Sql.Context;

    public static class InjectionDependency
    {
        public static void StartInjectionDependency(this IServiceCollection services)
        {
            //Base Datos
            services.AddScoped<TransactionContext>();

            //Services
            services.AddScoped<IClientService, ClientService>();
            services.AddScoped<IBankAccountService, BankAccountService>();
            services.AddScoped<ITransactionService, TransactionService>();

            //Repositoy
            services.AddScoped<IClientRepository, ClientRepository>();
            services.AddScoped<IBankAccountRepository, BankAccountRepository>();
            services.AddScoped<ITransactionRepository, TransactionRepository>();
        }
    }
}
