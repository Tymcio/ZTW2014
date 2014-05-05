using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WnioskiOnline.Models;
using WebMatrix.WebData;

namespace WnioskiOnline.Controllers
{
    public class WnioskiController : Controller
    {
        private WnioskiContext db = new WnioskiContext();

        //
        // GET: /Wnioski/

        public ActionResult Index()
        {
            List<Wniosek> Wnioski = db.Wnioski.ToList();
            if (User.IsInRole("Wnioskodawca"))
            {
                return View(db.Wnioski.ToList().FindAll(x => x.Wnioskodawca.UserId == WebSecurity.GetUserId(User.Identity.Name)));
            }

            else if (User.IsInRole("Recenzent"))
            {
                return View(db.Wnioski.ToList().FindAll(x => x.Recenzent.UserId == WebSecurity.GetUserId(User.Identity.Name)));
            }
            else if (User.IsInRole("Komisja"))
            {
                return View(db.Wnioski.ToList().FindAll(x => x.CzlonekKomisji.UserId == WebSecurity.GetUserId(User.Identity.Name)));
            }
            else
                return View(db.Wnioski.ToList());
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
            return View();
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