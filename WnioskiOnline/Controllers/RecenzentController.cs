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

        public ActionResult Recenzje()
        {
            ViewBag.Message = "Recenzje";

            return View();
        }

    }
}
