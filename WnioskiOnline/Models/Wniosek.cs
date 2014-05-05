using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WnioskiOnline.Models
{
    [Table("Wnioski")]
    public class Wniosek
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int IdWniosku { get; set; }

        [Display(Name = "Tytuł wniosku ")]
        public string TytulWniosku {get; set;}

        public virtual Konkurs Konkurs { get; set; }


        public virtual UserProfile Wnioskodawca { get; set; }


        public virtual UserProfile Recenzent { get; set; }

        public virtual UserProfile CzlonekKomisji { get; set; }

        [Display(Name = "Ocena ")]
        public int Ocena { get; set; }

        [Display(Name = "Data złożenia ")]
        public DateTime DataZlozenia { get; set; }

        public Status Status { get; set; }

        public DateTime DataOceny { get; set; }
        public DateTime DataRozpatrzenia { get; set; }

    }

    public class WnioskiWnioskodawcaModel
    {
        public string Konkurs;
        public string TytulWniosku;
        public DateTime DataZlozenia;
        public string Status;
    }
}