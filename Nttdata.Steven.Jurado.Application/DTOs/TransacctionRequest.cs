namespace Nttdata.Steven.Jurado.Application.DTOs
{
    using Nttdata.Steven.Jurado.Domain.Entities;
    using Nttdata.Steven.Jurado.Domain.Helpers;
    using System;
    using System.ComponentModel.DataAnnotations;

    public class TransacctionRequest
    {
        public Guid IdTransaction { get; set; }

        public Guid IdBankAccount { get; set; }

        [Required]
        public DateTime TransactionDate { get; set; } = DateTime.Now;

        [Required]
        public BankAccountType TransactionType { get; set; }

        [Required]
        [DataType("decimal(4,2)")]
        public decimal TransactionValue { get; set; }

    }
}
