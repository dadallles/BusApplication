using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BusApplication.Models
{
    public class LineName
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name="Nazwa linii")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Aktywna")]
        public bool IsActive { get; set; }

        public IList<BusStopList> BusStopList { get; set; }

        public IList<Timetable> Timetable { get; set; }
    }
}
