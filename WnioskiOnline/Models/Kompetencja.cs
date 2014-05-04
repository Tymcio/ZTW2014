using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WnioskiOnline.Models
{
    [Table("Kompetencje")]
    public class Kompetencja
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int IdKompetencji { get; set; }
        public UserProfile Recenzent { get; set; }
        public Dziedzina Dziedzina { get; set; }


    }
}