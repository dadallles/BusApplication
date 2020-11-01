using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BusApplication.Models
{
    public class Timetable
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Aktywny")]
        public bool IsActive { get; set; }

        public LineName LineName { get; set; }

        [ForeignKey("LineName")]
        public int LineNameId { get; set; }

        public Wehicle Wehicle { get; set; }

        [ForeignKey("Wehicle")]
        public int WehicleId { get; set; }

        public OperatingDays OperatingDays { get; set; }

        [ForeignKey("OperatingDays")]
        public int OperatingDaysId { get; set; }

        public IList<ArrivalsDepartures> ArrivalsDepartures { get; set; }

        public TicketPrice TicketPrice { get; set; }

        [ForeignKey("TicketPrice")]
        public int TicketPriceId { get; set; }

        public IList<BusRoute> BusRoute { get; set; }



    }
}
