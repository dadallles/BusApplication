using System;
using System.Collections.Generic;
using System.Text;

namespace BusApplication.DataAccess.DTOs
{
    public class BusStopDto
    {
        public BusStopDto(int number, string name)
        {
            Number = number;
            Name = name;
        }

        public int Number { get; set; }
        public string Name { get; set; }
    }
}
