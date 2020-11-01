using System;
using System.Collections.Generic;
using System.Text;

namespace BusApplication.Models.ViewModels
{
    public class BusStopBetweenBusStopsVM
    {
        public string BusStopName { get; set; }
        public string? ArrivalTime { get; set; }
        public string? DepartureTime { get; set; }
    }
}
