﻿using System;
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

        public virtual Wniosek Wniosek { get; set; }

        public string TytulProjektu { get; set; }


        public virtual Organizacja Organizacja { get; set; }


        public virtual Koordynator PierwszyKoord { get; set; }


        public virtual Koordynator DrugiKoord { get; set; }

        public double KwotaWnioskowana { get; set; }

        public virtual Dziedzina Dziedzina { get; set; }

        // koszty

        // harmonogram

        public virtual Zasieg Zasieg { get; set; }

        public virtual Charakter Charakter { get; set; }

        [Display(Name = "Uzasadnienie celowości realizowanego zadania, przewidywane efekty merytoryczne")]
        public string Celowosc { get; set; }

        [Display(Name = "Dlaczego ten projekt zasługuje na sfinansowanie jego realizacji? ")]
        public string DlaczegoZasluguje { get; set; }

        [Display(Name = "W czym jest lepszy (co nowego wnosi - czym się wyróżnia) od innych projektów? ")]
        public string DlaczegoLepszy { get; set; }

        [Display(Name = "W jakim stopniu jest innowacyjny? ")]
        public string StopienInnowacji { get; set; }

        [Display(Name = "Jak bardzo angażuje studentów i doktorantów Politechniki Wrocławskiej (ilość osób, czas itd.)")]
        public string JakAngazuje { get; set; }

        [Display(Name = "Jakie warunki lokalowe są niezbędne do jego realizacji a jakie posiada organizacja wnioskująca?")]
        public string JakieWarunki { get; set; }

        [Display(Name = "Jakie i ile projektów o podobnej skali zrealizował już główny koordynator (wymienić kiedy, gdzie oraz budżet projektu)")]
        public string JakiePodobnePierwszy { get; set; }

        [Display(Name = "Jakie i ile projektów o podobnej skali zrealizował już drugi koordynator (wymienić kiedy, gdzie oraz budżet projektu)")]
        public string JakiePodobneDrugi { get; set; }

        [Display(Name = "Jaki jest planowany finansowy wkład własny uczestników i organizatorów w realizację projektu? ")]
        public string WkladFinansowy { get; set; }

        [Display(Name = "Jakie podjęto środki celem znalezienia sponsorów spoza Politechniki Wrocławskiej - i z jakim skutkiem (ile firm i instytucji zapytano itp.)")]
        public string Sponsorzy { get; set; }

        [Display(Name = "W jaki sposób projekt będzie promował Uczelnię oraz studentów/doktorantów Politechniki Wrocławskiej?")]
        public string JakPromuje { get; set; }

        [Display(Name = "Inne informacje, jakie wnioskodawca chciałby przekazać Komisji celem wykazania istotności planowanego do zrealizowania projektu.")]
        public string InneInformacje { get; set; }

        // zrodla finansowania

    }
}