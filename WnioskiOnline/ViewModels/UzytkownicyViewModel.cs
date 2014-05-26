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
    public class UzytkownicyViewModel
    {

        public SelectList Role { get; set; }

        public IEnumerable<WnioskiOnline.Models.UserProfile> Uzytkownicy { get; set; }

        public string Rola { get; set; }
    }
}