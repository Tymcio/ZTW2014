﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WnioskiOnline.Models
{
    [Table("FormularzeK1N")]
    public class FormularzK1N
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int IdFormularza { get; set; }

        public Wniosek Wniosek { get; set; }

        public string CelProjektu { get; set; }

        public string InfoOWarunkach { get; set; }

        public string StanZaawans { get; set; }

        [Display(Name= "Charakterystyka stanu wiedzy i osiągnięć technicznych w dziedzinie projektu: ")]
        public string StanWiedzy { get; set; }

        public string SkladZespolu { get; set; }

        [Display(Name = "Współpraca z innymi kołami naukowymi lub instytucjami")]
        public string Wspolpraca { get; set; }

        [Display(Name = "Tytuł i numer umowy/zlecenia oraz nazwisko kierownika zespołu badawczego Politechniki Wrocławskiej, z którym związany jest projekt")]
        public string TytulNumerUmowy { get; set; }

        [Display(Name = "Przewidywany rezultat materialny realizacji projektu: ")]
        public string RezultatMaterialny { get; set; }

        [Display(Name = "Przewidywany rezultat poznawczy realizacji projektu: ")]
        public string RezultatPoznawczy { get; set; }

        [Display(Name = "Przewidywany rezultat spoleczny realizacji projektu: ")]
        public string RezultatSpoleczny { get; set; }

        [Display(Name = "Elementy nowości w sformułowaniu celu projektu")]
        public string NowosciCelu { get; set; }

        [Display(Name = "Elementy nowości rozwiązań przewidywanych w projekcie")]
        public string NowosciRozwiazan { get; set; }

        [Display(Name = "Elementy nowości w sposobie realizacji projektu")]
        public string NowosciRealizacji { get; set; }

        [Display(Name = "Elementy nowości w doborze obiektu prac")]
        public string NowosciDoboru { get; set; }

        [Display(Name = "Planowane upowszechnienie uzyskanych wyników")]
        public string Upowszechnienie { get; set; }

        [Display(Name = "Opis strategii pozyskiwania sposorów")]
        public string PozyskiwanieSponsorow { get; set; }
    }
}