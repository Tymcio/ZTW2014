using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WnioskiOnline.Controllers
{
    public class AdminController : Controller
    {
        //
        // GET: /Admin/

        public ActionResult Konkursy()
        {
            return View();
        }

        public ActionResult SzczegolyKonkursu()
        {
            return View();
        }

        public ActionResult Uzytkownicy()
        {
            return View();
        }

    }
}
