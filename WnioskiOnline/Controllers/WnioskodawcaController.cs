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
    public class WnioskodawcaController : Controller
    {

        private WnioskiContext db = new WnioskiContext();

        //
        // GET: /Wnioskodawca/

        public ActionResult Index()
        {
            WnioskiViewModel model = new WnioskiViewModel();

            List<Status> statusy = db.Statusy.ToList();
            List<Konkurs> konkursy = db.Konkursy.ToList();

            Status wszystkieStatusy = new Status();
            wszystkieStatusy.IdStatusu = 0;
            wszystkieStatusy.NazwaStatusu = "Wszystkie";
            statusy.Insert(0, wszystkieStatusy);

            Konkurs wszystkie = new Konkurs();
            wszystkie.IdKonkursu = 0;
            wszystkie.NazwaKonkursu = "Wszystkie";
            konkursy.Insert(0, wszystkie);

            model.Konkursy = new SelectList(konkursy, "IdKonkursu", "NazwaKonkursu", 0);
            model.Statusy = new SelectList(statusy, "IdStatusu", "NazwaStatusu");
            model.Wnioski = db.Wnioski.OrderBy(w => w.Konkurs.NazwaKonkursu).ToList().FindAll(x => x.Wnioskodawca.UserId == WebSecurity.GetUserId(User.Identity.Name));

            return View(model);

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
                model.Formularz.Wniosek.IdWnioskodawcy = WebSecurity.GetUserId(User.Identity.Name);
             //   model.Formularz.Wniosek.IdWnioskodawcy = 1;

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

        public ActionResult Edytuj(string konkurs, int id = 0)
        {

            Wniosek wniosek = db.Wnioski.Find(id);
            if (wniosek != null)
            {
                if (konkurs == "K1N")
                {
                    SzczegolyK1NViewModel model = new SzczegolyK1NViewModel();
                    model.Formularz = db.FormularzeK1N.ToList().Find(f => f.IdWniosku == wniosek.IdWniosku);
                    model.Dziedziny = new SelectList(db.Dziedziny, "IdDziedziny", "NazwaDziedziny", model.Formularz.Wniosek.IdDziedziny);
                    model.Organizacje = new SelectList(db.Organizacje, "IdOrganizacji", "NazwaOrganizacji", model.Formularz.IdOrganizacji);

                    return View("EdytujK1N", model);
                }
                else if (konkurs == "K2")
                {
                    SzczegolyK2ViewModel model = new SzczegolyK2ViewModel();
                    model.Formularz = db.FormularzeK2.ToList().Find(f => f.IdWniosku == wniosek.IdWniosku);
                    model.Dziedziny = new SelectList(db.Dziedziny, "IdDziedziny", "NazwaDziedziny", model.Formularz.Wniosek.IdDziedziny);
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
                    model.Dziedziny = new SelectList(db.Dziedziny, "IdDziedziny", "NazwaDziedziny", model.Formularz.Wniosek.IdDziedziny);
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

        public ActionResult Szczegoly(string konkurs, int id = 0)
        {

            Wniosek wniosek = db.Wnioski.Find(id);
            if (wniosek != null)
            {
                if (konkurs == "K1N")
                {
                    FormularzK1N model = db.FormularzeK1N.ToList().Find(f => f.IdWniosku == wniosek.IdWniosku);

                    return View("SzczegolyK1N", model);
                }
                else if (konkurs == "K2")
                {
                    FormularzK2 model = db.FormularzeK2.ToList().Find(f => f.IdWniosku == wniosek.IdWniosku);

                    return View("SzczegolyK2", model);
                }
                else if (konkurs == "K3")
                {
                    FormularzK3 model = db.FormularzeK3.ToList().Find(f => f.IdWniosku == wniosek.IdWniosku);

                    return View("SzczegolyK3", model);
                }
            }
            else
            {
                return HttpNotFound();
            }
            return View(wniosek);
        }

        [HttpPost]
        public ActionResult FiltrujWnioski(WnioskiViewModel model)
        {
            List<Wniosek> wnioski = db.Wnioski.OrderBy(w => w.Konkurs.NazwaKonkursu).ToList().FindAll(x => x.Wnioskodawca.UserId == WebSecurity.GetUserId(User.Identity.Name));

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



    }
}
