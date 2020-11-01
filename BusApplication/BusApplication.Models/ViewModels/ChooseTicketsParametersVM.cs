using System;
using System.Collections.Generic;
using System.Text;

namespace BusApplication.Models.ViewModels
{
    public class ChooseTicketsParametersVM
    {
        public BusRoute BusRoute { get; set; }
        public string StartBusStopName { get; set; }
        public string EndBusStopName { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
        public bool IsEntireRoute { get; set; }
        public int NumberOfBusStops { get;set; }
        public float Price { get; set; }
        public float ExtraBaggagePrice { get; set; }
        public int NumberOfNormalTickets { get; set; }
        public int NumberOfStudentsTickets { get; set; }
        public int NumberOfExtraBaggages { get; set; }
        public Wehicle Wehicle { get; set; }
    }
}
