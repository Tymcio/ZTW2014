using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Entity;
using System.Web.Mvc;
using WnioskiOnline.Models;

namespace WnioskiOnline.ViewModels
{
    public class SzczegolyK1NViewModel
    {
        public SelectList Dziedziny { get; set; }
        public SelectList Organizacje { get; set; }

        public FormularzK1N Formularz { get; set; }
    }
}