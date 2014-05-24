using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WnioskiOnline.Models
{
    [Table("RodzajeWydatku")]
    public class RodzajWydatku
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int IdRodzaju { get; set; }

        [MaxLength(100)]
        [StringLength(100, ErrorMessage = "Rodzaj wydatku nie może mieć więcej niż 100 znaków.")]
        public string NazwaRodzaju { get; set; }


    }
}