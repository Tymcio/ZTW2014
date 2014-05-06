using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WnioskiOnline.ViewModels
{
    public class SzczegolyWnioskuViewModel
    {
        public IEnumerable<string> Dziedziny { get; set; }
        public IEnumerable<string> Organizacje { get; set; }
        public IEnumerable<string> Zasiegi { get; set; }
        public IEnumerable<string> Charaktery { get; set; }
        public IEnumerable<string> RodzajeWydatku { get; set; }
        public WnioskiOnline.Models.Wydatek Wydatek { get; set; }
        public WnioskiOnline.Models.ZrodloDofinansowania Zrodlo { get; set; }
        public WnioskiOnline.Models.Wniosek Wniosek { get; set; }
        public WnioskiOnline.Models.FormularzK3 Formularz { get; set; }
        public string Dziedzina { get; set; }
        public string Organizacja { get; set; }
        public string Zasieg { get; set; }
        public string Charakter { get; set; }
        public string RodzajWydatku { get; set; }

    }
}