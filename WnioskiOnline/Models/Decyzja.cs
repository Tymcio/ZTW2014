using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WnioskiOnline.Models
{
    [Table("Decyzje")]
    public class Decyzja
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int IdDecyzji { get; set; }

        [MaxLength(20)]
        [StringLength(20, ErrorMessage = "Decyzja nie może mieć więcej niż 40 znaków.")]
        public string NazwaDecyzji { get; set; }


    }
}