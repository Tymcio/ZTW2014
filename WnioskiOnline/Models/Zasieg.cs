using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WnioskiOnline.Models
{
    [Table("Zasiegi")]
    public class Zasieg
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int IdZasiegu { get; set; }

        [MaxLength(50)]
        [StringLength(50, ErrorMessage = "Zasięg nie może mieć więcej niż 50 znaków.")]
        public string NazwaZasiegu { get; set; }


    }
}