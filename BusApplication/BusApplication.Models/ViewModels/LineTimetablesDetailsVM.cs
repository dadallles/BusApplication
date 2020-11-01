using System;
using System.Collections.Generic;
using System.Text;

namespace BusApplication.Models.ViewModels
{
    public class LineTimetablesDetailsVM
    {
        public string LineName { get; set; }
        public IList<string> BusStopsList { get; set; }
        public IList<LineTimetableDetailsForDaysVM> LineTimetableDetailsForDays { get; set; }
    }
}
