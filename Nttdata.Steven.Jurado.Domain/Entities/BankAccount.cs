namespace Nttdata.Steven.Jurado.Domain.Entities
{
    using Nttdata.Steven.Jurado.Domain.Helpers;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class BankAccount
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid IdBankAccount { get; set; }

        public Guid IdUsuario { get; set; }

        [Required]
        [RegularExpression("[0-9]")]
        [MaxLength(16)]
        public string BankAccountNumber { get; set; }

        [Required]
        public BankAccountType BankAccountType { get; set; }

        [Required]
        [DataType("decimal(4,2)")]
        public decimal BankAccountBalance { get; set; }

        public Status BankAccountStatus { get; set; } = Status.Inactive;


        [ForeignKey(nameof(IdUsuario))]
        [InverseProperty(nameof(Client.BankAccountNav))]
        public Client ClientNav { get; set; }

        [InverseProperty(nameof(Transaction.BankAccountNav))]
        public ICollection<Transaction> TransactionsNav { get; set; }
    }
}
