namespace Nttdata.Steven.Jurado.Domain.Entities
{
    using Nttdata.Steven.Jurado.Domain.Helpers;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Client : Person
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid IdClient { get; set; }
        
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public Status Status { get; set; } = Status.Inactive;

        [InverseProperty(nameof(BankAccount.ClientNav))]
        public ICollection<BankAccount> BankAccountNav { get; set; }
    }
}
