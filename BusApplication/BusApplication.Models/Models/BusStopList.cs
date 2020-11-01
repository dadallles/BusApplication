using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BusApplication.Models
{
    public class BusStopList
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Nr.")]
        public int BusStopNumber { get; set; }

        public BusStop BusStop { get; set; }

        [ForeignKey("BusStop")]
        public int BusStopId { get; set; }

        public LineName LineName { get; set; }

        [ForeignKey("LineName")]
        public int LineNameId { get; set; }

        

    }
}
