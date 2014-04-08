using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WnioskiOnline.Controllers
{
    public class WnioskodawcaController : Controller
    {
        //
        // GET: /Wnioskodawca/

        public ActionResult Wnioski()
        {
            ViewBag.Message = "Wnioski";

            return View();
        }

        public ActionResult Wniosek()
        {
            ViewBag.Message = "Dodawanie/Edycja wniosku";

            return View();
        }

    }
}
