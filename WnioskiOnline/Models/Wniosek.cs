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

        [Display(Name = "Tytuł")]
        public string TytulWniosku { get; set; }

        public int IdKonkursu { get; set; }

        [ForeignKey("IdKonkursu")]
        public virtual Konkurs Konkurs { get; set; }

        [ForeignKey("Dziedzina")]
        public int? IdDziedziny { get; set; }

        [Display(Name = "Dziedzina")]
        public virtual Dziedzina Dziedzina { get; set; }

        [ForeignKey("Decyzja")]
        public int? IdDecyzji { get; set; }

        [Display(Name = "Decyzja")]
        public virtual Decyzja Decyzja { get; set; }

        public int IdWnioskodawcy { get; set; }

        [ForeignKey("IdWnioskodawcy")]
        public virtual UserProfile Wnioskodawca { get; set; }

        public int? IdRecenzenta { get; set; }

        [ForeignKey("IdRecenzenta")]
        public virtual UserProfile Recenzent { get; set; }

        public int? IdCzlonkaKomisji { get; set; }

        [ForeignKey("IdCzlonkaKomisji")]
        public virtual UserProfile CzlonekKomisji { get; set; }

        [Display(Name = "Ocena ")]
        public int? Ocena { get; set; }

        [Display(Name = "Data złożenia ")]
        public DateTime DataZlozenia { get; set; }

        public int IdStatusu { get; set; }

        [ForeignKey("IdStatusu")]
        public virtual Status Status { get; set; }

        public DateTime? DataOceny { get; set; }
        public DateTime? DataRozpatrzenia { get; set; }

    }
}