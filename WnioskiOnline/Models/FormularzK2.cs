using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WnioskiOnline.Models
{
    [Table("FormularzeK2")]
    public class FormularzK2
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int IdFormularza{ get; set; }


        public int IdWniosku { get; set; }

        [ForeignKey("IdWniosku")]
        public virtual Wniosek Wniosek { get; set; }

        public int IdOrganizacji { get; set; }

        [ForeignKey("IdOrganizacji")]
        public virtual Organizacja Organizacja { get; set; }

        public int? IdPierwszegoKoord { get; set; }

        [Display(Name = "Koordynator projektu: ")]
        [ForeignKey("IdPierwszegoKoord")]
        public virtual Koordynator PierwszyKoord { get; set; }

        public int? IdDrugiegoKoord { get; set; }

        [Display(Name = "Drugi koordynator projektu: ")]
        [ForeignKey("IdDrugiegoKoord")]
        public virtual Koordynator DrugiKoord { get; set; }

        [Display(Name = "Kwota wnioskowana: ")]
        public double KwotaWnioskowana { get; set; }

        
        [Display(Name = "Zasięg zadania: ")]
        public int IdZasiegu { get; set; }

       
        [ForeignKey("IdZasiegu")]
        public virtual Zasieg Zasieg { get; set; }

        [Display(Name = "Charakter zadania: ")]
        public int IdCharakteru { get; set; }

        [ForeignKey("IdCharakteru")]
        public virtual Charakter Charakter { get; set; }

        [Display(Name = "Uzasadnienie celowości realizowanego zadania, przewidywane efekty merytoryczne")]
        [MaxLength(500)]
        [StringLength(500, ErrorMessage = "Informacja nie może mieć więcej niż 500 znaków.")]
        public string Celowosc { get; set; }

        [Display(Name = "Dlaczego ten projekt zasługuje na sfinansowanie jego realizacji? ")]
        [MaxLength(500)]
        [StringLength(500, ErrorMessage = "Informacja nie może mieć więcej niż 500 znaków.")]
        public string DlaczegoZasluguje { get; set; }

        [Display(Name = "W czym jest lepszy (co nowego wnosi - czym się wyróżnia) od innych projektów? ")]
        [MaxLength(500)]
        [StringLength(500, ErrorMessage = "Informacja nie może mieć więcej niż 500 znaków.")]
        public string DlaczegoLepszy { get; set; }

        [Display(Name = "W jakim stopniu jest innowacyjny? ")]
        [MaxLength(500)]
        [StringLength(500, ErrorMessage = "Informacja nie może mieć więcej niż 500 znaków.")]
        public string StopienInnowacji { get; set; }

        [Display(Name = "Jak bardzo angażuje studentów i doktorantów Politechniki Wrocławskiej (ilość osób, czas itd.)")]
        [MaxLength(500)]
        [StringLength(500, ErrorMessage = "Informacja nie może mieć więcej niż 500 znaków.")]
        public string JakAngazuje { get; set; }

        [Display(Name = "Jakie warunki lokalowe są niezbędne do jego realizacji a jakie posiada organizacja wnioskująca?")]
        [MaxLength(500)]
        [StringLength(500, ErrorMessage = "Informacja nie może mieć więcej niż 500 znaków.")]
        public string JakieWarunki { get; set; }

        [Display(Name = "Jakie i ile projektów o podobnej skali zrealizował już główny koordynator (wymienić kiedy, gdzie oraz budżet projektu)")]
        [MaxLength(500)]
        [StringLength(500, ErrorMessage = "Informacja nie może mieć więcej niż 500 znaków.")]
        public string JakiePodobnePierwszy { get; set; }

        [Display(Name = "Jakie i ile projektów o podobnej skali zrealizował już drugi koordynator (wymienić kiedy, gdzie oraz budżet projektu)")]
        [MaxLength(500)]
        [StringLength(500, ErrorMessage = "Informacja nie może mieć więcej niż 500 znaków.")]
        public string JakiePodobneDrugi { get; set; }

        [Display(Name = "Jaki jest planowany finansowy wkład własny uczestników i organizatorów w realizację projektu? ")]
        [MaxLength(500)]
        [StringLength(500, ErrorMessage = "Informacja nie może mieć więcej niż 500 znaków.")]
        public string WkladFinansowy { get; set; }

        [Display(Name = "Jakie podjęto środki celem znalezienia sponsorów spoza Politechniki Wrocławskiej - i z jakim skutkiem (ile firm i instytucji zapytano itp.)")]
        [MaxLength(500)]
        [StringLength(500, ErrorMessage = "Informacja nie może mieć więcej niż 500 znaków.")]
        public string Sponsorzy { get; set; }

        [Display(Name = "W jaki sposób projekt będzie promował Uczelnię oraz studentów/doktorantów Politechniki Wrocławskiej?")]
        [MaxLength(500)]
        [StringLength(500, ErrorMessage = "Informacja nie może mieć więcej niż 500 znaków.")]
        public string JakPromuje { get; set; }

        [Display(Name = "Inne informacje, jakie wnioskodawca chciałby przekazać Komisji celem wykazania istotności planowanego do zrealizowania projektu.")]
        [MaxLength(500)]
        [StringLength(500, ErrorMessage = "Informacja nie może mieć więcej niż 500 znaków.")]
        public string InneInformacje { get; set; }


    }
}