using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Projekt.Models
{
    public class Kursus
    {

        public int ID { get; set; }
        [Display(Name = "Event navn")]
        [Required(ErrorMessage = "Navngivning af evnet er påkrævet"), MaxLength(30)]

        public string Navn { get; set; }

        public string Beskrivelse { get; set; }



        [Required]
        [StringLength(18, ErrorMessage = "Navngivning af Lærer og rum kan ikke være længere en 12 karaktere.")]
        
        public string Underviser { get; set; }
            
        public string Lokale { get; set; }

        [Required(ErrorMessage = "Datoen er påkrævet!")]
        [Range(typeof(DateTime), "17/12/2020", "01/01/2022", ErrorMessage = "Værdi for {0} skal være mellem {1} og {2}")]

        public DateTime DateTime { get; set; }

        //[Required]
        //[StringLength(1, ErrorMessage = "Der er nød til at være minimum en person som deltager i kurset.")]
        //public int AntalMin { get; set; }

        //[Required]
        //[StringLength(2, ErrorMessage = "Der skal være et maximum antal personer som deltager i kurset")]
        //public int AntalMax { get; set; }
    }
}
