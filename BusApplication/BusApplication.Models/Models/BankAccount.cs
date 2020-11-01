using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BusApplication.Models
{
    public class BankAccount
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Nazwa odbiorcy")]
        public string CompanyName { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Adres odbiorcy")]
        public string CompanyAddress { get; set; }

        [Required]
        [StringLength(40)]
        [Display(Name = "Numer konta")]
        public string AccountNumber { get; set; }
    }
}
