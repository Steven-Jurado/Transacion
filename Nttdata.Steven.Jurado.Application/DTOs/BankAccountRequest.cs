namespace Nttdata.Steven.Jurado.Application.DTOs
{
    using Nttdata.Steven.Jurado.Domain.Helpers;
    using System;
    using System.ComponentModel.DataAnnotations;

    public class BankAccountRequest
    {

        [Required(ErrorMessage = "Campo Requerido")]
        public Guid IdUsuario { get; set; }

        [Required(ErrorMessage = "Campo Requerido")]
        [RegularExpression("^([0-9]){6,16}", ErrorMessage = "Campo solo permite numeros entre 10 - 16 caracteres")]
        public string BankAccountNumber { get; set; }

        [Required(ErrorMessage = "Campo Requerido")]
        public BankAccountType BankAccountType { get; set; }

        [Required(ErrorMessage = "Campo Requerido")]
        [DataType("decimal(4,2)")]
        public decimal BankAccountBalance { get; set; }


        public decimal BankAccountAvailableBalance { get; set; }


        public Status BankAccountStatus { get; set; } = Status.Inactive;
    }
}
