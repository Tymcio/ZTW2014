using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WnioskiOnline.Models;
using System.Web.Mvc;

namespace WnioskiOnline.ViewModels
{
    public class EdycjaUzytkownikaViewModel
    {
        public IEnumerable<string> Role { get; set; }
        public UserProfile Uzytkownik { get; set; }
        public string Rola { get; set; }
    }
}