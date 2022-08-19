namespace Nttdata.Steven.Jurado.Domain.Entities
{
    using Nttdata.Steven.Jurado.Domain.Helpers;
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Person
    {
        
        [Required]
        [MaxLength(150)]
        public string Name { get; set; }

        [Required]
        [MaxLength(150)]
        public string Address { get; set; }

        [RegularExpression("[0-9]", ErrorMessage = "Campo solo permite Numero")]
        public string Telephone { get; set; }

        public Gender Gender { get; set; }

        public int Age { get; set; }
    }
}
