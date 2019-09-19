using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace Eventures.Services.Models
{
    using System;

    public class EventCreateBindingModel
    {
        [Required]
        [MinLength(10, ErrorMessage = "The name must be at least 10 characters long.")]
        public string  Name { get; set; }

        [Required]
        [RegularExpression(@"^\w.+\w$", ErrorMessage = "Please enter a valid, non-empty name for the Event's place, you may have to remove unnecessary empty spaces!")]
        public string Place { get; set; }

        public DateTime Start { get; set; }
        public DateTime End { get; set; }

        [Required]
        [RegularExpression(@"^\d{2}/\d{2}/\d{4} \d{2}:\d{2}$", ErrorMessage = "Please enter a valid start date in the format dd/MM/yyyy HH:mm, for example 21/11/2018 21:00")]
        public string StartString { get; set; }

        [Required]
        [RegularExpression(@"^\d{2}/\d{2}/\d{4} \d{2}:\d{2}$", ErrorMessage = "Please enter a valid start date in the format dd/MM/yyyy HH:mm, for example 21/11/2018 21:00")]
        public string EndString { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public int TotalTickets { get; set; }

        [Required]
        [Range(typeof(decimal), "0", "79228162514264337593543950335", ErrorMessage = "Please enter a valid price!")]
        public decimal PricePerTicket { get; set; }
    }
}
