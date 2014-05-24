using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WnioskiOnline.Models
{
    [Table("Statusy")]
    public class Status
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int IdStatusu { get; set; }
        [Display(Name = "Status")]
        [MaxLength(30)]
        [StringLength(30, ErrorMessage = "Status nie może mieć więcej niż 30 znaków.")]
        public string NazwaStatusu { get; set; }


    }
}