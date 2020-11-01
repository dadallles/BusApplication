using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BusApplication.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        [Display(Name = "Imię")]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Nazwisko")]
        [StringLength(100)]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Miasto")]
        [StringLength(50)]
        public string City { get; set; }

        [Required]
        [Display(Name = "Kod pocztowy")]
        [StringLength(10)]
        public string PostalCode { get; set; }

        [Required]
        [Display(Name = "Ulica")]
        [StringLength(100)]
        public string Street { get; set; }

        [Required]
        [Display(Name = "Nr. domu")]
        public int HouseNumber { get; set; }

        [Display(Name = "Nr. mieszkania")]
        public int? FlatNumber { get; set; }

        public IList<Tickets> Tickets { get; set; }

        public IList<Payment> Payment { get; set; }

    }
}
