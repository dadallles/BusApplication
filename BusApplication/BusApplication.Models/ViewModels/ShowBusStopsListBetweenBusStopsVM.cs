using System;
using System.Collections.Generic;
using System.Text;

namespace BusApplication.Models.ViewModels
{
    public class ShowBusStopsListBetweenBusStopsVM
    {
        public int TimetableId { get; set; } 
        public int BusStopListStartId { get; set; } 
        public int BusStopListEndId { get; set; }
    }
}
