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
    public class RecenzentController : Controller
    {
        private WnioskiContext db = new WnioskiContext();
        //
        // GET: /Recenzent/

        public ActionResult Index()
        {
            WnioskiViewModel model = new WnioskiViewModel();

            List<Status> statusy = db.Statusy.ToList();
            List<Konkurs> konkursy = db.Konkursy.ToList();

            statusy.RemoveAt(0);

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
         //   model.Wnioski = db.Wnioski.OrderBy(w => w.Konkurs.NazwaKonkursu).ToList().FindAll(x => x.Recenzent.UserId == WebSecurity.GetUserId(User.Identity.Name));
            model.Wnioski = db.Wnioski.OrderBy(w => w.Konkurs.NazwaKonkursu).ToList().FindAll(w => w.Status.NazwaStatusu != "Do zatwierdzenia" && w.IdRecenzenta == WebSecurity.GetUserId(User.Identity.Name));
            return View(model);

        }

        public ActionResult Recenzja(string konkurs, int id = 0)
        {

            Wniosek wniosek = db.Wnioski.Find(id);
            if (wniosek != null)
            {
                if (konkurs == "K1N")
                {
                    FormularzK1N model  = db.FormularzeK1N.ToList().Find(f => f.IdWniosku == wniosek.IdWniosku);

                    return View("RecenzjaK1N", model);
                }
                else if (konkurs == "K2")
                {
                    FormularzK2 model = db.FormularzeK2.ToList().Find(f => f.IdWniosku == wniosek.IdWniosku);

                    return View("RecenzjaK2", model);
                }
                else if (konkurs == "K3")
                {
                    FormularzK3 model = db.FormularzeK3.ToList().Find(f => f.IdWniosku == wniosek.IdWniosku);

                    return View("RecenzjaK3", model);
                }
            }
            else
            {
                return HttpNotFound();
            }
            return View(wniosek);
        }

        [HttpPost]
        public ActionResult RecenzjaK1N(string Zapisz,string Anuluj, FormularzK1N model)
        {
            if (Anuluj != null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                var dbWniosek = db.Wnioski.FirstOrDefault(p => p.IdWniosku == model.Wniosek.IdWniosku);
                if (dbWniosek == null)
                {
                    return HttpNotFound();
                }

                dbWniosek.Ocena = model.Wniosek.Ocena;
                dbWniosek.DataOceny = DateTime.Now;
                dbWniosek.IdStatusu = db.Statusy.ToList().ElementAt(2).IdStatusu;

            }

            if (ModelState.IsValid)
            {
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            System.Diagnostics.Debug.WriteLine("Not valid");

            return View(model);
        }

        [HttpPost]
        public ActionResult RecenzjaK2(string Zapisz, string Anuluj, FormularzK2 model)
        {
            if (Anuluj != null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                var dbWniosek = db.Wnioski.FirstOrDefault(p => p.IdWniosku == model.Wniosek.IdWniosku);
                if (dbWniosek == null)
                {
                    return HttpNotFound();
                }

                dbWniosek.Ocena = model.Wniosek.Ocena;
                dbWniosek.DataOceny = DateTime.Now;
                dbWniosek.IdStatusu = db.Statusy.ToList().ElementAt(2).IdStatusu;

            }

            if (ModelState.IsValid)
            {
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            System.Diagnostics.Debug.WriteLine("Not valid");

            return View(model);
        }

        [HttpPost]
        public ActionResult RecenzjaK3(string Zapisz, string Anuluj, FormularzK3 model)
        {
            if (Anuluj != null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                var dbWniosek = db.Wnioski.FirstOrDefault(p => p.IdWniosku == model.Wniosek.IdWniosku);
                if (dbWniosek == null)
                {
                    return HttpNotFound();
                }

                dbWniosek.Ocena = model.Wniosek.Ocena;
                dbWniosek.DataOceny = DateTime.Now;
                dbWniosek.IdStatusu = db.Statusy.ToList().ElementAt(2).IdStatusu;

            }

            if (ModelState.IsValid)
            {
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            System.Diagnostics.Debug.WriteLine("Not valid");

            return View(model);
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
            List<Wniosek> wnioski = db.Wnioski.OrderBy(w => w.Konkurs.NazwaKonkursu).ToList().FindAll(w => w.IdRecenzenta == WebSecurity.GetUserId(User.Identity.Name));

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
