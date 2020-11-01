using System;
using System.Collections.Generic;
using System.Text;

namespace BusApplication.Models.ViewModels
{
    public class LineTimetableDetailsForDaysVM
    {
        public int OperatingDay { get; set; }
        public IList<string> ArrivalsDepartures { get; set; }
    }
}
