using System;
using System.Collections.Generic;
using System.Text;

namespace BusApplication.Models.ViewModels
{
    public class LineListForTimetableListVM
    {
        public IList<LineForTimetableListVM> lineForTimetableListVMs { get; set; }
    }
}
