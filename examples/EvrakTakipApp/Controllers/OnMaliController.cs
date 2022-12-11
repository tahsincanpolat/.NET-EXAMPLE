using EvrakTakipApp.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EvrakTakipApp.Controllers
{
    public class OnMaliController : Controller
    {
        EvrakTakipDBEntities entity = new EvrakTakipDBEntities();
        // GET: Kullanici
        public ActionResult Index()
        {
            int yetkiId = Convert.ToInt32(Session["yetkiId"]);

            if(yetkiId == 2)
            {
                return View();
            }

            return RedirectToAction("Index", "Login");       

        }

        public ActionResult Bekleyen()
        {

            int yetkiId = Convert.ToInt32(Session["yetkiId"]);

            if(yetkiId == 2)
            {
                var evraklar = (from e in entity.Evraklar where e.evrakDurumId == 1 && e.evrakYerId==1 select e).ToList();
                ViewBag.evraklar = evraklar;
                return View();

            }
            return RedirectToAction("Index","Login");
        }

       
    }
}