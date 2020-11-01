using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BusApplication.Models.ViewModels
{
    public class BusStopWithNumberForLineVM
    {
        [Required]
        public int Number { get; set; }

        [Required]
        public string Name { get; set; }

        public BusStopWithNumberForLineVM(int busStopNumber, string name)
        {
            Number = busStopNumber;
            Name = name;
        }
    }
}
