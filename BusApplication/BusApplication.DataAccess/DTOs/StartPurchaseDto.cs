using System;
using System.Collections.Generic;
using System.Text;

namespace BusApplication.DataAccess.DTOs
{
    public class StartPurchaseDto
    {
        public int TimetableId { get; set; }
        public DateTime StartTime { get; set; }
        public int BusStopListStartId { get; set; }
        public int BusStopListEndId { get; set; }
    }
}
