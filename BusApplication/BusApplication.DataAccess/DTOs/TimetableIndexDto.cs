using System;
using System.Collections.Generic;
using System.Text;

namespace BusApplication.DataAccess.DTOs
{
    public class TimetableIndexDto
    {
        public int Id { get; set; }
        public string LineName { get; set; }
        public string Wehicle { get; set; }
        public string OperatingDays { get; set; }
        public string DepartureTime { get; set; }
        public float PricePerEntireRoute { get; set; }
        public float PricePerSegment { get; set; }
        public bool IsActive { get; set; }
    }
}
