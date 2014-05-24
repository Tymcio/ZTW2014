using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WnioskiOnline.Models
{
    [Table("Koordynatorzy")]
    public class Koordynator
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int IdKoord { get; set; }

        [MaxLength(40)]
        [StringLength(40, ErrorMessage = "Imię koordynatora nie może mieć więcej niż 40 znaków.")]
        public string Imie { get; set; }

        [MaxLength(40)]
        [StringLength(40, ErrorMessage = "Nazwisko koordynatora nie może mieć więcej niż 40 znaków.")]
        public string Nazwisko { get; set; }

        [MaxLength(20)]
        [StringLength(20, ErrorMessage = "Numer indeksu koordynatora nie może mieć więcej niż 40 znaków.")]
        public string NrIndeksu { get; set; }

        [MaxLength(15)]
        [StringLength(15, ErrorMessage = "Telefon koordynatora nie może mieć więcej niż 40 znaków.")]
        public string Telefon { get; set; }

        [MaxLength(40)]
        [StringLength(40, ErrorMessage = "Adres email koordynatora nie może mieć więcej niż 40 znaków.")]
        public string Email { get; set; }



    }
}