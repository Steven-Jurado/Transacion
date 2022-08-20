namespace Nttdata.Steven.Jurado.Application.DTOs
{
    using Nttdata.Steven.Jurado.Domain.Helpers;
    using System;

    public class BankAccountResponse 
    {
        public Guid IdBankAccount { get; set; }

        public Guid IdUsuario { get; set; }

        public string BankAccountNumber { get; set; }

        public BankAccountType BankAccountType { get; set; }

        public decimal BankAccountBalance { get; set; }

        public Status BankAccountStatus { get; set; }

        public ClientRequest ClientNav { get; set; }
    }
}
