namespace Nttdata.Steven.Jurado.Application.DTOs
{
    using Nttdata.Steven.Jurado.Domain.Helpers;
    using System;
    using System.ComponentModel.DataAnnotations;

    public class ClientRequest
    {
        public Guid IdClient { get; set; }

        public string UserName { get; set; }

        [Required(ErrorMessage = "Campo Requerido")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Campo Requerido")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Campo Requerido")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Campo Requerido")]
        [RegularExpression("^([0-9]){10}", ErrorMessage = "Campo solo permite Numero con longitud de 10 caracteres")]
        public string Telephone { get; set; }

        [Required(ErrorMessage = "Campo Requerido")]
        public Gender Gender { get; set; }

        [RegularExpression("^([0-9]){1,2}", ErrorMessage = "Campo solo permite Numero con longitud de 2 caracteres")]
        public int Age { get; set; }

        public Status Status { get; set; } = Status.Inactive;

    }
}
