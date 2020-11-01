using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BusApplication.Models
{
    public class TicketPrice
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Cena za cały odcinek")]
        public float PricePerEntireRoute { get; set; }

        [Required]
        [Display(Name = "Cena za jeden segment")]
        public float PricePerSegment { get; set; }

    }
}
