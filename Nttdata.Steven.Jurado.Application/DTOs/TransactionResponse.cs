namespace Nttdata.Steven.Jurado.Application.DTOs
{
    using Nttdata.Steven.Jurado.Domain.Helpers;
    using System;

    public class TransactionResponse
    {
        public Guid IdTransaction { get; set; }
        public DateTime TransactionDate { get; set; }
        public string Name { get; set; }
        public string BankAccountNumber { get; set; }
        public BankAccountType BankAccountType { get; set; }
        public decimal BankAccountBalance { get; set; }
        public decimal TransactionValue { get; set; }
    }
}
