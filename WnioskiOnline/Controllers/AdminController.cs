using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WnioskiOnline.Models;
using WebMatrix.WebData;
using WnioskiOnline.ViewModels;

namespace WnioskiOnline.Controllers
{
    public class AdminController : Controller
    {
        private WnioskiContext db = new WnioskiContext();
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

        public ActionResult SzczegolyKonta()
        {
            return View();
        }

        public ActionResult PrzypiszRec()
        {
            PrzypiszRecenzentaViewModel model = new PrzypiszRecenzentaViewModel();
           
            model.Recenzenci = db.UserProfiles.ToList();
            model.Wnioski = db.Wnioski.ToList();

            return View(model);
        }

        public ActionResult Przypisz(string IdRec, string IdWniosku)
        {
            // This returned data is a sample. You should get it using some logic
            // This can be an object or an anonymous object like this:
            System.Diagnostics.Debug.WriteLine("Przypisz");
            int IdR =  Convert.ToInt32(IdRec.Substring(3));
            int IdW = Convert.ToInt32(IdWniosku.Substring(7));
            var dbWniosek = db.Wnioski.FirstOrDefault(p => p.IdWniosku == IdW);
            if (dbWniosek == null)
            {
                return null;
            }

            dbWniosek.IdRecenzenta = IdR;
            dbWniosek.Recenzent = db.UserProfiles.Find(IdR);
            db.SaveChanges();
            PrzypiszRecenzentaViewModel model = new PrzypiszRecenzentaViewModel();

            model.Recenzenci = db.UserProfiles.ToList();
            model.Wnioski = db.Wnioski.ToList();

            return Json(db.UserProfiles.Find(IdR));
        }

    }
}
