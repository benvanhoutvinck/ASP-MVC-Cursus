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
        public string Paswoord { get; set; }
        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime Geboren { get; set; }
        public bool Gehuwd { get; set; }
        public string Opmerkingen { get; set; }
        public Geslacht Geslacht { get; set; }
    }
}