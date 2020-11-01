using System;
using System.Collections.Generic;
using System.Text;

namespace BusApplication.Models.ViewModels
{
    public class ArrivalDepartureBusStopVM
    {
        public ArrivalDepartureBusStopVM()
        {
        }

        public ArrivalDepartureBusStopVM(int busStopId, string busStopName, DateTime? arrivalTime, DateTime? departureTime)
        {
            BusStopId = busStopId;
            BusStopName = busStopName;
            ArrivalTime = arrivalTime;
            DepartureTime = departureTime;
        }

        public int BusStopId { get; set; }
        public string BusStopName { get; set; }
        public DateTime? ArrivalTime { get; set; }
        public DateTime? DepartureTime { get; set; }
    }
}
