using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BusApplication.Models
{
    public class Messages
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "E-mail")]
        [StringLength(100)]
        public string Mail { get; set; }

        [Required]
        [Display(Name = "Tytuł zgłoszenia")]
        [StringLength(100)]
        public string Title { get; set; }

        [Required]
        [Display(Name = "Treść")]
        public string Content { get; set; }

        [Required]
        [Display(Name = "Czas wysłania")]
        public DateTime Date { get; set; }

        [Required]
        [Display(Name = "Status")]
        public bool Status { get; set; }

    }
}
