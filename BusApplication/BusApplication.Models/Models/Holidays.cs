using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BusApplication.Models
{
    public class Holidays
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Nazwa święta")]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Miesiąc")]
        public int Month { get; set; }

        [Required]
        [Display(Name = "Dzień")]
        public int Day { get; set; }

    }
}
