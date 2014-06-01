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
            model.Wnioski = db.Wnioski.OrderBy(w => w.Konkurs.NazwaKonkursu).ToList();

            return View(model);

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


        public ActionResult Konkursy()
        {

            return View(db.Konkursy.ToList());
        }

        public ActionResult EdytujProfil(int id = 0)
        {
            EdycjaUzytkownikaViewModel model = new EdycjaUzytkownikaViewModel();
            model.Uzytkownik = db.UserProfiles.Find(id);
            model.Rola = Roles.GetRolesForUser(model.Uzytkownik.UserName).First();
            model.Role = Roles.GetAllRoles();

            return View(model);
        }

        [HttpPost]
        public ActionResult EdytujProfil(string Zapisz, string Anuluj, EdycjaUzytkownikaViewModel model)
        {
            if (Anuluj != null)
            {
                return RedirectToAction("Uzytkownicy");
            }

            if (ModelState.IsValid)
            {
                string ObecnaRola = Roles.GetRolesForUser(model.Uzytkownik.UserName).First();
                if (ObecnaRola != model.Rola)
                {
                    Roles.RemoveUserFromRole(model.Uzytkownik.UserName, ObecnaRola);
                    Roles.AddUserToRole(model.Uzytkownik.UserName, model.Rola);
                }
                db.Entry(model.Uzytkownik).State = System.Data.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Uzytkownicy");
            }
            System.Diagnostics.Debug.WriteLine("Not valid");

            model.Role = Roles.GetAllRoles();
            return View(model);
        }

        public ActionResult PrzypiszDziedzine(int id = 0)
        {
            PrzypiszDziedzineViewModel model = new PrzypiszDziedzineViewModel();
            model.Recenzent = db.UserProfiles.Find(id);
            List<Kompetencja> komp = db.Kompetencje.Where(k => k.IdRecenzenta == model.Recenzent.UserId).ToList();
            if (komp.Any())
            {
                 model.MaKompetencje = true;
                 model.Kompetencja = komp.First();
                 model.Dziedziny = new SelectList(db.Dziedziny, "IdDziedziny", "NazwaDziedziny", model.Kompetencja.IdDziedziny);
            }
            else
            {
                model.MaKompetencje = false;
                model.Dziedziny = new SelectList(db.Dziedziny, "IdDziedziny", "NazwaDziedziny"); 
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult PrzypiszDziedzine(string Zapisz, string Anuluj, PrzypiszDziedzineViewModel model)
        {
            if (Anuluj != null)
            {
                return RedirectToAction("Recenzenci");
            }

            System.Diagnostics.Debug.WriteLine(model.MaKompetencje);

            if (ModelState.IsValid)
            {
                if (model.MaKompetencje)
                {
                    db.Entry(model.Kompetencja).State = System.Data.EntityState.Modified;
                }
                else
                {
                    model.Kompetencja.IdRecenzenta = model.Recenzent.UserId;
                    db.Kompetencje.Add(model.Kompetencja);
                }
                db.SaveChanges();
                return RedirectToAction("Recenzenci");
            }
            System.Diagnostics.Debug.WriteLine("Not valid");

            model.Dziedziny = new SelectList(db.Dziedziny, "IdDziedziny", "NazwaDziedziny", model.Kompetencja.IdDziedziny); 
            return View(model);
        }

        public ActionResult EdytujKonkurs(int id = 0)
        {
            return View(db.Konkursy.Find(id));
        }

        [HttpPost]
        public ActionResult EdytujKonkurs(string Zapisz, string Anuluj, Konkurs konkurs)
        {
            if (Anuluj != null)
            {
                return RedirectToAction("Konkursy");
            }

            if (ModelState.IsValid)
            {
                db.Entry(konkurs).State = System.Data.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Konkursy");
            }
            System.Diagnostics.Debug.WriteLine("Not valid");
            return View(konkurs);
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
        public ActionResult EdytujK1N(string Zapisz, string Anuluj, SzczegolyK1NViewModel model)
        {
            if (Anuluj != null)
            {
                return RedirectToAction("Index");
            }

            if (ModelState.IsValid)
            {
                db.Entry(model.Formularz).State = System.Data.EntityState.Modified;
                db.Entry(model.Formularz.Wniosek).State = System.Data.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            System.Diagnostics.Debug.WriteLine("Not valid");
            return View(model);
        }

        [HttpPost]
        public ActionResult EdytujK2(string Zapisz,string Anuluj, SzczegolyK2ViewModel model)
        {
            if (Anuluj != null)
            {
                return RedirectToAction("Index");
            }

            if (ModelState.IsValid)
            {
                db.Entry(model.Formularz).State = System.Data.EntityState.Modified;
                db.Entry(model.Formularz.Wniosek).State = System.Data.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            System.Diagnostics.Debug.WriteLine("Not valid");
            return View(model);
        }

        [HttpPost]
        public ActionResult EdytujK3(string Zapisz, string Anuluj, SzczegolyK3ViewModel model)
        {
            if (Anuluj != null)
            {
                return RedirectToAction("Index");
            }

            if (ModelState.IsValid)
            {
                db.Entry(model.Formularz).State = System.Data.EntityState.Modified;
                db.Entry(model.Formularz.Wniosek).State = System.Data.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public ActionResult Uzytkownicy()
        {
            UzytkownicyViewModel model = new UzytkownicyViewModel();
            model.Uzytkownicy = db.UserProfiles.OrderBy(u => u.UserName).ToList();
            List<string> role = Roles.GetAllRoles().ToList();
            role.Insert(0, "Wszystkie");
            model.Role = new SelectList(role, "Wszystkie");
            return View(model);
        }


        public ActionResult Recenzenci()
        {

            return View(db.UserProfiles.ToList().FindAll(u => Roles.GetRolesForUser(u.UserName).First() == "Recenzent"));
        }


        [HttpPost]
        public ActionResult FiltrujUzytkownikow(UzytkownicyViewModel model)
        {
            List<UserProfile> uzytkownicy = db.UserProfiles.OrderBy(u => u.UserName).ToList();

            if (model.Rola != "Wszystkie")
            {
                uzytkownicy = uzytkownicy.FindAll(u => Roles.GetRolesForUser(u.UserName).First() == model.Rola);
            }
            return PartialView("ListaUzytkownikow", uzytkownicy);
        }

        public ActionResult SzczegolyKonta()
        {
            return View();
        }

        public ActionResult PrzypiszRec()
        {
            PrzypiszRecenzentaViewModel model = new PrzypiszRecenzentaViewModel();
           
         //   model.Recenzenci = db.UserProfiles.ToList();
            model.Recenzenci = db.Kompetencje.ToList();
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



        public ActionResult DodajAktualnosc()
        {
            
            return View();
        }

        [HttpPost]
        public ActionResult DodajAktualnosc(Aktualnosc akt)
        {
            if (ModelState.IsValid)
            {

                db.Aktualnosci.Add(akt);
                db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
                return View(akt);
        }

       

        public ActionResult Archiwum()
        {
           
            return View(db.Aktualnosci.ToList());
        }

        public ActionResult Aktualnosci()
            
        {
           
            return View(db.Aktualnosci.ToList());
        }

    }
}
