using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WnioskiOnline.Models
{
    [Table("Dziedziny")]
    public class Dziedzina
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int IdDziedziny { get; set; }

        [MaxLength(40)]
        [StringLength(40, ErrorMessage = "Dziedzina zadania nie może mieć więcej niż 40 znaków.")]
        public string NazwaDziedziny { get; set; }


    }
}