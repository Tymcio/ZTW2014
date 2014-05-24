﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WnioskiOnline.Models
{
    [Table("Zadania")]
    public class Zadanie
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int IdZadania { get; set; }

        [MaxLength(100)]
        [StringLength(100, ErrorMessage = "Nazwa zadania nie może mieć więcej niż 100 znaków.")]
        public string NazwaZadania { get; set; }
        public DateTime DataRozpoczecia { get; set; }
        public DateTime DataZakonczenia { get; set; }
        public double UdzialFinansowyUczelni { get; set; }

        public virtual Wniosek Wniosek { get; set; }


    }
}