using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WnioskiOnline.Models;

namespace WnioskiOnline.Controllers
{
    public class RecenzentController : Controller
    {
        private WnioskiContext db = new WnioskiContext();
        //
        // GET: /Recenzent/

        public ActionResult Wnioski()
        {
            ViewBag.Message = "Wnioski";

            return View();
        }

       // GET: /Recenzent/Wniosek/
        public ActionResult Wniosek(int id =0)
        {
            ViewBag.Message = "Szczegóły wniosku";
            Wniosek w = db.Wnioski.Find(id);
            
            if (w == null)
            {
                return HttpNotFound();
            }
            return View(w);
        }

    }
}
