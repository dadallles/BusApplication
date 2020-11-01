using System;
using System.Collections.Generic;
using System.Text;

namespace BusApplication.Models.ViewModels
{
    public class SearchRouteShowRouteVM
    {
        public int TimetableId { get; set; }
        public string LineName { get; set; }
        public string StartBusStopName { get; set; }
        public string DepartureTime { get; set; }
        public string EndBusStopName { get; set; }
        public string ArrivalTime { get; set; }
    }
}
