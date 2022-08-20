namespace Nttdata.Steven.Jurado.Repository.Interfaces
{
    using Nttdata.Steven.Jurado.Domain.Entities;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IBankAccountRepository
    {

        Task<List<BankAccount>> GetBankAccountsAsyn();
        Task<BankAccount> GetBankAccountIdAsyn(Guid idBankAccount);
        Task<bool> AddBankAccountAsyn(BankAccount bankAccount);
        Task<bool> UpdateBankAccountAsyn(BankAccount bankAccount);
        Task<bool> DeleteBankAccountAsyn(Guid idBankAccount);


    }
}
