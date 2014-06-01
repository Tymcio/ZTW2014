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

        [MaxLength(250)]
        [StringLength(250, ErrorMessage = "Aktualnosc nie może mieć więcej niż 250 znaków.")]
        public string TrescAktualnosci { get; set; }

        public class AktualnosciDBContext:WnioskiContext{
        public DbSet<Aktualnosc> Aktualnosci{get;set; }
        
}

    }
}