using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WnioskiOnline.Models
{
    [Table("FormularzeK3")]
    public class FormularzK3
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int IdFormularza { get; set; }

        [ForeignKey("Wniosek")]
        public int? IdWniosku { get; set; }

        public virtual Wniosek Wniosek { get; set; }

        [ForeignKey("Organizacja")]
        public int IdOrganizacji { get; set; }

        public virtual Organizacja Organizacja { get; set; }

        public string NazwaProjektu { get; set; }

        public int? IdPierwszegoKoord { get; set; }

        [Display(Name = "Koordynator projektu: ")]
        [ForeignKey("IdPierwszegoKoord")]
        public virtual Koordynator PierwszyKoord { get; set; }

        public int? IdDrugiegoKoord { get; set; }

        [Display(Name = "Drugi koordynator projektu: ")]
        [ForeignKey("IdDrugiegoKoord")]
        public virtual Koordynator DrugiKoord { get; set; }

        [ForeignKey("Dziedzina")]
        public int IdDziedziny { get; set; }

        [Display(Name = "Dziedzina projektu: ")]
        public virtual Dziedzina Dziedzina { get; set; }

        [Display(Name = "Termin projektu: ")]
        public DateTime Termin { get; set; }

        [Display(Name = "Liczba studentów zaangażowanych w projekt")]
        public int LiczbaStudZaang { get; set; }

        [Display(Name = "Liczba studentów korzystających z projektu")]
        public int LiczbaStudKorzyst { get; set; }

        [ForeignKey("Zasieg")]
        public int IdZasiegu { get; set; }

        [Display(Name = "Zasięg zadania: ")]
        public virtual Zasieg Zasieg { get; set; }

        [ForeignKey("Charakter")]
        public int IdCharakteru { get; set; }

        [Display(Name = "Charakter zadania: ")]
        public virtual Charakter Charakter { get; set; }

        [Display(Name = "Uzasadnienie celowości realizowanego zadania, przewidywane efekty merytoryczne: ")]
        public string Uzasadnienie { get; set; }

        [Display(Name = "Uwagi dodatkowe: ")]
        public string Uwagi { get; set; }

        [Display(Name = "Wniosek zawiera: ")]
        public string WniosekZawiera { get; set; }

        public string Zalacznik { get; set; }
    }
}