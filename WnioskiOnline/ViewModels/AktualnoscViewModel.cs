using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WnioskiOnline.ViewModels
{
    public class AktualnoscViewModel
    {
        public IEnumerable<WnioskiOnline.Models.Aktualnosc> Aktualnosci { get; set; }
        public int IdAktualnosci { get; set; }
        public string TrescAktualnosci { get; set; }
    }
}