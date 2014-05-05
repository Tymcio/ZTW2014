using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WnioskiOnline.Models
{
    [Table("ZrodlaDofinansowania")]
    public class ZrodloDofinansowania
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int IdZrodla { get; set; }
        public string NazwaZrodla { get; set; }
        public string Wyszczegolnienie { get; set; }
        public double Kwota { get; set; }

        public virtual Wniosek Wniosek { get; set; }


    }
}