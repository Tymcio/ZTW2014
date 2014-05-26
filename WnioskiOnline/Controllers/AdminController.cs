using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using DotNetOpenAuth.AspNet;
using Microsoft.Web.WebPages.OAuth;
using WebMatrix.WebData;
using WnioskiOnline.Filters;
using WnioskiOnline.Models;
using WnioskiOnline.ViewModels;

namespace WnioskiOnline.Controllers
{
    [InitializeSimpleMembership]
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
           
         //   model.Recenzenci = db.UserProfiles.ToList();
            model.Recenzenci = db.UserProfiles.ToList().FindAll(r => Roles.FindUsersInRole("Recenzent",r.UserName).Length > 0);
            model.Wnioski = db.Wnioski.ToList().FindAll(w => w.Status.NazwaStatusu == "Do recenzji");

            return View(model);
        }

        public ActionResult Przypisz(string IdRec, string IdWniosku)
        {

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

            return Json(db.UserProfiles.Find(IdR));
        }

    }
}
