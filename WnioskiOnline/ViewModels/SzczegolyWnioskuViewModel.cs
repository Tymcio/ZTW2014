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
    public class SzczegolyWnioskuViewModel
    {
        public SelectList Dziedziny { get; set; }
        public SelectList Organizacje { get; set; }
        public SelectList Zasiegi { get; set; }
        public SelectList Charaktery { get; set; }
        public SelectList RodzajeWydatku { get; set; }
        //   public Wydatek Wydatek { get; set; }
        //  public ZrodloDofinansowania Zrodlo { get; set; }
        //   public Wniosek Wniosek { get; set; }
        public FormularzK3 Formularz { get; set; }

    }
}