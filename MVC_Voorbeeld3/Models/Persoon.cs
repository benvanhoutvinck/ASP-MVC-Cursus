using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_Voorbeeld3.Models
{
    public class Persoon
    {
        public int ID { get; set; }
        public string Voornaam { get; set; }
        public string Familienaam { get; set; }
        public int Score { get; set; }
        [DisplayFormat(DataFormatString = "{0:#,##0.00}")]
        public decimal Wedde { get; set; }
        [Required(ErrorMessage = "Paswoord is een verplicht veld")]
        [StringLength(20, MinimumLength = 8, ErrorMessage = "Het paswoord bevat min. {2}, max. {1} tekens")]
        [DataType(DataType.Password)]
        public string Paswoord { get; set; }
        [Compare("Paswoord", ErrorMessage = "{0} verschilt van {1}")]
        public string HerhaalPaswoord { get; set; }
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        [Verleden(ErrorMessage = "Geboortedatum moet in het verleden liggen")]
        public DateTime Geboren { get; set; }
        public bool Gehuwd { get; set; }
        [DataType(DataType.MultilineText)]
        public string Opmerkingen { get; set; }
        public Geslacht Geslacht { get; set; }
    }
}