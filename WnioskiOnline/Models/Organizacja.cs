using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WnioskiOnline.Models
{
    [Table("Organizacje")]
    public class Organizacja
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int IdOrganizacji { get; set; }

        [MaxLength(100)]
        [StringLength(100, ErrorMessage = "Nazwa organizacji nie może mieć więcej niż 100 znaków.")]
        public string NazwaOrganizacji { get; set; }

        [MaxLength(30)]
        [StringLength(30, ErrorMessage = "Miasto nie może mieć więcej niż 30 znaków.")]
        public string Miasto { get; set; }

        [MaxLength(6)]
        [StringLength(6, ErrorMessage = "Kod pocztowy nie może mieć więcej niż 6 znaków.")]
        public string KodPocztowy { get; set; }

        [MaxLength(40)]
        [StringLength(40, ErrorMessage = "Ulica nie może mieć więcej niż 40 znaków.")]
        public string Ulica { get; set; }
        public int NumerBudynku { get; set; }
        public int NumerLokalu { get; set; }

        [MaxLength(30)]
        [StringLength(100, ErrorMessage = "Telefon nie może mieć więcej niż 15 znaków.")]
        public string Telefon { get; set; }

        [MaxLength(40)]
        [StringLength(40, ErrorMessage = "Adres email nie może mieć więcej niż 40 znaków.")]
        public string Email { get; set; }

    }
}