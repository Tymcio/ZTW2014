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
    public class WnioskiController : Controller
    {
        private WnioskiContext db = new WnioskiContext();

        //
        // GET: /Wnioski/

        public ActionResult Index()
        { 
            WnioskiViewModel model = new WnioskiViewModel();
            List<Status> statusy = db.Statusy.ToList();       
            List<Konkurs> konkursy = db.Konkursy.ToList();
            Status wszystkieStatusy = new Status();
            Konkurs wszystkie = new Konkurs();
            wszystkie.IdKonkursu = 0;
            wszystkie.NazwaKonkursu = "Wszystkie";
            konkursy.Insert(0,wszystkie);
            model.Konkursy = new SelectList(konkursy, "IdKonkursu", "NazwaKonkursu", 0);


            if (User.IsInRole("Wnioskodawca"))
            {
                wszystkieStatusy.IdStatusu = 0;
                wszystkieStatusy.NazwaStatusu = "Wszystkie";
                statusy.Insert(0, wszystkieStatusy);
                model.Statusy = new SelectList(statusy,"IdStatusu","NazwaStatusu");
                model.Wnioski = db.Wnioski.OrderBy(w => w.Konkurs.NazwaKonkursu).ToList().FindAll(x => x.Wnioskodawca.UserId == WebSecurity.GetUserId(User.Identity.Name));
                return View(model);
            }

            else if (User.IsInRole("Recenzent"))
            {
                statusy.RemoveAt(0);
                wszystkieStatusy.IdStatusu = 0;
                wszystkieStatusy.NazwaStatusu = "Wszystkie";
                statusy.Insert(0, wszystkieStatusy);
                model.Statusy = new SelectList(statusy, "IdStatusu", "NazwaStatusu");
                model.Wnioski = db.Wnioski.OrderBy(w => w.Konkurs.NazwaKonkursu).ToList().FindAll(x => x.Recenzent.UserId == WebSecurity.GetUserId(User.Identity.Name));
                return View(model);
            }

            else
            {
                wszystkieStatusy.IdStatusu = 0;
                wszystkieStatusy.NazwaStatusu = "Wszystkie";
                statusy.Insert(0, wszystkieStatusy);
                model.Statusy = new SelectList(statusy, "IdStatusu", "NazwaStatusu");
                model.Wnioski = db.Wnioski.OrderBy(w => w.Konkurs.NazwaKonkursu).ToList();
                return View(model);
            }
        }

        [HttpPost]
        public ActionResult FiltrujWnioski(WnioskiViewModel model)
        {
            List<Wniosek> wnioski;
            if (User.IsInRole("Wnioskodawca"))
            {
                wnioski = db.Wnioski.OrderBy(w => w.Konkurs.NazwaKonkursu).ToList().FindAll(x => x.Wnioskodawca.UserId == WebSecurity.GetUserId(User.Identity.Name));
            }

            else if (User.IsInRole("Recenzent"))
            {
                wnioski = db.Wnioski.OrderBy(w => w.Konkurs.NazwaKonkursu).ToList().FindAll(x => x.Recenzent.UserId == WebSecurity.GetUserId(User.Identity.Name));
            }
            else
            {
                wnioski = db.Wnioski.OrderBy(w => w.Konkurs.NazwaKonkursu).ToList();
            }

            if (model.Konkurs != 0)
            {   
                wnioski = wnioski.FindAll(w => w.IdKonkursu == model.Konkurs);
            }
            if (model.Status != 0)
            {
                wnioski = wnioski.FindAll(w => w.IdStatusu == model.Status);
            }
            return PartialView("ListaWnioskow", wnioski);
        }



        //
        // GET: /Wnioski/Details/5

        public ActionResult Details(int id = 0)
        {
            Wniosek wniosek = db.Wnioski.Find(id);
            if (wniosek == null)
            {
                return HttpNotFound();
            }
            return View(wniosek);
        }

        //
        // GET: /Wnioski/Create

 


        //
        // GET: /Wnioski/Edit/5

   
        //
        // POST: /Wnioski/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Wniosek wniosek)
        {
            if (ModelState.IsValid)
            {
                db.Entry(wniosek).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(wniosek);
        }

        //
        // GET: /Wnioski/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Wniosek wniosek = db.Wnioski.Find(id);
            if (wniosek == null)
            {
                return HttpNotFound();
            }
            return View(wniosek);
        }

        //
        // POST: /Wnioski/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Wniosek wniosek = db.Wnioski.Find(id);
            db.Wnioski.Remove(wniosek);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}