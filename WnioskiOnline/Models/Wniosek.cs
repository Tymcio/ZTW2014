using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WnioskiOnline.Models
{
    [Table("Wnioski")]
    public class Wniosek
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int IdWniosku { get; set; }

        public virtual Konkurs Konkurs { get; set; }


        public virtual UserProfile Wnioskodawca { get; set; }


        public virtual UserProfile Recenzent { get; set; }

        public virtual UserProfile CzlonekKomisji { get; set; }

        public int Ocena { get; set; }
        public DateTime DataZlozenia { get; set; }
        public DateTime DataOceny { get; set; }
        public DateTime DataRozpatrzenia { get; set; }

    }
}