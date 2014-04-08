using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WnioskiOnline.Controllers
{
    public class KomisjaController : Controller
    {
        //
        // GET: /Komisja/

        public ActionResult Wnioski()
        {
            ViewBag.Message = "Wnioski";

            return View();
        }

        public ActionResult SzczegolyWnioskow()
        {
            ViewBag.Message = "Wnioski - szczegóły";

            return View();
        }

    }
}
