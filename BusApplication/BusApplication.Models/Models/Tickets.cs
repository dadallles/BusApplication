using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BusApplication.Models
{
    public class Tickets
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Bilet normalny")]
        public int NumberOfRegularTickets { get; set; }

        [Required]
        [Display(Name = "Bilet studencki")]
        public int NumberOfStudentsTickets { get; set; }

        [Required]
        [Display(Name = "Dodatkowy bagaż")]
        public int NumberOfExtraBaggages { get; set; }

        [Required]
        [Display(Name = "Data zakupu")]
        public DateTime PurchaseDates { get; set; }

        [Required]
        [Display(Name = "Przystanek początkowy")]
        public string StartBusStopName { get; set; }

        [Required]
        [Display(Name = "Odjazd")]
        public DateTime Departure { get; set; }

        [Required]
        [Display(Name = "Przystanek końcowy")]
        public string EndBusStopName { get; set; }

        [Required]
        [Display(Name = "Przyjazd")]
        public DateTime Arrival { get; set; }

        public BusRoute BusRoute { get; set; }

        [ForeignKey("BusRoute")]
        public int BusRouteId { get; set; }

        public Payment Payment { get; set; }

        [ForeignKey("Payment")]
        public int PaymentId { get; set; }

        public ApplicationUser ApplicationUser { get; set; }

        [ForeignKey("ApplicationUser")]
        public string ApplicationUserId { get; set; }

    }
}
