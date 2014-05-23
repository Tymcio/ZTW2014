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
    public class WnioskiViewModel
    {
        public IEnumerable<WnioskiOnline.Models.Wniosek> Wnioski { get; set; }
        public SelectList Statusy { get; set; }
        public SelectList Konkursy { get; set; }
        public int Konkurs { get; set; }
        public int Status { get; set; }
    }
}