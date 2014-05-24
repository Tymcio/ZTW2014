using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WnioskiOnline.Models
{
    [Table("Charaktery")]
    public class Charakter
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int IdCharakteru { get; set; }
        
        [MaxLength(40)]
        [StringLength(40, ErrorMessage = "Charakter zadania nie może mieć więcej niż 40 znaków.")]
        public string NazwaCharakteru { get; set; }


    }
}