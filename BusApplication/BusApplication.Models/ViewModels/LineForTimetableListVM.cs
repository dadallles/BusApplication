using System;
using System.Collections.Generic;
using System.Text;

namespace BusApplication.Models.ViewModels
{
    public class LineForTimetableListVM
    {
        public LineForTimetableListVM(int id, string name, string stationList)
        {
            Id = id;
            Name = name;
            StationList = stationList;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string StationList { get; set; }
    }
}
