using System;
using System.Collections.Generic;
using System.Text;

namespace BusApplication.DataAccess.DTOs
{
    public class LineInfoAsListDto
    {
        public LineInfoAsListDto(int id, string name, bool isActive, string stationList)
        {
            Id = id;
            Name = name;
            IsActive = isActive;
            StationList = stationList;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public string StationList { get; set; }
    }
}
