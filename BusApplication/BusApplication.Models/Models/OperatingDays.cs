using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BusApplication.Models
{
    public class OperatingDays
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Poniedziałek")]
        public bool Monday { get; set; }

        [Required]
        [Display(Name = "Wtorek")]
        public bool Tuesday { get; set; }

        [Required]
        [Display(Name = "Środa")]
        public bool Wednesday { get; set; }

        [Required]
        [Display(Name = "Czwartek")]
        public bool Thursday { get; set; }

        [Required]
        [Display(Name = "Piątek")]
        public bool Friday { get; set; }

        [Required]
        [Display(Name = "Sobota")]
        public bool Saturday { get; set; }

        [Required]
        [Display(Name = "Niedziele i święta")]
        public bool SundayAndHolidays { get; set; }

    }
}
