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
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public string NrIndeksu { get; set; }
        public string Telefon { get; set; }
        public string Email { get; set; }



    }
}