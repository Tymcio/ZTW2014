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
        public string NazwaOrganizacji { get; set; }
        public string Miasto { get; set; }
        public string KodPocztowy { get; set; }
        public string Ulica { get; set; }
        public int NumerBudynku { get; set; }
        public int NumerLokalu { get; set; }
        public string Telefon { get; set; }
        public string Email { get; set; }

    }
}