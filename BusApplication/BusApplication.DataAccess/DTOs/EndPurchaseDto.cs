using System;
using System.Collections.Generic;
using System.Text;

namespace BusApplication.DataAccess.DTOs
{
    public class EndPurchaseDto
    {
        public int NumberOfNormalTickets { get; set; }
        public int NumberOfStudentsTickets { get; set; }
        public int NumberOfExtraBaggages { get; set; }
        public bool IsEntireRoute { get; set; }
        public int NumberOfBusStops { get; set; }
        public int BusRouteId { get; set; }
        public string StartBusStopName { get; set; }
        public DateTime DepartureTime { get; set; }
        public string EndBusStopName { get; set; }
        public DateTime ArrivalTime { get; set; }
    }
}
