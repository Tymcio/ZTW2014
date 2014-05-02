using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WnioskiOnline.Controllers
{
    public class RecenzentController : Controller
    {
        //
        // GET: /Recenzent/

        public ActionResult Wnioski()
        {
            ViewBag.Message = "Wnioski";

            return View();
        }

        public ActionResult Wniosek()
        {
            ViewBag.Message = "Szczegóły wniosku";

            return View();
        }

    }
}
