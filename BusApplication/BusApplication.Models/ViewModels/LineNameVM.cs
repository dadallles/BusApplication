using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BusApplication.Models.ViewModels
{
    public class LineNameVM
    {
        [Required]
        [Display(Name = "Wybierz liczbę przystanków")]
        public int NumberOfBusStops { get; set; }

        public LineName lineName { get; set; }

        public IList<BusStopList> busStopList { get; set; }

        public IEnumerable<SelectListItem> BusStopListItem { get; set; }

        [Display(Name = "Dodaj trasę powrotną")]
        public bool IsReversedToo { get; set; }

        [Display(Name = "Nazwa trasy powrotnej")]
        public string ReversedLineName { get; set; }

    }
}
