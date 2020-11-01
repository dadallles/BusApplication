using System;
using System.Collections.Generic;
using System.Text;

namespace BusApplication.Models.ViewModels
{
    public class ArrivalDepartureBusStopListVM
    {
        public ArrivalDepartureBusStopListVM()
        {
        }

        public ArrivalDepartureBusStopListVM(IList<ArrivalDepartureBusStopVM> arrivalDepartureBusStopListVM, int timetableId)
        {
            this.arrivalDepartureBusStopListVM = arrivalDepartureBusStopListVM;
            TimetableId = timetableId;
        }

        public IList<ArrivalDepartureBusStopVM> arrivalDepartureBusStopListVM { get; set; }
        public int TimetableId { get; set; }
    }
}
