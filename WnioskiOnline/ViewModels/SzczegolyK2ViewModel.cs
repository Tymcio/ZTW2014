﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Entity;
using System.Web.Mvc;
using WnioskiOnline.Models;

namespace WnioskiOnline.ViewModels
{
    public class SzczegolyK2ViewModel
    {
        public SelectList Dziedziny { get; set; }
        public SelectList Organizacje { get; set; }
        public SelectList Zasiegi { get; set; }
        public SelectList Charaktery { get; set; }
        public SelectList RodzajeWydatku { get; set; }
        //   public Wydatek Wydatek { get; set; }
        //  public ZrodloDofinansowania Zrodlo { get; set; }
        public FormularzK2 Formularz { get; set; }


    }
}