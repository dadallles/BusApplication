using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusApplication.Models.ViewModels
{
    public class AddNewRouteToTimetableVM
    {
        public Timetable Timetable { get; set; }
        public IEnumerable<SelectListItem> LineName { get; set; }
        public IEnumerable<SelectListItem> Wehicle { get; set; }
        public OperatingDays OperatingDays { get; set; }
        public TicketPrice TicketPrice { get; set; }
    }
}
