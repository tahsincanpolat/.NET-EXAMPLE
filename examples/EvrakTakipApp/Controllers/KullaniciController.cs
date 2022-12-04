using EvrakTakipApp.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EvrakTakipApp.Controllers
{
    public class KullaniciController : Controller
    {
        EvrakTakipDBEntities entity = new EvrakTakipDBEntities();
        // GET: Kullanici
        public ActionResult Index()
        {
            int yetkiId = Convert.ToInt32(Session["yetkiId"]);

            if(yetkiId == 1)
            {
                return View();
            }

            return RedirectToAction("Index", "Login");       

        }

        public ActionResult Olustur()
        {
            int yetkiId = Convert.ToInt32(Session["yetkiId"]);
            
            if (yetkiId == 1)
            {
                return View();
            }

            return RedirectToAction("Index", "Login");

        }

        [HttpPost]
        public ActionResult Olustur(string evrakAd,System.Web.HttpPostedFileBase yuklenecekDosya)
        {

            if (yuklenecekDosya != null)
            {
                string dosyaYolu = Path.GetFileName(yuklenecekDosya.FileName);
                return View();
            }
            else
            {
                return View();

            }


        }

    }
}