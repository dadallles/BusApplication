using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BusApplication.Models
{
    public class BusStop
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name="Przystanek")]
        public string Name { get; set; }

        [Required]
        [Display(Name="Aktywny")]
        public bool IsActive { get; set; }

        public IList<BusStopList> BusStopList { get; set; }

        public IList<ArrivalsDepartures> ArrivalsDepartures { get; set; }

    }
}
