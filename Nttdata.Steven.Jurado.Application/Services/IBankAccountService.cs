namespace Nttdata.Steven.Jurado.Application.Services
{
    using Nttdata.Steven.Jurado.Application.DTOs;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IBankAccountService
    {
        Task<List<BankAccountRequest>> GetBankAccountsAsync();
        Task<BankAccountResponse> GetBankAccountIdAsync(Guid idBankAccount);
        Task<bool> AddBankAccountAsync(BankAccountRequest bankAccountRequest);
        Task<bool> UpdateBankAccountAsync(BankAccountRequest bankAccountRequest);
        Task<bool> DeleteBankAccountsAsync(Guid idBankAccount);
    }
}
