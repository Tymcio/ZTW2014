using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WnioskiOnline.Models;

namespace WnioskiOnline.ViewModels
{
    public class PrzypiszDziedzineViewModel
    {
        public SelectList Dziedziny { get; set; }

        public UserProfile Recenzent { get; set; }
        public Kompetencja Kompetencja { get; set; }
        public bool MaKompetencje { get; set; }


    }
}