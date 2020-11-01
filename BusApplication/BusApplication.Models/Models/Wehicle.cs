using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BusApplication.Models
{
    public class Wehicle
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name="Marka")]
        [StringLength(50)]
        public string Brand { get; set; }

        [Required]
        [Display(Name = "Model")]
        [StringLength(50)]
        public string Model { get; set; }

        [Required]
        [Display(Name = "Rok produkcji")]
        public int YearOfManufacture { get; set; }

        [DataType(DataType.ImageUrl)]
        [Display(Name = "Zdjęcie")]
        public string ImageUrl { get; set; }

        [Required]
        [Display(Name = "Liczba miejsc siedzących")]
        public int NumberOfSeats { get; set; }


        [Display(Name = "Opis")]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Aktywny")]
        public bool IsActive { get; set; }

        [Required]
        [Display(Name = "Klimatyzacja")]
        public bool AirConditioning { get; set; }

        [Required]
        [Display(Name = "Klasa premium")]
        public bool PremiumClass { get; set; }

        [Required]
        [Display(Name = "WC")]
        public bool Toilet { get; set; }

        public IList<Timetable> Timetable { get; set; }

    }
}
