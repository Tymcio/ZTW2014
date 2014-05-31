using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WnioskiOnline.Models
{
    [Table("Aktualnosci")]
    public class Aktualnosc
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int IdAktualnosci { get; set; }

        [MaxLength(20)]
        [StringLength(20, ErrorMessage = "Aktualnosc nie może mieć więcej niż 50 znaków.")]
        public string TrescAktualnosci { get; set; }

        public class AktualnosciDBContext:WnioskiContext{
        public DbSet<Aktualnosc> Aktualnosci{get;set;
        }
}

    }
}