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
    public class HomeController : Controller
    {

        private WnioskiContext db = new WnioskiContext();
        public ActionResult Index()
        {
            
            return View(db.Aktualnosci.OrderByDescending(u => u.IdAktualnosci).Take(2).ToList());
            
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public  ActionResult Aktualnosci()
        {
            //var akt = db.Aktualnosci.ToList();
            //return View(akt);

            var zapyt = from s in db.Aktualnosci
                        select new Aktualnosc
                        {
                            TrescAktualnosci = s.TrescAktualnosci
                        };
            return View(zapyt);
        }
    }
}
