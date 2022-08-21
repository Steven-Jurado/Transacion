namespace Nttdata.Steven.Jurado.Domain.Entities
{
    using Nttdata.Steven.Jurado.Domain.Helpers;
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Transaction
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid IdTransaction { get; set; }

        public Guid IdBankAccount { get; set; }

        [Required]
        public DateTime TransactionDate { get; set; } = DateTime.Now;

        public BankAccountType TransactionType { get; set; }

        [Required]
        [DataType("decimal(4,2)")]
        public decimal TransactionValue { get; set; }

        [ForeignKey(nameof(IdBankAccount))]
        [InverseProperty(nameof(BankAccount.TransactionsNav))]
        public BankAccount BankAccountNav { get; set; }

    }
}
