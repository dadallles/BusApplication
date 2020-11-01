using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BusApplication.Models
{
    public class ArrivalsDepartures
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Przyjazd")]
        public DateTime? ArrivalTime { get; set; }

        [Display(Name = "Odjazd")]
        public DateTime? DepartureTime { get; set; }

        public BusStop BusStop { get; set; }

        [ForeignKey("BusStop")]
        public int BusStopId { get; set; }

        public Timetable Timetable { get; set; }

        [ForeignKey("Timetable")]
        public int TimetableId { get; set; }

    }
}
