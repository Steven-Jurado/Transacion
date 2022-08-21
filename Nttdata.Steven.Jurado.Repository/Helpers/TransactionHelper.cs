namespace Nttdata.Steven.Jurado.Repository.Helpers
{
    using Nttdata.Steven.Jurado.Domain.Helpers;
    using System;

    public class TransactionHelper
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
