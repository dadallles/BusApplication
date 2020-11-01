using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BusApplication.Models
{
    public class BusRoute
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Data")]
        public DateTime RouteDate { get; set; }

        [Required]
        [Display(Name = "Dostępne miejsca")]
        public int AvailableSeats { get; set; }

        public Timetable Timetable { get; set; }

        [ForeignKey("Timetable")]
        public int TimetableId { get; set; }

        public IList<Tickets> Tickets { get; set; }

    }
}
