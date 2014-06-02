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
using WnioskiOnline.Filters;


namespace WnioskiOnline.Controllers
{
    [InitializeSimpleMembership]
    public class KomisjaController : Controller
    {
        private WnioskiContext db = new WnioskiContext();

        public ActionResult Index()
        {
            WnioskiViewModel model = new WnioskiViewModel();

            List<Status> statusy = db.Statusy.ToList();
            List<Konkurs> konkursy = db.Konkursy.ToList();

            statusy.RemoveAt(0);
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
            model.Wnioski = db.Wnioski.OrderBy(w => w.Konkurs.NazwaKonkursu).ToList().FindAll(w => (w.Status.NazwaStatusu != "Do zatwierdzenia" && w.Status.NazwaStatusu != "Do recenzji"));
            return View(model);

        }

        public ActionResult Rozpatrz(string konkurs, int id = 0)
        {

            Wniosek wniosek = db.Wnioski.Find(id);
            if (wniosek != null)
            {
                if (konkurs == "K1N")
                {
                    FormularzK1N model = db.FormularzeK1N.ToList().Find(f => f.IdWniosku == wniosek.IdWniosku);

                    return View("RozpatrzK1N", model);
                }
                else if (konkurs == "K2")
                {
                    FormularzK2 model = db.FormularzeK2.ToList().Find(f => f.IdWniosku == wniosek.IdWniosku);

                    return View("RozpatrzK2", model);
                }
                else if (konkurs == "K3")
                {
                    FormularzK3 model = db.FormularzeK3.ToList().Find(f => f.IdWniosku == wniosek.IdWniosku);

                    return View("RozpatrzK3", model);
                }
            }
            else
            {
                return HttpNotFound();
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult RozpatrzK1N(string Zapisz, string Anuluj, FormularzK1N model)
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

                dbWniosek.IdDecyzji = model.Wniosek.IdDecyzji;
                dbWniosek.DataRozpatrzenia = DateTime.Now;
                dbWniosek.IdStatusu = db.Statusy.ToList().ElementAt(3).IdStatusu;

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
        public ActionResult RozpatrzK2(string Zapisz, string Anuluj, FormularzK2 model)
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

                dbWniosek.IdDecyzji = model.Wniosek.IdDecyzji;
                dbWniosek.DataRozpatrzenia = DateTime.Now;
                dbWniosek.IdStatusu = db.Statusy.ToList().ElementAt(3).IdStatusu;

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
        public ActionResult RozpatrzK3(string Zapisz, string Anuluj, FormularzK3 model)
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

                dbWniosek.IdDecyzji = model.Wniosek.IdDecyzji;
                dbWniosek.DataRozpatrzenia = DateTime.Now;
                dbWniosek.IdStatusu = db.Statusy.ToList().ElementAt(3).IdStatusu;

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
            List<Wniosek> wnioski = db.Wnioski.OrderBy(w => w.Konkurs.NazwaKonkursu).ToList();

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
