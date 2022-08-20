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

    public class BankAccountService : IBankAccountService
    {

        private readonly IBankAccountRepository _bankAccountRepository;

        public BankAccountService(IBankAccountRepository bankAccountRepository)
        {
            _bankAccountRepository = bankAccountRepository;
        }


        public async Task<List<BankAccountRequest>> GetBankAccountsAsync()
        {
            var responseRepository = await _bankAccountRepository.GetBankAccountsAsyn();

            var responseConvert = ConvertHelper.ConvertType<List<BankAccountRequest>>(responseRepository);

            return responseConvert;
        }

        public async Task<BankAccountResponse> GetBankAccountIdAsync(Guid idBankAccount)
        {
            var responseRepository = await _bankAccountRepository.GetBankAccountIdAsyn(idBankAccount);

            var responseConvert = ConvertHelper.ConvertType<BankAccountResponse>(responseRepository);

            return responseConvert;
        }

        public async Task<bool> AddBankAccountAsync(BankAccountRequest bankAccountRequest)
        {
            var responseConvert = ConvertHelper.ConvertType<BankAccount>(bankAccountRequest);

            return await _bankAccountRepository.AddBankAccountAsyn(responseConvert);
        }

        public async Task<bool> UpdateBankAccountAsync(BankAccountRequest bankAccountRequest)
        {
            var responseConvert = ConvertHelper.ConvertType<BankAccount>(bankAccountRequest);

            return await _bankAccountRepository.UpdateBankAccountAsyn(responseConvert);
        }

        public async Task<bool> DeleteBankAccountsAsync(Guid idBankAccount)
        {

            return await _bankAccountRepository.DeleteBankAccountAsyn(idBankAccount);
        }

    }
}
