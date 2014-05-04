using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WnioskiOnline.Models
{
    [Table("Wydatki")]
    public class Wydatek
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int IdWydatku { get; set; }
        public string RodzajWydatku { get; set; }
        public string Wyszczegolnienie { get; set; }
        public double KwotaOgolem { get; set; }
        public double KwotaDoSfinans { get; set; }
        public Wniosek Wniosek { get; set; }


    }
}