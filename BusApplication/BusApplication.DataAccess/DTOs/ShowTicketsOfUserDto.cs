using System;
using System.Collections.Generic;
using System.Text;

namespace BusApplication.DataAccess.DTOs
{
    public class ShowTicketsOfUserDto
    {
        public int TicketId { get; set; }
        public string Date { get; set; }
        public string StartBusStopName { get; set; }
        public string Departure { get; set; }
        public string EndBusStopName { get; set; }
        public string Arrival { get; set; }
        public int NumberOfNormalTickets { get; set; }
        public int NumberOfStudentsTickets { get; set; }
        public int NumberOfExtraBaggages { get; set; }
        public string PaymentStatus { get; set; }
    }
}
