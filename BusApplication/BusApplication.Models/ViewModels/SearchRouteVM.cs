using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Text;

namespace BusApplication.Models.ViewModels
{
    public class SearchRouteVM
    {
        [Display(Name = "Stacja początkowa")]
        [Required]
        public IEnumerable<SelectListItem> BusStopListStart { get; set; }

        [Required]
        public int BusStopListStartId { get; set; }

        [Display(Name = "Stacja końcowa")]
        [Required]
        public IEnumerable<SelectListItem> BusStopListEnd { get; set; }

        [Required]
        public int BusStopListEndId { get; set; }

        [Display(Name = "Czas odjazdu")]
        [Required]
        public DateTime StartTime { get; set; }

        public IList<SearchRouteShowRouteVM> searchRouteShowRouteVMs { get; set; }
    }
}
