using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BusApplication.Models
{
    public class Payment
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Wartość")]
        public float Value { get; set; }

        [Required]
        [Display(Name = "Staus")]
        [StringLength(10)]
        public string Status { get; set; }

        [Display(Name = "Data zatwierdzenia")]
        public DateTime ConfirmationDate { get; set; }

        [Display(Name = "Data anulacji")]
        public DateTime CanceledDate { get; set; }

        public ApplicationUser ApplicationUser { get; set; }

        [ForeignKey("ApplicationUser")]
        public string ChangedBy { get; set; }

        //public ApplicationUser ApplicationUserCanceled { get; set; }

        //[ForeignKey("ApplicationUserCanceled")]
        //public string CanceledBy { get; set; }

    }
}
