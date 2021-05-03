using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Projekt.Models

{
    public class User
    {
        public int ID { get; set; }
        [Required]
        public string Navn { get; set; }
        [Required(ErrorMessage = "Emailen er ugyldig, prøv igen.")]
        public string Email { get; set; }

        [Required]
        [StringLength(8, ErrorMessage = "Passworded skal indeholde 8 tegn.")]
        public string PassWord { get; set; }

        public string UserType { get; set; }
        public override string ToString()
        {
            return $"ID: {ID} Navn: {Navn} Email: {UserType}";
        }

    }

}
