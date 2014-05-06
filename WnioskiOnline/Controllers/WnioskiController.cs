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
            List<Status> Statusy = db.Statusy.ToList();
            List<Konkurs> Konkursy = db.Konkursy.ToList();
            List<string> NazwyStatusow = new List<string>();
            List<string> NazwyKonkursow = new List<string>();

            WnioskiViewModel model = new WnioskiViewModel();
            foreach (Konkurs k in Konkursy)
            {
                NazwyKonkursow.Add(k.NazwaKonkursu);
            }
            model.Konkursy = NazwyKonkursow;

            if (User.IsInRole("Wnioskodawca"))
            {
                foreach (Status s in Statusy)
                {
                    NazwyStatusow.Add(s.NazwaStatusu);
                }
                model.Statusy = NazwyStatusow;
                model.Wnioski = db.Wnioski.ToList().FindAll(x => x.Wnioskodawca.UserId == WebSecurity.GetUserId(User.Identity.Name));
                return View(model);
            }

            else if (User.IsInRole("Recenzent"))
            {
                Statusy.RemoveAt(0);
                foreach (Status s in Statusy)
                {
                    NazwyStatusow.Add(s.NazwaStatusu);
                }
                model.Statusy = NazwyStatusow;
                model.Wnioski = db.Wnioski.ToList().FindAll(x => x.Recenzent.UserId == WebSecurity.GetUserId(User.Identity.Name));
                return View(model);
            }
            else if (User.IsInRole("Komisja"))
            {
                Statusy.RemoveAt(0);
                Statusy.RemoveAt(1);
                foreach (Status s in Statusy)
                {
                    NazwyStatusow.Add(s.NazwaStatusu);
                }
                model.Statusy = NazwyStatusow;
                model.Wnioski = db.Wnioski.ToList().FindAll(x => x.CzlonekKomisji.UserId == WebSecurity.GetUserId(User.Identity.Name));
                return View(model);
            }
            else
                foreach (Status s in Statusy)
                {
                    NazwyStatusow.Add(s.NazwaStatusu);
                }
                 model.Statusy = NazwyStatusow;
                model.Wnioski = db.Wnioski.ToList();
                return View(model);
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

        public ActionResult Create()
        {

            return RedirectToAction("K3Wnioskodawca");
        //    return View();
        }

        public ActionResult K3Wnioskodawca()
        {
            SzczegolyWnioskuViewModel model = new SzczegolyWnioskuViewModel();
            List<string> NazwyDziedzin = new List<string>();
            List<string> NazwyOrganizacji = new List<string>();
            List<string> NazwyZasiegow = new List<string>();
            List<string> NazwyCharakterow = new List<string>();
            List<string> NazwyRodzajowWydatku = new List<string>();

            foreach (Dziedzina d in db.Dziedziny.ToList())
            {
                NazwyDziedzin.Add(d.NazwaDziedziny);
            }

            foreach (Organizacja o in db.Organizacje.ToList())
            {
                NazwyOrganizacji.Add(o.NazwaOrganizacji);
            }

            foreach (Zasieg z in db.Zasiegi.ToList())
            {
                NazwyZasiegow.Add(z.NazwaZasiegu);
            }

            foreach (Charakter c in db.Charaktery.ToList())
            {
                NazwyCharakterow.Add(c.NazwaCharakteru);
            }

            foreach (RodzajWydatku r in db.RodzajeWydatku.ToList())
            {
                NazwyRodzajowWydatku.Add(r.NazwaRodzaju);
            }

            model.Dziedziny = NazwyDziedzin;
            model.Organizacje = NazwyOrganizacji;
            model.Zasiegi = NazwyZasiegow;
            model.Charaktery = NazwyCharakterow;
            model.RodzajeWydatku = NazwyRodzajowWydatku;

            return View(model);
        }

        //
        // POST: /Wnioski/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Wniosek wniosek)
        {
            if (ModelState.IsValid)
            {
                db.Wnioski.Add(wniosek);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(wniosek);
        }

        //
        // GET: /Wnioski/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Wniosek wniosek = db.Wnioski.Find(id);
            if (wniosek == null)
            {
                return HttpNotFound();
            }
            return View(wniosek);
        }

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