using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WnioskiOnline.Models
{
    [Table("ZrodlaDofinansowania")]
    public class ZrodloDofinansowania
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int IdZrodla { get; set; }

        [MaxLength(100)]
        [StringLength(100, ErrorMessage = "Źrodlo dofinansowania nie może mieć więcej niż 100 znaków.")]
        public string NazwaZrodla { get; set; }

        [MaxLength(500)]
        [StringLength(500, ErrorMessage = "Wyszczególnienie nie może mieć więcej niż 500 znaków.")]
        public string Wyszczegolnienie { get; set; }
        public double Kwota { get; set; }

        public virtual Wniosek Wniosek { get; set; }


    }
}