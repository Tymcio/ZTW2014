﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WnioskiOnline.Models;
using WebMatrix.WebData;
using WnioskiOnline.ViewModels;
using WnioskiOnline.Filters;

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

        public ActionResult DodajK1N()
        {
            SzczegolyK1NViewModel model = new SzczegolyK1NViewModel();

            model.Dziedziny = new SelectList(db.Dziedziny, "IdDziedziny", "NazwaDziedziny");
            model.Organizacje = new SelectList(db.Organizacje, "IdOrganizacji", "NazwaOrganizacji");

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult DodajK1N(string ZapiszRobocza, string WyslijDoRec, string Anuluj, SzczegolyK1NViewModel model)
        {
            if (Anuluj != null)
                return RedirectToAction("Index");
            else
            {
                model.Formularz.Wniosek.DataZlozenia = DateTime.Now;
                model.Formularz.Wniosek.IdKonkursu = db.Konkursy.ToList().Find(k => k.NazwaKonkursu == "K1N").IdKonkursu;
                //    model.Wniosek.IdWnioskodawcy = WebSecurity.GetUserId(User.Identity.Name);
                model.Formularz.Wniosek.IdWnioskodawcy = 1;

                if (ZapiszRobocza != null)
                    model.Formularz.Wniosek.IdStatusu = db.Statusy.ToList().First().IdStatusu;
                else
                    if (WyslijDoRec != null)
                        model.Formularz.Wniosek.IdStatusu = db.Statusy.ToList().ElementAt(1).IdStatusu;
            }

            if (ModelState.IsValid)
            {
                db.FormularzeK1N.Add(model.Formularz);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            model.Dziedziny = new SelectList(db.Dziedziny, "IdDziedziny", "NazwaDziedziny");
            model.Organizacje = new SelectList(db.Organizacje, "IdOrganizacji", "NazwaOrganizacji");

            return View(model);
        }

        public ActionResult DodajK2()
        {
            SzczegolyK2ViewModel model = new SzczegolyK2ViewModel();

            model.Dziedziny = new SelectList(db.Dziedziny, "IdDziedziny", "NazwaDziedziny");
            model.Organizacje = new SelectList(db.Organizacje, "IdOrganizacji", "NazwaOrganizacji");
            model.Zasiegi = new SelectList(db.Zasiegi, "IdZasiegu", "NazwaZasiegu");
            model.Charaktery = new SelectList(db.Charaktery, "IdCharakteru", "NazwaCharakteru");
            model.RodzajeWydatku = new SelectList(db.RodzajeWydatku, "IdRodzaju", "NazwaRodzaju");

            return View(model);
        }

        //
        // POST: /Wnioski/Create

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult DodajK2(string ZapiszRobocza, string WyslijDoRec, string Anuluj, SzczegolyK2ViewModel model)
        {
            if (Anuluj != null)
                return RedirectToAction("Index");
            else
            {
                model.Formularz.Wniosek.DataZlozenia = DateTime.Now;
                model.Formularz.Wniosek.IdKonkursu = db.Konkursy.ToList().Find(k => k.NazwaKonkursu == "K2").IdKonkursu;
                //    model.Wniosek.IdWnioskodawcy = WebSecurity.GetUserId(User.Identity.Name);
                model.Formularz.Wniosek.IdWnioskodawcy = 1;

                if (ZapiszRobocza != null)
                    model.Formularz.Wniosek.IdStatusu = db.Statusy.ToList().First().IdStatusu;
                else
                    if (WyslijDoRec != null)
                        model.Formularz.Wniosek.IdStatusu = db.Statusy.ToList().ElementAt(1).IdStatusu;
            }

            if (ModelState.IsValid)
            {
                db.FormularzeK2.Add(model.Formularz);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            model.Dziedziny = new SelectList(db.Dziedziny, "IdDziedziny", "NazwaDziedziny");
            model.Organizacje = new SelectList(db.Organizacje, "IdOrganizacji", "NazwaOrganizacji");
            model.Zasiegi = new SelectList(db.Zasiegi, "IdZasiegu", "NazwaZasiegu");
            model.Charaktery = new SelectList(db.Charaktery, "IdCharakteru", "NazwaCharakteru");
            model.RodzajeWydatku = new SelectList(db.RodzajeWydatku, "IdRodzaju", "NazwaRodzaju");

            return View(model);
        }

        public ActionResult DodajK3()
        {
            SzczegolyK3ViewModel model = new SzczegolyK3ViewModel();

            model.Dziedziny = new SelectList(db.Dziedziny, "IdDziedziny", "NazwaDziedziny");
            model.Organizacje = new SelectList(db.Organizacje, "IdOrganizacji", "NazwaOrganizacji");
            model.Zasiegi = new SelectList(db.Zasiegi, "IdZasiegu", "NazwaZasiegu");
            model.Charaktery = new SelectList(db.Charaktery, "IdCharakteru", "NazwaCharakteru");
            model.RodzajeWydatku = new SelectList(db.RodzajeWydatku, "IdRodzaju", "NazwaRodzaju");

            return View(model);
        }

        //
        // POST: /Wnioski/Create

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult DodajK3(string ZapiszRobocza, string WyslijDoRec, string Anuluj, SzczegolyK3ViewModel model)
        {
            if (Anuluj != null)
                return RedirectToAction("Index");
            else
            {
                model.Formularz.Wniosek.DataZlozenia = DateTime.Now;
                model.Formularz.Wniosek.IdKonkursu = db.Konkursy.ToList().Find(k => k.NazwaKonkursu == "K3").IdKonkursu;
                //    model.Wniosek.IdWnioskodawcy = WebSecurity.GetUserId(User.Identity.Name);
                model.Formularz.Wniosek.IdWnioskodawcy = 1;

                if (ZapiszRobocza != null)
                    model.Formularz.Wniosek.IdStatusu = db.Statusy.ToList().First().IdStatusu;
                else
                    if (WyslijDoRec != null)
                        model.Formularz.Wniosek.IdStatusu = db.Statusy.ToList().ElementAt(1).IdStatusu;
            }

            if (ModelState.IsValid)
            {
                db.FormularzeK3.Add(model.Formularz);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            model.Dziedziny = new SelectList(db.Dziedziny, "IdDziedziny", "NazwaDziedziny");
            model.Organizacje = new SelectList(db.Organizacje, "IdOrganizacji", "NazwaOrganizacji");
            model.Zasiegi = new SelectList(db.Zasiegi, "IdZasiegu", "NazwaZasiegu");
            model.Charaktery = new SelectList(db.Charaktery, "IdCharakteru", "NazwaCharakteru");
            model.RodzajeWydatku = new SelectList(db.RodzajeWydatku, "IdRodzaju", "NazwaRodzaju");

            return View(model);
        }



        //
        // GET: /Wnioski/Edit/5

        public ActionResult Edytuj(string konkurs, int id = 0)
        {
        
            Wniosek wniosek = db.Wnioski.Find(id);
            if (wniosek !=null)
            {
                if (konkurs == "K1N")
                {
                    SzczegolyK1NViewModel model = new SzczegolyK1NViewModel();
                    model.Formularz = db.FormularzeK1N.ToList().Find(f => f.IdWniosku == wniosek.IdWniosku);
                    model.Dziedziny = new SelectList(db.Dziedziny, "IdDziedziny", "NazwaDziedziny", model.Formularz.IdDziedziny);
                    model.Organizacje = new SelectList(db.Organizacje, "IdOrganizacji", "NazwaOrganizacji", model.Formularz.IdOrganizacji);

                    return View("EdytujK1N", model);
                }
                else if (konkurs == "K2")
                {
                    SzczegolyK2ViewModel model = new SzczegolyK2ViewModel();
                    model.Formularz = db.FormularzeK2.ToList().Find(f => f.IdWniosku == wniosek.IdWniosku);
                    model.Dziedziny = new SelectList(db.Dziedziny, "IdDziedziny", "NazwaDziedziny", model.Formularz.IdDziedziny);
                    model.Organizacje = new SelectList(db.Organizacje, "IdOrganizacji", "NazwaOrganizacji", model.Formularz.IdOrganizacji);
                    model.Zasiegi = new SelectList(db.Zasiegi, "IdZasiegu", "NazwaZasiegu", model.Formularz.IdZasiegu);
                    model.Charaktery = new SelectList(db.Charaktery, "IdCharakteru", "NazwaCharakteru", model.Formularz.IdCharakteru);
                    model.RodzajeWydatku = new SelectList(db.RodzajeWydatku, "IdRodzaju", "NazwaRodzaju");

                    return View("EdytujK2", model);
                }
                else if (konkurs == "K3")
                {
                    SzczegolyK3ViewModel model = new SzczegolyK3ViewModel();
                    model.Formularz = db.FormularzeK3.ToList().Find(f => f.IdWniosku == wniosek.IdWniosku);
                    model.Dziedziny = new SelectList(db.Dziedziny, "IdDziedziny", "NazwaDziedziny", model.Formularz.IdDziedziny);
                    model.Organizacje = new SelectList(db.Organizacje, "IdOrganizacji", "NazwaOrganizacji", model.Formularz.IdOrganizacji);
                    model.Zasiegi = new SelectList(db.Zasiegi, "IdZasiegu", "NazwaZasiegu", model.Formularz.IdZasiegu);
                    model.Charaktery = new SelectList(db.Charaktery, "IdCharakteru", "NazwaCharakteru", model.Formularz.IdCharakteru);
                    model.RodzajeWydatku = new SelectList(db.RodzajeWydatku, "IdRodzaju", "NazwaRodzaju");

                    return View("EdytujK3", model);
                }
            }
            else
            {
                return HttpNotFound();
            }
            return View(wniosek);
        }

        [HttpPost]
        public ActionResult EdytujK1N(string ZapiszRobocza, string WyslijDoRec, string Anuluj, SzczegolyK1NViewModel model)
        {
            if (Anuluj != null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                model.Formularz.Wniosek.DataZlozenia = DateTime.Now;

                if (ZapiszRobocza != null)
                    model.Formularz.Wniosek.IdStatusu = db.Statusy.ToList().First().IdStatusu;
                else
                    if (WyslijDoRec != null)
                        model.Formularz.Wniosek.IdStatusu = db.Statusy.ToList().ElementAt(1).IdStatusu;
            }
            if (ModelState.IsValid)
            {
                db.Entry(model.Formularz).State = System.Data.EntityState.Modified;
                db.Entry(model.Formularz.Wniosek).State = System.Data.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            System.Diagnostics.Debug.WriteLine("Not valid");
            return RedirectToAction("Invalid");
        }

        [HttpPost]
        public ActionResult EdytujK2(string ZapiszRobocza, string WyslijDoRec, string Anuluj, SzczegolyK2ViewModel model)
        {
            if (Anuluj != null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                model.Formularz.Wniosek.DataZlozenia = DateTime.Now;

                if (ZapiszRobocza != null)
                    model.Formularz.Wniosek.IdStatusu = db.Statusy.ToList().First().IdStatusu;
                else
                    if (WyslijDoRec != null)
                        model.Formularz.Wniosek.IdStatusu = db.Statusy.ToList().ElementAt(1).IdStatusu;
            }
            if (ModelState.IsValid)
            {
                db.Entry(model.Formularz).State = System.Data.EntityState.Modified;
                db.Entry(model.Formularz.Wniosek).State = System.Data.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            System.Diagnostics.Debug.WriteLine("Not valid");
            return RedirectToAction("Invalid");
        }

        [HttpPost]
        public ActionResult EdytujK3(string ZapiszRobocza, string WyslijDoRec, string Anuluj, SzczegolyK3ViewModel model)
        {
            if (Anuluj != null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                model.Formularz.Wniosek.DataZlozenia = DateTime.Now;

                if (ZapiszRobocza != null)
                    model.Formularz.Wniosek.IdStatusu = db.Statusy.ToList().First().IdStatusu;
                else
                    if (WyslijDoRec != null)
                        model.Formularz.Wniosek.IdStatusu = db.Statusy.ToList().ElementAt(1).IdStatusu;
            }
            if (ModelState.IsValid)
            {
                db.Entry(model.Formularz).State = System.Data.EntityState.Modified;
                db.Entry(model.Formularz.Wniosek).State = System.Data.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Invalid");
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