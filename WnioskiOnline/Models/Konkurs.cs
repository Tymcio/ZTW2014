using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WnioskiOnline.Models
{
    [Table("Konkursy")]
    public class Konkurs
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int IdKonkursu { get; set; }

        [Display(Name = "Konkurs ")]
        [MaxLength(20)]
        [StringLength(20, ErrorMessage = "Nazwa konkursu nie może mieć więcej niż 20 znaków.")]
        public string NazwaKonkursu { get; set; }
        public DateTime DataRozpoczecia { get; set; }
        public DateTime DataZakonczenia { get; set; }
    }
}